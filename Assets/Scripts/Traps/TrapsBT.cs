using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class TrapsBT : Tree
{
    
    public float DetectRange = 5f;
    public bool IsActivated;
    protected override Node SetupTree()
    {
        Node Root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new DetectGuardInRange(transform, DetectRange),
                new SlowDownTraps(0.25f, 2f, this),
            })
        });
        return Root;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectRange);
    }
}
