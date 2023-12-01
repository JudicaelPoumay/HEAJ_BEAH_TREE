using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class GuardBT2 : Tree
{
	public UnityEngine.Transform[] waypoints1;
	public float speed = 6f;
	public float fovRange = 2f;
	public float cratePickupRange;
	public float attackRadius;
	public NavMeshAgent agent;

	public Transform[] allCrates;
	public Transform selectedCrate;
	public bool hasCrate;
	public bool hasSelectedCrate;

	private SkelBT2 skel => FindObjectOfType<SkelBT2>();

	protected override Node SetupTree()
	{
		Node root = new Selector(new List<Node>
		{
			new Selector(new List<Node> {
				new Sequence(new List<Node> {
					new CheckBool(this, "hasCrate", false, ""),
					new CheckRange(transform, skel.transform, attackRadius, returnDataName:"SkelInRange"),
					new TaskAttack("SkelInRange", 15),
				}),
				new Sequence(new List<Node> {
					new CheckBool(this, "hasCrate", false, ""),
					new CheckRange(transform, skel.transform, fovRange, "Target"),
					new NavMeshAtoB(agent, skel.transform, speed),
				}),
			}),
			new Sequence(new List<Node> {
				new CheckBool(this, "hasCrate", false, ""),
				new Selector(new List<Node> {
					new CheckBool(this, "hasSelectedCrate", true, ""),
					new SelectRandomObject(allCrates.ToList(), this),
				}),
				new NavMeshAtoB(agent, this, speed, cratePickupRange, ""),
				new PickupObject(this),
				new DebugNode("Crate picked up"),
			}),
			new NavMeshPatrol(agent, waypoints1, speed)
		 });

		return root;
	}

	private void Update() {
		base.Update();
		agent.speed = speed;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, fovRange);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, cratePickupRange);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, attackRadius);

	}

	public void ReduceSpeed(float percent, float time) {
		StartCoroutine(ReduceSpeedCoroutine(percent, time));
	}

	public IEnumerator ReduceSpeedCoroutine(float percent, float time) {
		float tempSpeed = speed;

		speed = speed * percent;

		//Debug.Log("Reduced guard speed");

		yield return new WaitForSeconds(tempSpeed);

		speed = tempSpeed;
	}
}