using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class MoveToPoint : Node
{
    private Transform _transform;
    private Transform _waypoint;
    private float _speed;

    private NavMeshAgent _Agent;

    //private int _currentWaypointIndex = 0;

    public MoveToPoint(Transform transform, Transform waypoint, float speed, NavMeshAgent agent)
    {
        _transform = transform;
        _waypoint = waypoint;
        _speed = speed;
        _Agent = agent;
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(_transform.position, _waypoint.position) < 0.01f)
        {
            _transform.position = _waypoint.position;
            return NodeState.SUCCESS;
        }
        else
        {
            _Agent.SetDestination(_waypoint.position);
            return NodeState.FAILURE;
        }

    }

}
