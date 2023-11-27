using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GoToPoint : BehaviorTree.Node
{
    private Transform _transform;
    private Animator _animator;
    private Transform _waypoint;
    private NavMeshAgent _agent;
    public GoToPoint(Transform transform, Transform waypoint, NavMeshAgent agent)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _waypoint = waypoint;
        _agent = agent;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if(Vector3.Distance(_transform.position, _waypoint.position) < 0.1f) 
        {
            _transform.position = _waypoint.position;
            return BehaviorTree.NodeState.SUCCESS;
        }
        else
        {
            _agent.SetDestination(_waypoint.position);
            _agent.speed = 4.5f;
            return BehaviorTree.NodeState.FAILURE;
        }
    }
}
