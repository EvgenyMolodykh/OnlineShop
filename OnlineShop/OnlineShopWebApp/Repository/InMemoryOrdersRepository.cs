using OnlineShopWebApp.Enums;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repository
{
    public class InMemoryOrdersRepository : IOrdersRepository

    {
        private List<OrderViewModel> orders = new List<OrderViewModel>();

        public void Add(OrderViewModel order)
        {
            orders.Add(order);
        }

        public List<OrderViewModel> GetAll()
        {
            return orders;
        }

        public OrderViewModel TryGetById(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

		public void UpdateStatus(Guid orderId, OrderStatus newstatus)
		{
            var order = TryGetById(orderId);
            if (order != null) 
            {
                order.Status = newstatus;
            }
		}
	}
}

