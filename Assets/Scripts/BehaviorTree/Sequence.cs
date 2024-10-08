using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
	public class Sequence : Node
	{
        public Sequence() : base() {}
        public Sequence(List<Node> children) : base(children) {}

		public override NodeState Evaluate()
		{
			foreach(Node child in children)
			{
				switch(child.Evaluate())
				{
                    case NodeState.FAILURE:
						return NodeState.FAILURE;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
						return NodeState.RUNNING;
                    default:
                        continue;
				}
			}

			_Reset();
			return NodeState.SUCCESS;
		}

		public void _Reset()
		{
			foreach(Node child in children)
				child.Reset();
		}
	}
}