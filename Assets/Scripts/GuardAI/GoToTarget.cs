using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToTarget : BehaviorTree.Node
{
    
    private float _speed;
    private Transform _transform;
    private Transform _target;
    private Animator _animator;
    private NavMeshAgent agent;

    

    public GoToTarget(NavMeshAgent agent, float speed)
    {
        _animator = agent.transform.GetComponent<Animator>();
        _speed = speed;
        _transform = agent.transform;
        this.agent = agent;
    }
    public override BehaviorTree.NodeState Evaluate()
    {
        agent.speed = _speed;

        if (GetData("Target") != null)
        {
            _target = (Transform)GetData("Target");
            if(_target == null) {
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            if (Vector3.Distance(_transform.position, _target.position) < 0.5f)
            {
                _transform.position = _target.position;
                _animator.SetBool("Walking", false);
            }
            else
            {
                agent.SetDestination(_target.position);
                _transform.LookAt(_target.position);
                _animator.SetBool("Walking", true);
            }


            return BehaviorTree.NodeState.SUCCESS;
        }
        else
        {
            return BehaviorTree.NodeState.FAILURE;
        }
        
    }
}