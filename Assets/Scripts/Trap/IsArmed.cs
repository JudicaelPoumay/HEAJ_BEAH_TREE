using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsArmed : BehaviorTree.Node
{
    private TrapBT1 _tree;
    public IsArmed(TrapBT1 tree)
    {
        _tree = tree;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_tree.isArmed != false) return BehaviorTree.NodeState.SUCCESS;
        return BehaviorTree.NodeState.FAILURE;
    }
}
