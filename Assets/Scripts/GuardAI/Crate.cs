using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : BehaviorTree.Sequence
{
	public Crate()
	{
		children.Add(new CheckBool(this, "hasCrate", false, ""));
		children.Add(new Selector(new List<Node> {
				new CheckBool(this, "hasSelectedCrate", true, ""),
				new SelectRandomObject(allCrates.ToList(), this),
		}));
		children.Add(new NavMeshAtoB(agent, this, speed, cratePickupRange, ""));
		children.Add(new PickupObject(this));
		children.Add(new DebugNode("Crate picked up"));
	}
}
