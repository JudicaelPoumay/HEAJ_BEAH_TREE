using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class GuardBT1 : Tree
{
	public UnityEngine.Transform[] waypoints1;
	public float speed = 6f;
	public float fovRange = 2f;
	public NavMeshAgent agent;

	protected override Node SetupTree()
	{
		Node root = new Selector(new List<Node>
		{
            new Sequence(new List<Node>
            {
               new CheckInRange(transform),
			   new TaskAttack(transform),
            }),
            new Sequence(new List<Node>
			{
				new CheckEnemyRange(transform, fovRange),
				new GoToTarget(agent, speed)
			}),
			new Sequence(new List<Node>
			{
				new NavMeshPatrol(agent, waypoints1, speed)
			}),
            
         });

		return root;
	}

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, fovRange);
    }
}