using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class PickupObject : Node
{
    public GuardBT2 tree;
    

    public PickupObject(Tree tree) {
        this.tree = tree as GuardBT2;
    }

    public override BehaviorTree.NodeState Evaluate() {
        tree.selectedCrate.SetParent(null);
        tree.selectedCrate.SetParent(tree.transform);
        tree.hasCrate = true;
        return NodeState.SUCCESS;
    }
}
