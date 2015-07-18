using System;
using System.Fabric;
using System.Threading;
using Microsoft.ServiceFabric.Actors;

namespace CoffeeShop.ActorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (var fabricRuntime = FabricRuntime.Create())
                {
                    fabricRuntime.RegisterActor(typeof (OrderActor));

                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e);
                throw;
            }
        }
    }
}