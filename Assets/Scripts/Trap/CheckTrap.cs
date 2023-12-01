using BehaviorTree;
using UnityEngine;
public class CheckTrap : Node
{
    public SkelBT2 bt;

    public CheckTrap(SkelBT2 bt) { 
        this.bt = bt;
    }

    public override NodeState Evaluate(){
        if(bt.trapDropped < bt.trapCount){
            return NodeState.SUCCESS;
        } else {
            return NodeState.FAILURE;
        }
    }
}
