using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class SelectRandomObject : Node
{
    private List<Transform> randomList;
    private GuardBT2 tree;
    

    public SelectRandomObject(List<Transform> randomList, Tree tree) {
        this.randomList = randomList;
        this.tree = tree as GuardBT2;
    }

    public override BehaviorTree.NodeState Evaluate() {
        //Debug.Log("Enterer select random node");
        if(randomList.Count <= 0) return NodeState.FAILURE;

        int randIndex = Random.Range(0, randomList.Count);
        //Debug.Log($"Random object selected at index : {randIndex}");
        tree.selectedCrate = randomList[randIndex];
        tree.hasSelectedCrate = true;
        return NodeState.SUCCESS;
    }
}
