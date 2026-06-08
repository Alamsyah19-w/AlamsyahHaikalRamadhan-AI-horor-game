using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set lastSeenPlayer", story: "Set [lastSeenPlayer] from [AI]", category: "Action", id: "f5304bcf64ad1193b94b0c861a169b6d")]
public partial class SetLastSeenPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> LastSeenPlayer;
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
        LastSeenPlayer.Value = AI.Value.SightPerception.LastSeenPosition;
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

