using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyRange : BehaviorTree.Node
{
    private int _enemyLayerMarck = 1 << LayerMask.NameToLayer("Enemy");
    private Transform _transform;
    private float _fovRange;

    public CheckEnemyRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _fovRange = fovRange;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _fovRange,_enemyLayerMarck);
        if (colliders.Length > 0 )
        {
            SetData("Target", colliders[0].transform);
            return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
     
}
