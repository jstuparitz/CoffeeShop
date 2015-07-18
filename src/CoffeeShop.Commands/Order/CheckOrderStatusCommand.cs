using System;
using System.Runtime.Serialization;

namespace CoffeeShop.Commands.Order
{
    [DataContract]
    public class CheckOrderStatusCommand : ICommand
    {
        [DataMember]
        public Guid OrderId { get; set; }
    }
}