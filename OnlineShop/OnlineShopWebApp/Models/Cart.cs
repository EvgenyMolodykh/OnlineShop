namespace OnlineShopWebApp.Models
{
	public class Cart
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }

		public List<CartItem> Items { get; set; }

		public decimal CostCart
		{
			get
			{
				return Items?.Sum(x => x.Cost)??0;
			}
		}

        public int AmountCart
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}

