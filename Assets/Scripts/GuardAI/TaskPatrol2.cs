using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;

public class TaskPatrol2 : Node
{
    private Transform _transform;
    private Animator _animator;
    private Transform[] _waypoints;
    private float _speed;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;

    private NavMeshAgent _agent;

    public TaskPatrol2(Transform transform, Transform[] waypoints, float speed, NavMeshAgent agent)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _waypoints = waypoints;
        _speed = speed;
        _agent = agent;
        _animator.SetBool("Walking", true);
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                _animator.SetBool("Attacking", false);
                _animator.SetBool("Walking", true);
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 1f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;
                
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;

                _animator.SetBool("Attacking", false);
                _animator.SetBool("Walking", false);
            }
            else
            {
                _agent.SetDestination(wp.position);
                _animator.SetBool("Attacking", false);
                _animator.SetBool("Walking", true);

            }
        }


        state = NodeState.RUNNING;
        return state;
    }
	public override void Reset()
	{
        _currentWaypointIndex = 0;
	}

}