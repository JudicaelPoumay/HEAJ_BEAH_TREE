using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int Health;
    
    void Start()
    {
        Health = 100; 
    }

   public bool takeHit(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
            return false;
        }
        return true;
    }
    
}
