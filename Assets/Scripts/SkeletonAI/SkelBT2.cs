using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;
using UnityEngine.AI;
using JetBrains.Annotations;

public class SkelBT2 : Tree
{
    public Transform waypoint;
    public NavMeshAgent agent;
    public GameObject trapObj;
    public float speed;

    public int trapCount = 2; 
    public int trapDropped;

    public float attackRadius;
    public float guardDetectionRadius;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
		{
            new Selector(new List<Node> {
                new Sequence(new List<Node> {
                    new CheckSkelRange(transform, guardDetectionRadius),      
                    new Selector(new List<Node> {                             
                        new Sequence(new List<Node> {
                            new CheckTrap(this),            
                            new TaskAvoid(agent, 7f),                         
                            new DropObject(this, trapObj, 2f, trapCount),     
                        }),
                        new Sequence(new List<Node> {
                            new NavMeshAtoB(agent, "TargetGuard", speed),           
                            new CheckRange(transform, targetDataName:"TargetGuard", attackRadius, returnDataName:"TargetGuard"),
                            new TaskAttack("TargetGuard", 2),                       
                        })
                    }),
                }),
                new Sequence(new List<Node>{                
			        new NavMeshAtoB(agent, waypoint, speed),
                    new DestroyNode(this.gameObject),
                }),
            }),
        });

		return root;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, guardDetectionRadius);
    }
}
