using System;

namespace CoffeeShop.Commands.Order
{
    public class CompleteOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
    }
}