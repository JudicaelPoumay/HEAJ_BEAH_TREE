using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckOBJinRange : Node
{
    private static int _sphereLayerMask = 1 << LayerMask.NameToLayer("Sphere");

    private Transform _transform;
    private Animator _animator;
    private float _fovRange;

    public CheckOBJinRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _fovRange = fovRange;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("sphere");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, _fovRange, _sphereLayerMask);

            if (colliders.Length > 0)
            {
                SetData("sphere", colliders[0].transform);
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
