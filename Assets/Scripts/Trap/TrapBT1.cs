using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class TrapBT1 : Tree
{
    public bool isArmed = true;
    public UnityEngine.GameObject cube;
    public NavMeshAgent agent;
    public float fovRange = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new IsArmed(this),
                new IsGuardClose(transform, fovRange),
                new OnActivation(this, cube, agent)
            }),
            new Sequence(new List<Node>
            {
                new TrapLifeTime(this),
                new DisarmTrap(this, cube)
            }),
        });
        return root;
    }
}
