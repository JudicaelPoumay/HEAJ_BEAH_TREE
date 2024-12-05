using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
public class MoveToDeposit : Node
{
    public Transform _transform;
    public Transform _Deposit;
    public NavMeshAgent _agent;
    public bool HasArrived = false;

    public MoveToDeposit(Transform transform, Transform Deposit, NavMeshAgent Agent)
    {
        _transform = transform;
        _Deposit = Deposit;
        _agent = Agent;
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(_transform.position, _Deposit.position) < 1f)
        {
            _transform.position = _Deposit.position;
            HasArrived = true;
            SetData("Arrived", HasArrived);
            return NodeState.SUCCESS;
        }
        else
        {
            HasArrived = false;
            _agent.SetDestination(_Deposit.position);
        }
        return NodeState.RUNNING;
    }
}
