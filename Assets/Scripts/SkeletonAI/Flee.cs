using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;

public class Flee : Node
{
    private Transform _transform;
    private float _speed;
    public UnityEngine.AI.NavMeshAgent _agent;

    public Flee(Transform transform, float speed, UnityEngine.AI.NavMeshAgent agent)
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

		Debug.Log(target);
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
			Vector3 awayDirection = (_transform.position-target.position).normalized*15;
            _agent.SetDestination(awayDirection);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
