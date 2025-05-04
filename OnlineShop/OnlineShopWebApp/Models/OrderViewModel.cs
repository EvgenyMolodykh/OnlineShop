using OnlineShopWebApp.Enums;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        private static int _orderId = 0;

        public int CurrentNumberOrder { get; set; }

        public UserDelivetyInfo User { get; set; }

        public List<CartItem> Items { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime {  get; set; }   
                
        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
            CurrentNumberOrder = ++_orderId;
        }

        public decimal CostOrders
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }


    }

 
}
