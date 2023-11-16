using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class TaskAttack : BehaviorTree.Node
{
    private Animator _animator;
    private TaskDamage takeDamage;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;
    private Transform _target;
    private int damage = 10;

    NavMeshAgent agentToDealDamage;

    public TaskAttack(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
       
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
            _target = (Transform)GetData("Target");
            if(_target == null ){
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            takeDamage = _target.transform.GetComponent<TaskDamage>();
            if (takeDamage.TakeHit(damage, _target))
            {
                Debug.Log("Attack");
                _animator.SetBool("Attacking", true);
                waiting = true;
                waitCounter = 0f;
            }
            else
            {
                _animator.SetBool("Attacking", false);
                ClearData("Target");
            }
        }
        return BehaviorTree.NodeState.SUCCESS;
        
       
    }
}