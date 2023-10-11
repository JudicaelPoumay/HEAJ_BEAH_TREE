using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private float _speed;

    public TaskGoToTarget(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, target.position, _speed * Time.deltaTime);
            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
