using System;
using System.Collections.Generic;
using System.Threading;
using CoffeeShop.ActorService.Interfaces;
using CoffeeShop.Commands.Order;
using Microsoft.ServiceFabric.Actors;

namespace CoffeeShop.ActorService.Client
{
    public class Program
    {
        private const string ApplicationName = "fabric:/CoffeeShop.ActorServiceApplication";

        public static void Main(string[] args)
        {
            Thread.Sleep(20000);

            //gives you the ability to connect to the actor
            var orderId = Guid.NewGuid();
            var proxyOrder = ActorProxy.Create<IOrderActor>(new ActorId(orderId), ApplicationName);

            proxyOrder.CreateOrder(CreateOrderCommand(orderId));
        }

        private static CreateOrderCommand CreateOrderCommand(Guid orderId)
        {
            var product = new Product {Id = Guid.NewGuid(), Name = "some product name", Price = (decimal) 5.54};
            var details = new List<OrderDetail>();
            details.Add(new OrderDetail(product, 3));
            details.Add(new OrderDetail(product, 5));
            details.Add(new OrderDetail(product, 8));
            var command = new CreateOrderCommand(orderId, details);
            return command;
        }
    }
}