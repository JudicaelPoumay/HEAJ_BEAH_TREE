using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmTrap : BehaviorTree.Node
{
    private TrapBT1 _tree;
    private GameObject _trap;
    private Color _color;
    public DisarmTrap(TrapBT1 tree, GameObject trap)
    {
        _tree = tree;
        _trap = trap;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        var trapRenderer = _trap.GetComponent<Renderer>();
        trapRenderer.material.SetColor("_color", Color.black);
        trapRenderer.material.color = _color;

        _tree.isArmed = false;
        return BehaviorTree.NodeState.SUCCESS;
    }
}
