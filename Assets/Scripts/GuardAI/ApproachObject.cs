using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class ApproachObject : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    
    public ApproachObject(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("sphere");
        if(target == null)
        {
            Debug.Log("sadly they are no sphere to grab :( ");
            state = NodeState.FAILURE;
            return state;
        }
        else
        {
            _agent.SetDestination(target.position);
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
