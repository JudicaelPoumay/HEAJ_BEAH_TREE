using System.Collections.Generic;
using BehaviorTree;

public class GuardBT2 : Tree
{
    public UnityEngine.Transform[] waypoints;

    public float speed = 2f;
    public float fovRange = 6f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform, fovRange),
                new TaskGoToTarget(transform, speed),
            }),
            new TaskPatrol2(transform, waypoints, speed),
        });

        return root;
    }
}
