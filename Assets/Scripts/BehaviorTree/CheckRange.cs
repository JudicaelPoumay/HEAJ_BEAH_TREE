using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UIElements;
using Tree = BehaviorTree.Tree;

public class CheckRange : Node
{
    private Transform thisTransform;
    private float checkRadius;
    public Transform target;
    public string returnDataName;

    string debug;

    public CheckRange(Transform thisTransform, Transform targetTransform, float checkRadius, string returnDataName, string debug = "") {
        this.thisTransform = thisTransform;
        this.checkRadius = checkRadius;

        this.target = targetTransform;

        this.returnDataName = returnDataName;

        this.debug = debug;
    }

    public CheckRange(Transform thisTransform, string targetDataName, float checkRadius, string returnDataName) {
        this.thisTransform = thisTransform;
        this.checkRadius = checkRadius;

        this.target = (Transform)GetData(targetDataName);

        this.returnDataName = returnDataName;
    }

    public CheckRange(Transform thisTransform, Transform targetTransform, float checkRadius) {
        this.thisTransform = thisTransform;
        this.target = targetTransform;
        this.checkRadius = checkRadius;
    }

    public override NodeState Evaluate() {
        if(target == null) return NodeState.FAILURE;

        if (Vector3.Distance(thisTransform.position, target.position) < checkRadius) {
            if(debug != "") Debug.Log(debug);
            SetData(returnDataName, target);
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }

    public override void Reset() {
        ClearData(returnDataName);
    }
}
