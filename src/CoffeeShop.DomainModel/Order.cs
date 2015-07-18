using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CoffeeShop.DomainModel.Shared;

namespace CoffeeShop.DomainModel
{
    /// <summary>
    ///     This is the order aggregate root. Aggregate roots define a consistency boundary.
    /// </summary>
    [DataContract]
    public class Order
    {
        public Order(Guid id, List<OrderDetail> orderDetails)
        {
            Id = id;
            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatus.InProgress;
            SetOrderDetails(orderDetails);
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public List<OrderDetail> OrderDetails { get; private set; }

        [DataMember]
        public DateTime OrderDate { get; private set; }

        [DataMember]
        public OrderStatus OrderStatus { get; private set; }

        private void SetOrderDetails(List<OrderDetail> orderDetails)
        {
            AssertionConcern.AssertArgumentRange(orderDetails.Count, 1, 500, "Orders should have a minimum of one item.");
            OrderDetails = orderDetails;
        }

        public void CancelOrder(Guid id)
        {
            if (OrderStatus.SameValueAs(OrderStatus.InProgress) || OrderStatus.SameValueAs(OrderStatus.Canceled))
                OrderStatus = OrderStatus.Canceled;
            else
                throw new InvalidOperationException("This order is completed and can not be canceled.");
        }

        public void CompleteOrder(Guid id)
        {
            if (OrderStatus.SameValueAs(OrderStatus.InProgress) || OrderStatus.SameValueAs(OrderStatus.Completed))
                OrderStatus = OrderStatus.Completed;
            else
                throw new InvalidOperationException("This order has been canceled and can not be completed.");
        }
    }
}