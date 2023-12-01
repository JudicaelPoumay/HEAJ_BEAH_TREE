using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System.Linq;

public class TrapAttack : Node
{
    public TrapBT trapBT;

    public float reduceSpeedPercent;
    public float reduceSpeedTime;

    public TrapAttack(float reduceSpeedPercent, float reduceSpeedTime, TrapBT trapBT) {
        this.reduceSpeedPercent = reduceSpeedPercent;
        this.reduceSpeedTime = reduceSpeedTime;
        this.trapBT = trapBT;
    }

    public override NodeState Evaluate() {
        if(trapBT.hasBeenActivated) return NodeState.FAILURE;

        Transform target = (Transform)GetData("TrapTarget");
        if(target == null) return NodeState.FAILURE;

        GuardBT2 guard = target.GetComponent<GuardBT2>();
        if(guard == null) return NodeState.FAILURE;

        guard.ReduceSpeed(reduceSpeedPercent, reduceSpeedTime);
        trapBT.ActivateTrap();


        return NodeState.SUCCESS;
    }
}
