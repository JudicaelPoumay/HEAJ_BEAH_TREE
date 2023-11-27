using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TaskAttack : BehaviorTree.Node
{
    private Animator _animator;
    private TakeDamage _takeDamage;
    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;
    private Transform _target;
    private int _Damage = 10;

    public TaskAttack(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
       
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                
            }
        }
        else
        {
            _target = (Transform)GetData("Target");
            if (_target == null )
            {
                ClearData("Target");
                _animator.SetBool("Attacking", false);
                return BehaviorTree.NodeState.FAILURE;
            }
            _takeDamage = _target.transform.GetComponent<TakeDamage>();
            if (_takeDamage.takeHit(_Damage))
            {
                _animator.SetBool("Attacking", true);
                _waiting = true;
                _waitCounter = 0f;
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
