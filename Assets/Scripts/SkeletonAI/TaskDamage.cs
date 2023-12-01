using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class TaskDamage : MonoBehaviour
{
    public TextMeshPro lifeText;

    public float health = 30;
    public bool oneTimeBool = false;
    public bool TakeHit(float damage, Transform transform)
    {
        if(health > 0)
        {
            health = health - damage;
            //Debug.Log("Enemy life : " + _health);
            //StartCoroutine(FreezeOnHit());
            return true;
        }
        
        if(health <= 0 && !oneTimeBool)
        {
            oneTimeBool = true;

            NavMeshAgent agent = transform.GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            Destroy(agent);
            transform.eulerAngles = new Vector3(90f, 0, 0);
            transform.GetComponent<BoxCollider>().enabled = false;

            Debug.Log("Skel is dead");

            Invoke("DestroyAfterTime", 5f);
            return false;
        }

        return false; 
    }

    private void Update() {
        lifeText.text = health.ToString();
    }

    private void DestroyAfterTime() {
        Destroy(gameObject);
    }

    public IEnumerator FreezeOnHit() {
        NavMeshAgent agent = transform.GetComponent<NavMeshAgent>();
        Vector3 backupDest = agent.destination;

        agent.isStopped = true;

        Debug.Log("Enemy Freezed");

        yield return new WaitForSeconds(1f);

        agent.isStopped = false;
        agent.SetDestination(backupDest);

    }
}
