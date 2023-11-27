using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : BehaviorTree.Node
{
    private Transform _target;
    private Transform _transform;
    private NavMeshAgent _agent;
    private float fleeSpeed;

    public Flee(Transform transform, NavMeshAgent agent) 
    {  
        _transform = transform;
        _agent = agent;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        Debug.Log("Flee");
        _target = (Transform)GetData("Target");
        Debug.Log("inRange");
        Vector3 direction = _transform.position - _target.position;
        direction.Normalize();
        _agent.SetDestination(direction*10);
        _agent.speed = 4f;
        return BehaviorTree.NodeState.SUCCESS;  
    }
}
