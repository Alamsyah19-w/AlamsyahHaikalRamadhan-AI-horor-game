using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Can See Target", story: "set [canSeeTarget] form [AI]", category: "Action", id: "6b90f98bda6665577e6fb56a203bd708")]
public partial class SetCanSeeTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> CanSeeTarget;
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI == null && AI.Value.SightPerception == null)
        {
            return Status.Failure;
        }
        CanSeeTarget.Value = AI.Value.SightPerception.CanSeePlayer;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

