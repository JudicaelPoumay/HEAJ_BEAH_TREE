using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private float _speed;
    private NavMeshAgent _agent;

    public TaskGoToTarget(Transform transform, float speed, NavMeshAgent agent)
    {
        _transform = transform;
        _speed = speed;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target == null)
            return NodeState.FAILURE;

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _agent.SetDestination(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
