using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class SimpleMove : Node
{
    private Transform moveTransform;
    private Transform waypoint;
	private float speed;

    public SimpleMove(Transform moveTransform, Transform waypoint, float speed) {
        this.moveTransform = moveTransform;
        this.waypoint = waypoint;
        this.speed = speed;
    }

    public override BehaviorTree.NodeState Evaluate()
	{
		if(Vector3.Distance(moveTransform.position, waypoint.position) < 0.01f)
			return BehaviorTree.NodeState.SUCCESS;
        else
        {
            moveTransform.position = Vector3.MoveTowards(moveTransform.position, waypoint.position, speed*Time.deltaTime);
        }
        return BehaviorTree.NodeState.RUNNING;
    }

}
