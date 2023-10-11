using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckGuardInFOVRange : Node
{
    private static int _guardLayerMask = 1 << LayerMask.NameToLayer("Guard");

    private Transform _transform;
    private Animator _animator;
    private float _fovRange;

    public CheckGuardInFOVRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _fovRange = fovRange;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, _fovRange, _guardLayerMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                _animator.SetBool("Walking", true);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
