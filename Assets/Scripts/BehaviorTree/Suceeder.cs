using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaitNode : BehaviorTree.Node
{
    BehaviorTree.Node node;
    
    public WaitNode(BehaviorTree.Node node, float waitTime)
    {
        this.node = node;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if(node.Evaluate() == BehaviorTree.NodeState.FAILURE)
            return BehaviorTree.NodeState.SUCCESS;
        return BehaviorTree.NodeState.FAILURE;
    }
}