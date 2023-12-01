using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavMeshPatrol : Node
{
    private NavMeshAgent agent;
    private Transform[] waypoints;
	private float speed;

	private int _currentWayPointIdx = 0;

    public NavMeshPatrol(NavMeshAgent agent, Transform[] waypoints, float speed) {
        this.agent = agent;
        this.waypoints = waypoints;
        this.speed = speed;
    }

    public override BehaviorTree.NodeState Evaluate()
	{
        agent.speed = speed;

        //Debug.Log("Current waypoint index : " + _currentWayPointIdx);
		if(_currentWayPointIdx == waypoints.Length)
			return BehaviorTree.NodeState.SUCCESS;
		Transform wp = waypoints[_currentWayPointIdx];
		if(Vector3.Distance(agent.transform.position, wp.position) < 0.1f)
        {
			agent.transform.position = wp.position;
			_currentWayPointIdx = (_currentWayPointIdx+1) % waypoints.Length;
        }
        else
        {
            agent.SetDestination(wp.position);
        }

		return BehaviorTree.NodeState.RUNNING;
    }

    public override void Reset()
	{
		_currentWayPointIdx = 0;
	}
}
