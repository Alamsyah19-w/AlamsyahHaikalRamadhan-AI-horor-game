using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Validate NavMesh", story: "Validate NavmeshAgent from [Ai]", category: "Action", id: "0156ac2e0c5a2da93138d784ed7e44ac")]
public partial class ValidateNavMeshAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> Ai;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Ai.Value == null)
        {
            return Status.Failure;

        }
        if (Ai.Value.NavMeshAgent == null)
        {
            return Status.Failure;
        }
        if (Ai.Value.NavMeshAgent.isActiveAndEnabled==false)
        {
            return Status.Failure;
        }

        if (Ai.Value.NavMeshAgent.isOnNavMesh == false)
        {
            return Status.Failure;
        }


        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

