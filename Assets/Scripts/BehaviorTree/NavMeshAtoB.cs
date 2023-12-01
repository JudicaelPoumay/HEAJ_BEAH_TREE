using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class NavMeshAtoB : Node
{
    private NavMeshAgent agent;
    private Transform waypoint;
	private float speed;

    private float stopDistance;

    private GuardBT2 tree;

    private string debug;

    public NavMeshAtoB(NavMeshAgent agent, Transform waypoint, float speed, float stopDistance = 0.1f, string debugMessage = "") {
        this.agent = agent;
        this.waypoint = waypoint;
        this.speed = speed;

        debug = debugMessage;
        this.stopDistance = stopDistance;
    }

    public NavMeshAtoB(NavMeshAgent agent, GuardBT2 tree, float speed, float stopDistance = 0.1f, string debugMessage = "") {
        this.agent = agent;
        this.tree = tree;
        this.speed = speed;

        debug = debugMessage;
        this.stopDistance = stopDistance;
    }

    public NavMeshAtoB(NavMeshAgent agent, string dataName, float speed, float stopDistance = 0.1f, string debugMessage = "") {
        this.agent = agent;
        waypoint = (Transform)GetData(dataName);
        this.speed = speed;

        tree = null;

        debug = debugMessage;
        this.stopDistance = stopDistance;
    }

    public override BehaviorTree.NodeState Evaluate()
	{
        if(debug != "") Debug.Log(debug);

        if(agent == null) return NodeState.FAILURE;
        if(waypoint == null){
            waypoint = tree?.selectedCrate;
            if(waypoint == null)
                return NodeState.FAILURE;
        }

		if(Vector3.Distance(agent.transform.position, waypoint.position) < stopDistance)
			return BehaviorTree.NodeState.SUCCESS;
        else
        {
            agent.speed = speed;
            agent.SetDestination(waypoint.position);
        }
        return BehaviorTree.NodeState.RUNNING;
    }
}
