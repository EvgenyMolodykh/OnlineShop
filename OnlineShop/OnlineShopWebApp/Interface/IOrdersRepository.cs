using OnlineShopWebApp.Enums;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersRepository
    {
        void Add(OrderViewModel card); 
        List<OrderViewModel> GetAll();
        OrderViewModel TryGetById(Guid id);
		void UpdateStatus(Guid orderId, OrderStatus newstatus);
	}
}
