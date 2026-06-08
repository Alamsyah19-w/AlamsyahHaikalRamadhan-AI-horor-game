using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Despwan AI", story: "Despawn [AI]", category: "Action", id: "5664b1fae72256689bf78f0126f4cb04")]
public partial class DespwanAIAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI == null)
        {
            return Status.Failure;
        }
        AI.Value.Despawn();
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

