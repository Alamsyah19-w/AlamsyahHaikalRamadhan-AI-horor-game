using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Wait Until Reach Destination", story: "[AI] wait Until Reach destination", category: "Action", id: "ce92258b419d95676b025021983cff92")]
public partial class WaitUntilReachDestinationAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI.Value==null)
        {
            return Status.Failure;
        }
        NavMeshAgent agent = AI.Value.NavMeshAgent;
        if (agent == null)
        {
            return Status.Failure;
        }
        if (agent.pathPending)
        {
            return Status.Running;
        }
        if (agent.remainingDistance > agent.stoppingDistance +0.5f)
        {
            return Status.Running;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

