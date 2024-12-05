using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class death : Node
{
    private Transform _transform;

    public death(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        _transform.GetComponent<EnemyManager>()._Die();

        state = NodeState.SUCCESS;
        return state;
    }

}
