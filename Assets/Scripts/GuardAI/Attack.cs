using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BehaviorTree.Selector
{
    public Attack(Transform transform, SkelBT2 skel,  GuardBT2 mainTree, float attackRadius, float fovRange, float speed, NavMeshAgent agent) : base() 
    {
		children.Add(new Sequence(new List<Node> {
			new CheckBool(mainTree, "hasCrate", false, ""),
			new CheckRange(transform, skel.transform, attackRadius, returnDataName:"SkelInRange"),
			new WaitNode(new TaskAttack("SkelInRange", 15), 3f)			
		}));
        
		children.Add(new Sequence(new List<Node> {
			new CheckBool(mainTree, "hasCrate", false, ""),
			new CheckRange(transform, skel.transform, fovRange, "Target"),
			new NavMeshAtoB(agent, skel.transform, speed),
		}));
    }
}
