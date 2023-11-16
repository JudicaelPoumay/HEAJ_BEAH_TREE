using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskAvoid : Node
{
    private float _speed = 5;
    private Transform _target;
    private NavMeshAgent agent;
    private float fov;
    Vector2 newDestination;

    public TaskAvoid(NavMeshAgent agent, float speed) {
        this.agent = agent;
        this._speed = speed;
    }

    public override BehaviorTree.NodeState Evaluate()
    {

        if (GetData("Target") != null)
        {
            _target = (Transform)GetData("Target");
            if(_target == null) {
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            else
            {
                Debug.Log("ESCAPE CODE REACHED");
                agent.speed = _speed;
                newDestination = (agent.transform.position - _target.position).normalized * 15;
                agent.SetDestination(newDestination);
            }


            return BehaviorTree.NodeState.SUCCESS;
        }
        else
        {
            return BehaviorTree.NodeState.FAILURE;
        }
    }
}
