using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class OnActivation : BehaviorTree.Node
{
    private TrapBT1 _tree;

    private GameObject _trap;

    private Transform _target;

    private NavMeshAgent _agent;

    private GuardBT1 _isSlowed;

    private Color _color;
    public OnActivation(TrapBT1 tree, GameObject trap, NavMeshAgent agent)
    {
        _tree = tree;
        _trap = trap;
        _agent = agent;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_tree.isArmed)
        {
            Debug.Log("Activated");

            _target = (Transform)GetData("Target");

            var _trapRenderer = _trap.GetComponent<Renderer>();
            _trapRenderer.material.SetColor("_color", Color.black);
            _trapRenderer.material.color = _color;

            _isSlowed = _target.transform.GetComponent<GuardBT1>();
            _isSlowed.slowSpeed();

            _tree.isArmed = false;
            Debug.Log("Disarmed");
            return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
}
