using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class FleeGuard : Node
{
    private Transform _transform;
    private float _speed;
    private Vector3 newdestination;
    private NavMeshAgent _agent;

    public FleeGuard(Transform transform, float speed, NavMeshAgent agent)
    {
        _transform = transform;
        _speed = speed;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if(target == null)
        {
            Debug.Log("failure");
            return NodeState.FAILURE;
        }
        
        if (Vector3.Distance(_transform.position, target.position) > 10f)
        {
            newdestination = (_transform.position - target.position).normalized * 15;
            _agent.SetDestination( _transform.position - newdestination);
        }
        

        state = NodeState.SUCCESS;
        return state;
    }
}
