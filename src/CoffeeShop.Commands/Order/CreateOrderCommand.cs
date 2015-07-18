using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoffeeShop.Commands.Order
{
    [DataContract]
    public class CreateOrderCommand : ICommand
    {
        public CreateOrderCommand(Guid orderId, List<OrderDetail> orderDetails)
        {
            OrderId = orderId;
            OrderDetails = orderDetails;
        }

        [DataMember]
        public Guid OrderId { get; set; }

        [DataMember]
        public List<OrderDetail> OrderDetails { get; set; }
    }

    [DataContract]
    public class OrderDetail
    {
        public OrderDetail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}