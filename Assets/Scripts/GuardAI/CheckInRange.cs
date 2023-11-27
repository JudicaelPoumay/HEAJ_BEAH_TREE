using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInRange : BehaviorTree.Node
{
    
    private Transform _transform;
    private Transform _target;
    private Animator _animator;

    public CheckInRange(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
        _transform = transform;
    }
    public override BehaviorTree.NodeState Evaluate()
    {
        if (GetData("Target") != null)
        {
            _target = (Transform)GetData("Target");
            if (_target == null)
            {
                _animator.SetBool("Attacking", false);
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            if (Vector3.Distance(_transform.position, _target.position) < 1.5f)
            {
                _animator.SetBool("Walking", false);
                Debug.Log("inRange");
                return BehaviorTree.NodeState.SUCCESS;
            }
            else
            {
                return BehaviorTree.NodeState.FAILURE;
            }
            
        }
        else
        {
            return BehaviorTree.NodeState.FAILURE;
        }

    }
}
