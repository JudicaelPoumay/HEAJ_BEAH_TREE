using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class GuardBT1 : Tree
{
	public UnityEngine.Transform[] waypoints1;
	public UnityEngine.Transform[] waypoints2;
	public float speed = 6f;

	protected override Node SetupTree()
	{
		//Node root = new 

		Node root = new Sequence(new List<Node>
		{
			new TaskPatrol2(transform, waypoints1, speed),
			new TaskPatrol2(transform, waypoints2, speed*2)
		});

		return root;
	}
}
