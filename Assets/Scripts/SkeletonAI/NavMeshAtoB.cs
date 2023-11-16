using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAtoB : Node
{
    private NavMeshAgent agent;
    private Transform waypoint;
	private float speed;

    public NavMeshAtoB(NavMeshAgent agent, Transform waypoint, float speed) {
        this.agent = agent;
        this.waypoint = waypoint;
        this.speed = speed;
    }

    public override BehaviorTree.NodeState Evaluate()
	{
		if(Vector3.Distance(agent.transform.position, waypoint.position) < 0.1f)
			return BehaviorTree.NodeState.SUCCESS;
        else
        {
            agent.speed = speed;
            agent.SetDestination(waypoint.position);
        }
        return BehaviorTree.NodeState.RUNNING;
    }
}
