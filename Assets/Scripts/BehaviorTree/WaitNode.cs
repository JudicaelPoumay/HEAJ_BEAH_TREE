using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaitNode : BehaviorTree.Node
{
    BehaviorTree.Node node;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;

    public WaitNode(BehaviorTree.Node node, float waitTime)
    {
        this.node = node;
        this.waitTime = waitTime;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;
            }
        }
        else
        {
            node.Evaluate();
            waiting = true;
            waitCounter = 0f;
        }
        return BehaviorTree.NodeState.SUCCESS;
    }
}