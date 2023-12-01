using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = BehaviorTree.Tree;
using System.Linq;

public class TrapBT : Tree {
    public float checkRange;

    public bool hasBeenActivated;

    public Transform target => FindObjectOfType<GuardBT2>().GetComponent<Transform>();

    protected override Node SetupTree() {
        Node root = new Selector(new List<Node>
		{
            new Sequence(new List<Node>
            {
               new CheckRange(transform, target, checkRange, returnDataName:"TrapTarget"),
			   new TrapAttack(0.25f, 2f, this),
            }),
            
         });

		return root; 
    }

    public void ActivateTrap() {
        hasBeenActivated = true;
        GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.black);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, checkRange);
    }
}
