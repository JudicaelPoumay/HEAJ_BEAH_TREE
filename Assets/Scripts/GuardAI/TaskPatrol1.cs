using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPatrol1 : BehaviorTree.Node
{
	private Transform _transform;
	private Transform[] _waypoints;
	private float _speed;

	private int _currentWayPointIdx = 0;

	public TaskPatrol1(Transform transform, Transform[] waypoints, float speed)
	{
		_transform = transform;
		_waypoints = waypoints;
		_speed = speed;
	}

	public override BehaviorTree.NodeState Evaluate()
	{
		if(_currentWayPointIdx == _waypoints.Length)
			return BehaviorTree.NodeState.SUCCESS;
		Transform wp = _waypoints[_currentWayPointIdx];
		if(Vector3.Distance(_transform.position, wp.position) < 0.01f)
		{
			_transform.position = wp.position;
			_currentWayPointIdx = (_currentWayPointIdx+1) % _waypoints.Length;
		}
		else
		{
			_transform.position = Vector3.MoveTowards(_transform.position, wp.position, _speed*Time.deltaTime);
		}

		return BehaviorTree.NodeState.RUNNING;
	}

	public override void Reset()
	{
		_currentWayPointIdx = 0;
	}
}
