using System;
using System.Runtime.Serialization;

namespace CoffeeShop.Commands.Order
{
    [DataContract]
    public class CancelOrderCommand : ICommand
    {
        [DataMember]
        public Guid OrderId { get; set; }
    }
}