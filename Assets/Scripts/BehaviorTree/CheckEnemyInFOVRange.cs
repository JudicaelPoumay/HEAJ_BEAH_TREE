using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private int _layerMask;

    private Transform _transform;
    private Animator _animator;
    private float _fovRange;

    public CheckEnemyInFOVRange(Transform transform, float fovRange, string layerName)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _fovRange = fovRange;
        _layerMask = 1 << LayerMask.NameToLayer(layerName);
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, _fovRange, _layerMask);

            if (colliders.Length > 0)
            {
                SetData("target", colliders[0].transform);
				Debug.Log(""+_layerMask+colliders[0].transform);
                if(_animator)
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
