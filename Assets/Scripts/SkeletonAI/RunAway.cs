using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class RunAway : Node
{
    private Transform _transform;
    private float _speed;

    public RunAway(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) < 10f)
        {
            Vector3 awayDirection = _transform.position - target.position;
            Quaternion awayRotation = Quaternion.LookRotation(awayDirection);
            _transform.rotation = awayRotation;

            if(!EnemyManager.frozen)
            {
                Debug.Log("Moving");
                _transform.position = Vector3.MoveTowards(_transform.position, target.position, -1* _speed * Time.deltaTime);
            }
            
        }

        state = NodeState.RUNNING;
        return state;
    }

}
