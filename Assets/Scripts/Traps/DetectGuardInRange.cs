using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class DetectGuardInRange : Node
{
   public static int  GuardLayer = 1 << LayerMask.NameToLayer("Guard");

   private Transform _transform;
   private float _DetectRange;

    public DetectGuardInRange(Transform transform, float DetectRange)
    {
        _transform = transform;
        _DetectRange = DetectRange;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] col = Physics.OverlapSphere(_transform.position, _DetectRange, GuardLayer);
            if (col.Length > 0)
            {
                SetData("target", col[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }
             state = NodeState.FAILURE;
             return state;
        }
        
        state = NodeState.RUNNING;
        return state;
    }    
}
