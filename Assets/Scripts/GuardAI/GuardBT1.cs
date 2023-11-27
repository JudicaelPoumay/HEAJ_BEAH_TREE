using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class GuardBT1 : BehaviorTree.Tree
{
	public UnityEngine.Transform[] waypoints1;
	public UnityEngine.Transform[] waypoints2;
	public float fovRange = 2f;
	public NavMeshAgent agent;

    private float _slowTimeCounter;
    private float _slowSpeedTime = 2f;

    private float _normalSpeed;
    private float _slowedSpeed;


    public void Start()
    {
        base.Start();
        _normalSpeed = agent.speed;
    }
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
				new GoToTarget(transform, agent)
			}),

            new TaskPatrol2(transform, waypoints1, agent),
            
         });
		 
		

		return root;
	}

    private void Update()
    {
        base.Update();
        if (_slowTimeCounter <= 0f)
            agent.speed = _normalSpeed;
        else _slowTimeCounter -= Time.deltaTime;
    }

    public void slowSpeed()
    {
        _normalSpeed = agent.speed;
        _slowedSpeed = agent.speed/2;
        agent.speed = _slowedSpeed;
        _slowTimeCounter = 2;
    }
}
