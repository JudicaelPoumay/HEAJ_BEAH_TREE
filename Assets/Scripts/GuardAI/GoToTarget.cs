using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToTarget : BehaviorTree.Node
{
    
    private Transform _transform;
    private Transform _target;
    private Animator _animator;
    private NavMeshAgent _agent;
    

    public GoToTarget(Transform transform, NavMeshAgent agent)
    {
        _animator = transform.GetComponent<Animator>();
        _transform = transform;
        _agent = agent;
    }
    public override BehaviorTree.NodeState Evaluate()
    {

        if (GetData("Target") != null)
        {
            Debug.Log("movetotarget");
            _target = (Transform)GetData("Target");
            if (Vector3.Distance(_transform.position, _target.position) < 0.01f)
            {
                _transform.position = _target.position;
                _animator.SetBool("Walking", false);
            }
            else
            {
                Debug.Log("movetotarget");
                _agent.SetDestination(_target.position);
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
