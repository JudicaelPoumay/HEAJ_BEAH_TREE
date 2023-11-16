using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;
using UnityEngine.AI;

public class SkeletonBT : Tree 
{ 
    public Transform waypoint;
    public NavMeshAgent agent;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
		{
            new Sequence(new List<Node> {
                new CheckSkelRange(transform, 5f),
                new TaskAvoid(agent, 7f),
            }),
            new Sequence(new List<Node>{
			    new NavMeshAtoB(agent, waypoint, 4),
                new DestroyNode(this.gameObject),
            }),
		});

		return root;
    }
}
