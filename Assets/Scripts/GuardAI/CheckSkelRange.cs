using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSkelRange : BehaviorTree.Node
{
    private int _enemyLayerMask = 1 << LayerMask.NameToLayer("Skel");
    private Transform _transform;
    private float _fovRange;

    public CheckSkelRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _fovRange = fovRange;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _fovRange, _enemyLayerMask);
        if (colliders.Length > 0 )
        {
            SetData("TargetGuard", colliders[0].transform);
            return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
     
}
