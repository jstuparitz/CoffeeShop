using CoffeeShop.DomainModel.Shared;

namespace CoffeeShop.DomainModel
{
    public class OrderStatus : Enumeration, IValueObject<OrderStatus>
    {
        public static readonly OrderStatus InProgress = new OrderStatus("InProgress", "InProgress");
        public static readonly OrderStatus Canceled = new OrderStatus("Canceled", "Canceled");
        public static readonly OrderStatus Completed = new OrderStatus("Completed", "Completed");

        private OrderStatus(string value, string displayName) : base(value, displayName)
        {
        }

        public bool SameValueAs(OrderStatus other)
        {
            return other != null && Equals(other);
        }
    }
}