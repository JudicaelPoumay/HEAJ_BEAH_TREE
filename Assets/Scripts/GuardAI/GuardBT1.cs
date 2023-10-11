using System.Collections.Generic;
using BehaviorTree;

public class GuardBT1 : Tree
{
    public UnityEngine.Transform[] waypoints;

    public float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol1(transform, waypoints, speed);

        return root;
    }
}
