using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkeletonDestroy : BehaviorTree.Node
{
    GameObject _skeleton;

    public SkeletonDestroy(GameObject skeleton)
    {
        _skeleton = skeleton;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_skeleton != null)
        {
            Debug.Log("Destroy");
            GameObject.Destroy(_skeleton);
        }
        return BehaviorTree.NodeState.SUCCESS;
    }
}
