using System.Collections.Generic;
using BehaviorTree;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    
    public static int healthpoints = 60; 

    public bool TakeHit()
    {        
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
