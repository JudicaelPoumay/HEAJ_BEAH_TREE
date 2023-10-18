using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPatrol2 : BehaviorTree.Node
{
	private Transform _transform;
	private Animator _animator;
	private Transform[] _waypoints;
	private float _speed;

	private int _currentWayPointIdx = 0;

	private float _waitTime = 1f;
	private float _waitCounter = 0f;
	private bool _waiting = false;

	public TaskPatrol2(Transform transform, Transform[] waypoints, float speed)
	{
		_transform = transform;
		_animator = transform.GetComponent<Animator>();
		_waypoints = waypoints;
		_speed = speed;
	}

	public override BehaviorTree.NodeState Evaluate()
	{
		if(_currentWayPointIdx == _waypoints.Length)
			return BehaviorTree.NodeState.SUCCESS;
		if(_waiting)
		{
			_waitCounter += Time.deltaTime;
			if(_waitCounter >= _waitTime)
			{
				_waiting = false;
				_animator.SetBool("Walking",true);
			}
		}
		else
		{
			Transform wp = _waypoints[_currentWayPointIdx];
			if(Vector3.Distance(_transform.position, wp.position) < 0.01f)
			{
				_transform.position = wp.position;
				_waitCounter = 0f;
				_waiting = true;
				_currentWayPointIdx = _currentWayPointIdx+1;

				_animator.SetBool("Walking",false);
			}
			else
			{
				_transform.position = Vector3.MoveTowards(_transform.position, wp.position, _speed*Time.deltaTime);
				_transform.LookAt(wp.position);
			}
		}

		

		return BehaviorTree.NodeState.RUNNING;
	}

	public override void Reset()
	{
		_currentWayPointIdx = 0;
	}
}
