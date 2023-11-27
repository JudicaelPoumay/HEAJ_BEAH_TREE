using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLifeTime : BehaviorTree.Node
{
    private TrapBT1 _tree;
    private float _lifeTime = 5f;
    private float _lifeTimeCounter;
    public TrapLifeTime(TrapBT1 tree)
    {
        _tree = tree;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_tree.isArmed == true)
        {
            _lifeTimeCounter += Time.deltaTime;
            if (_lifeTimeCounter >= _lifeTime) return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
}
