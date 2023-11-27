using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGuardRange : BehaviorTree.Node
{
    private int _guardLayerMarck = 1 << LayerMask.NameToLayer("Guard");
    private Transform _transform;
    private float _fovRange;

    public CheckGuardRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _fovRange = fovRange;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _fovRange, _guardLayerMarck);
        if (colliders.Length > 0)
        {
            Debug.Log("Princesses");
            SetData("Target", colliders[0].transform);
            return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
}
