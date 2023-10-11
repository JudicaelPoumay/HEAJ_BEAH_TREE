using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskPatrol1 : Node
{
    private Transform _transform;
    private Transform[] _waypoints;
    private float _speed;

    private int _currentWaypointIndex = 0;

    public TaskPatrol1(Transform transform, Transform[] waypoints, float speed)
    {
        _transform = transform;
        _waypoints = waypoints;
        _speed = speed;
    }

    public override NodeState Evaluate()
    {
        Transform wp = _waypoints[_currentWaypointIndex];
        if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
        {
            _transform.position = wp.position;
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position, wp.position, _speed * Time.deltaTime);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
