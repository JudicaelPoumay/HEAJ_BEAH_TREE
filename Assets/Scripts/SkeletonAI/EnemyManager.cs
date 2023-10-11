using System.Collections.Generic;
using BehaviorTree;
using System;
using System.Threading.Tasks;

public class EnemyManager : Tree
{    
    public UnityEngine.Transform[] waypoints;
    
    public static int healthpoints = 60; 
    public static float speed = 1f;
    public static bool frozen = false;
    public static float fovRange = 3f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckGuardInFOVRange(transform, fovRange),
                new RunAway(transform,speed),
            }),
            new TaskPatrol1(transform, waypoints, speed),
        });

        return root;
    }

    public bool TakeHit()
    {        
        frozen = true;
        Task.Run(async () => {
            await Task.Delay(300);
            frozen = false;
        });

        healthpoints -= 10;
        bool isDead = healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
    }

    private void _Die()
    {
        Destroy(gameObject);
    }
}
