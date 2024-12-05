using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class DropTraps : Node
{
    private GameObject _TrapsPrefabs;
    private float Cooldown = 2f;
    private Transform _transform;
    private float MaxTraps = 2;

    public DropTraps(GameObject TrapsPrefabs, Transform transform)
    {
        _TrapsPrefabs = TrapsPrefabs;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Cooldown -= 1 * Time.deltaTime;
        if(Cooldown <= 0 && MaxTraps != 0)
        {
            GameObject.Instantiate(_TrapsPrefabs, _transform.position, Quaternion.identity);
            Cooldown = 2f;
            MaxTraps -= 1f;
            return NodeState.SUCCESS;
        }


        state = NodeState.RUNNING;
        return state;
    }


}
