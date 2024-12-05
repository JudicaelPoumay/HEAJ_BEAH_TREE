using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = BehaviorTree.Tree;
using System.Linq;

public class TrapBT : Tree
{
    public float checkRange;

    public bool hasBeenActivated;

    public Transform target => FindObjectOfType<GuardBT3>().GetComponent<Transform>();

    protected override Node SetupTree()
    {
        Node root = new Sequence(new List<Node>
        {
           new CheckEnemyInFOVRange(transform, checkRange,"Guard"),
           new TrapAttack(0.1f, 0.8f, this),
        });

        return root;
    }

    public void ActivateTrap()
    {
        hasBeenActivated = true;
        GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.black);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRange);
    }
}
