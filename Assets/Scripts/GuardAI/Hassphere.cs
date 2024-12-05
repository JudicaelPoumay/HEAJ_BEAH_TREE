using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Hassphere : Node
{
    
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("GrabbedSphere");
        if (target == null)
        {
            Debug.Log("guard dont hold a sphere");
            return NodeState.FAILURE;
        }
        else
        {
            return NodeState.SUCCESS;
        }
    }
}
