using System.Collections.Generic;
using BehaviorTree;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    
    public int healthpoints = 35; 

    public bool TakeHit()
    {        
        healthpoints -= 10;
        bool isDead = healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
    }

    public void _Die()
    {
        Destroy(gameObject);
    }
}
