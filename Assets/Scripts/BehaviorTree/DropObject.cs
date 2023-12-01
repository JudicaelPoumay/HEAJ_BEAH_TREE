using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;

public class DropObject : Node
{
    public Tree dropperTree;

    public GameObject objectToDrop;
    public int dropCount, currentDropCount;
    public float currentDropCooldown;
    public float dropCooldown;

    public DropObject(Tree dropperTree, GameObject objectToDrop, float dropCooldown, int dropCount) {
        this.dropperTree = dropperTree;
        this.objectToDrop = objectToDrop;
        this.dropCooldown = dropCooldown;
        this.dropCount = dropCount;
        this.currentDropCount = (dropperTree as SkelBT2).trapDropped;
    }

    public DropObject(Tree dropperTree, GameObject objectToDrop) {
        this.dropperTree = dropperTree;
        this.objectToDrop = objectToDrop;
        this.dropCooldown = 2f;
        this.dropCount = 2;
        this.currentDropCount = (dropperTree as SkelBT2).trapDropped;
    }

    public bool canDrop => (currentDropCount < dropCount) && currentDropCooldown <= 0;

    public override NodeState Evaluate() {

        currentDropCooldown -= Time.deltaTime;

        Drop();

        return NodeState.SUCCESS;
    }

    public void Drop() {
        if(canDrop) {

            (dropperTree as SkelBT2).trapDropped++;
            currentDropCooldown = dropCooldown;
            GameObject.Instantiate(objectToDrop, dropperTree.transform.position, Quaternion.identity);
        }
    }
}
