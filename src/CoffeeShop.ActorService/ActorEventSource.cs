using System;
using System.Diagnostics.Tracing;
using System.Fabric;
using Microsoft.ServiceFabric.Actors;

namespace CoffeeShop.ActorService
{
    [EventSource(Name = "MyCompany-CoffeeShop.ActorServiceApplication-CoffeeShop.ActorService")]
    internal sealed class ActorEventSource : EventSource
    {
        public static ActorEventSource Current = new ActorEventSource();

        [NonEvent]
        public void Message(string message, params object[] args)
        {
            if (IsEnabled())
            {
                var finalMessage = string.Format(message, args);
                Message(finalMessage);
            }
        }

        [Event(1, Level = EventLevel.Informational, Message = "{0}")]
        public void Message(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(1, message);
            }
        }

        [NonEvent]
        public void ActorMessage(Actor actor, string message, params object[] args)
        {
            if (IsEnabled())
            {
                var finalMessage = string.Format(message, args);
                ActorMessage(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.Host.ActivationContext.ApplicationTypeName,
                    actor.Host.ActivationContext.ApplicationName,
                    actor.Host.StatelessServiceInitializationParameters.ServiceTypeName,
                    actor.Host.StatelessServiceInitializationParameters.ServiceName.ToString(),
                    actor.Host.StatelessServiceInitializationParameters.PartitionId,
                    actor.Host.StatelessServiceInitializationParameters.InstanceId,
                    FabricRuntime.GetNodeContext().NodeName,
                    finalMessage);
            }
        }

        [NonEvent]
        public void ActorMessage<TState>(Actor<TState> actor, string message, params object[] args) where TState : class
        {
            if (IsEnabled())
            {
                var finalMessage = string.Format(message, args);
                ActorMessage(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.Host.ActivationContext.ApplicationTypeName,
                    actor.Host.ActivationContext.ApplicationName,
                    actor.Host.StatefulServiceInitializationParameters.ServiceTypeName,
                    actor.Host.StatefulServiceInitializationParameters.ServiceName.ToString(),
                    actor.Host.StatefulServiceInitializationParameters.PartitionId,
                    actor.Host.StatefulServiceInitializationParameters.ReplicaId,
                    FabricRuntime.GetNodeContext().NodeName,
                    finalMessage);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "{9}")]
        private void ActorMessage(
            string actorType,
            string actorId,
            string applicationTypeName,
            string applicationName,
            string serviceTypeName,
            string serviceName,
            Guid partitionId,
            long replicaOrInstanceId,
            string nodeName,
            string message)
        {
            WriteEvent(
                2,
                actorType,
                actorId,
                applicationTypeName,
                applicationName,
                serviceTypeName,
                serviceName,
                partitionId,
                replicaOrInstanceId,
                nodeName,
                message);
        }

        [NonEvent]
        public void ActorHostInitializationFailed(Exception e)
        {
            if (IsEnabled())
            {
                ActorHostInitializationFailed(e.ToString());
            }
        }

        [Event(3, Level = EventLevel.Error, Message = "Actor host initialization failed")]
        private void ActorHostInitializationFailed(string exception)
        {
            WriteEvent(3, exception);
        }
    }
}