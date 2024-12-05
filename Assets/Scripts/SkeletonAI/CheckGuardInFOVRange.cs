using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;
public class CheckGuardInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << LayerMask.NameToLayer("Guard");

    private Transform _transform;
    private float _FOVRange;

    public CheckGuardInFOVRange(Transform transform, float FOVRange)
    {
        _transform = transform;
        _FOVRange = FOVRange;
    }
    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, _FOVRange, _enemyLayerMask);

            if (colliders.Length > 0)
            {
                SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
