using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class GrabObject : Node
{
    private Transform _transform;
    
    
    public GrabObject(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("GrabbedSphereInRange");
        if (target == null)
        {
            Debug.Log("No Grabbed sphere");
            return NodeState.FAILURE;
        }
        else
        {
            target.SetParent(_transform);
            SetData("GrabbedSphere", target);
            return NodeState.SUCCESS;
        }
    }
}
