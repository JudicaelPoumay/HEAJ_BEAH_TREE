using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class Deposit : Node
{
    private Transform _transform;

    public Deposit (Transform transform)
    {
        _transform = transform;
    }


    public override NodeState Evaluate()
    {
        Transform targetSphere = (Transform)GetData("GrabbedSphere");
        bool HasArrived = (bool)GetData("Arrived");
        if (HasArrived && targetSphere != null)
        {
            targetSphere.parent = null;
            targetSphere.gameObject.layer = LayerMask.NameToLayer("DepositObject");
            ClearData("GrabbedSphere");
            ClearData("sphere");
            ClearData("GrabbedSphereInRange");
            return NodeState.SUCCESS;
        }
        else
        {
            Debug.Log("not good");
            return NodeState.FAILURE;
        }
        
    }
}
