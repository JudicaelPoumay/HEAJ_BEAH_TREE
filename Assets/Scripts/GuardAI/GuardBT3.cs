using System.Collections.Generic;
using BehaviorTree;

public class GuardBT3 : Tree
{
    public UnityEngine.Transform[] waypoints;

    public float speed = 2f;
    public static float fovRange = 15f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform, attackRange),
                new TaskAttack(transform),
            }),
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
