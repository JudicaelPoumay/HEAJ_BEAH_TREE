using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class CheckBool : Node
{
    private Tree tree;
    private string toCheck;
    private bool returnTrueIf;
    private string debugMessage;
    

    public CheckBool(Tree tree, string toCheck, bool returnTrueIf, string debugMessage = "") {
        this.tree = tree;
        this.toCheck = toCheck;
        this.returnTrueIf = returnTrueIf;
        this.debugMessage = debugMessage;
    }

    public override BehaviorTree.NodeState Evaluate() {
        if((bool)tree.GetType().GetField(toCheck).GetValue(tree) == returnTrueIf){
            //if(debugMessage != "") Debug.Log($"{debugMessage} | If is true");
            return NodeState.SUCCESS;
        } else {
            //if(debugMessage != "") Debug.Log($"{debugMessage} | If is false");
            return NodeState.FAILURE;
        }
    }
}
