using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Target Is Hiding", story: "set [TargetIsHiding] from [AI]", category: "Action", id: "61e142325a7d0b0d844d25267d3acca2")]
public partial class SetTargetIsHidingAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> TargetIsHiding;
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI == null && AI.Value.Player == null)
        {
            return Status.Failure;
        }
        TargetIsHiding.Value = AI.Value.Player.IsHiding;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

