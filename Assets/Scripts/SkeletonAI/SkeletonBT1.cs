using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class SkeletonBT1 : Tree
{
    public UnityEngine.GameObject skeleton;
    public UnityEngine.Transform waypoints;
    public NavMeshAgent agent;
    public float fovRange = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckGuardRange(transform, fovRange),
                new Flee(transform, agent),
            }),
            new Sequence(new List<Node>()
            {
                new GoToPoint(transform, waypoints, agent),
                new SkeletonDestroy(skeleton),
            }),
        });
        return root;
    }
}
