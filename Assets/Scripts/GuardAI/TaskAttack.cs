using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class TaskAttack : BehaviorTree.Node
{
    private Animator animator;
    private TaskDamage takeDamage;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;
    private Transform target;
    private int damage = 10;

    private string whoToAttack = "Target";

    NavMeshAgent agentToDealDamage;

    public TaskAttack(Transform transform)
    {
        transform.TryGetComponent<Animator>(out animator);
    }

    public TaskAttack(string whoToAttack, int damage){
        this.whoToAttack = whoToAttack;
        this.damage = damage;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;
                
            }
        }
        else
        {
            target = (Transform)GetData(whoToAttack);
            if(target == null ){
                return BehaviorTree.NodeState.FAILURE;
            }
            takeDamage = target.transform.GetComponent<TaskDamage>();
            if (takeDamage.TakeHit(damage, target))
            {
                Debug.Log("Attack");
                animator?.SetBool("Attacking", true);
                waiting = true;
                waitCounter = 0f;
            }
            else
            {
                animator?.SetBool("Attacking", false);
                ClearData(whoToAttack);
            }
        }
        return BehaviorTree.NodeState.SUCCESS;
        
       
    }
}