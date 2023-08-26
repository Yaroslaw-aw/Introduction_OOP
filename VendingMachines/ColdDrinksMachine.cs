using Семинар_1.Products;

namespace Семинар_1.VendingMachines
{
    internal class ColdDrinksMachine
    {
        protected List<Product> products;

        public ColdDrinksMachine()
        {
            if (products == null)
                products = new List<Product>();
        }

        public ColdDrinksMachine(List<Product> products)
        {
            if (products == null)
                this.products = new List<Product>();
            this.products = products;
        }

        public void AddProduct(Product product)
        { products.Add(product); }

        public BottleOfWater GetBottleOfWater(string name, double volume)
        {
            foreach (var product in products)
            {
                if (product is BottleOfWater)
                {
                    BottleOfWater bottleOfWater = (BottleOfWater)product;
                    if (product.Name.Equals(name) && bottleOfWater.Volume == volume)
                    {
                        return bottleOfWater;
                    }
                }
            }
            return null;
        }

        public BottleOfMilk GetBottleOfMilk(string name, double volume)
        {
            foreach (var product in products)
            {
                if (product is BottleOfMilk)
                {
                    BottleOfMilk bottleOfMilk = (BottleOfMilk)product;
                    if (product.Name.Equals(name) && bottleOfMilk.Volume == volume)
                    {
                        return bottleOfMilk;
                    }
                }
            }
            return null;
        }

        public void ShowAvailability()
        {
            int number = 0;
            foreach(var product in products)
            {
                if(products != null)
                    Console.WriteLine($"{++number}. {product.ProductInfo()}");
            }
        }

    }
}
