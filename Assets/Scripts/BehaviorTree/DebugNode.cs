using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class DebugNode : Node
{
    private string message;
    
    public DebugNode(string message) {
        this.message = message;
    }

    public override BehaviorTree.NodeState Evaluate() {
        Debug.Log($"<color=#35E88C>Debug Node : {message}</color>");
        return NodeState.SUCCESS;
    }
}
