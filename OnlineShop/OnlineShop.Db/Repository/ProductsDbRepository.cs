using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Db.Interface;


namespace OnlineShopWebApp.Db
{
    public class ProductsDbRepository : IProductsRepository
	{

        private readonly DataBaseContext dataBaseContext;

        public ProductsDbRepository(DataBaseContext dataBaseContext) 
        {
            this.dataBaseContext = dataBaseContext;
        }

        //private static List<Product> products = new List<Product>()
        //{
        //    new Product("Anti Aging Glycolic Toner",4600,"Тоник с 7% гликолевой кислотой предотвращающий старение кожи","/images/Products/1.jpg"),
        //    new Product("Youth Transformation Exfoliating Scrub",5850,"Отшелушивающий крем-скраб с омолаживающим эффектом","/images/Products/2.jpg"),
        //    new Product("Oil Free Aromatherapy Massage Serum",7120,"Массажная  сыворотка","/images/Products/3.jpg"),
        //    new Product("Jenasus growth Factor Peel",10120,"Кислотный пилинг - бустер pH 2.5","/images/Products/4.jpg"),
        //    new Product("JESSNER`S PEEL",7260,"Лосьон-пилинг \"JESSNER`S PEEL\" pH 3.0","/images/Products/5.jpg"),
        //    new Product("Multi - C / Retinol Peel",7260,"Кислотный пилинг -бустер pH 3.0","/images/Products/6.jpg"),
        //    new Product("Dual Action Pumpkin Enzyme Mask",6650,"Омолаживающая маска с энзимами тыквы pH 2.25","/images/Products/7.jpg"),
        //    new Product("Набор:\r\nJenasus growth factor mask + Multi Plant Stem Booster Serum",9340,"Маска для интенсивного омоложения " +
        //        "и регенерации кожи + Сыворотка-бустер с меристемальными растительными клетками pH 7.5","/images/Products/8.jpg"),
        //    new Product("Four Fruit Enzyme Exfoliating Mask",6490,"Энзимная мультифруктовая маска \"Super Polish\"  pH 3.0","/images/Products/9.jpg"),
        //    new Product("Набор:\r\nYouth Transf Glycolic Mask+ Multi Plant Stem Booster Serum",6010,"Омолаживающая маска с " +
        //        "гликолиевой кислотой + Сыворотка-бустер pH 3.4","/images/Products/10.jpg"),
        //};

        public List<Product> GetAll()
        {
            return dataBaseContext.Products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);

        }

        public void Add(Product product)
        {
            product.ImagePath = "/images/Products/1.jpg";
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(product => product.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            dataBaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var productToRemove = dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
            if (productToRemove != null)
            {
                dataBaseContext.Products.Remove(productToRemove);
            }
        }

    }

}
