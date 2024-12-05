using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownTraps : Node
{
    public TrapsBT _TrapBT;
    public float ReduceSpeedPercent;
    public float ReduceSpeedTime;

    public SlowDownTraps(float ReduceSpeedPercent, float ReduceSpeedTime, TrapsBT trapbt)
    {
        this.ReduceSpeedPercent = ReduceSpeedPercent;
        this.ReduceSpeedTime = ReduceSpeedTime;
        this._TrapBT = trapbt;
    }

    public override NodeState Evaluate()
    {
        if (_TrapBT.IsActivated) return NodeState.FAILURE;

        Transform target = (Transform)GetData("target");
        if (target == null) return NodeState.FAILURE;

        GuardBT3 guard = target.GetComponent<GuardBT3>();
        if (guard == null) return NodeState.FAILURE;

        guard.ReduceSpeed(ReduceSpeedPercent, ReduceSpeedTime);
        return NodeState.SUCCESS;
    }
}
