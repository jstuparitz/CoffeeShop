using System.Runtime.Serialization;

namespace CoffeeShop.DomainModel
{
    [DataContract]
    public class OrderDetail
    {
        public OrderDetail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        [DataMember]
        public Product Product { get; private set; }

        [DataMember]
        public int Quantity { get; private set; }
    }
}