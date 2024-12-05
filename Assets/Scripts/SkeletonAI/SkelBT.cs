using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class SkelBT : Tree
{
    public UnityEngine.Transform waypoint;

    public float speed = 2f;
    public static float fovRange = 7.5f;
    public static float attackRange = 1f;
    public NavMeshAgent _agent;
    public GameObject traps;



    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new MoveToPoint(transform, waypoint, speed, _agent),
                new death(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckGuardInFOVRange(transform, fovRange),
                //new DebugNode("guard repere"),
                new FleeGuard(transform, speed, _agent),
                //new DebugNode("flee"),
                //new DropTraps(traps, transform),
                //new DebugNode("Drop"),
            }),
        });

        return root;
    }
}