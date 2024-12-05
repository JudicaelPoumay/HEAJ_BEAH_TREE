using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckOBJinGrabRange : Node
{
    private Transform _transform;
    private float _GrabRange;
    public bool IsInRange = false;

    public CheckOBJinGrabRange(Transform transform, float GrabRange)
    {
        _transform = transform;
        _GrabRange = GrabRange;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("sphere");
        if (target == null)
        {
            Debug.Log("fail");
            return NodeState.FAILURE;
        }
        if(Vector3.Distance(_transform.position, target.position) <= _GrabRange)
        {
            SetData("GrabbedSphereInRange", target);
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}
