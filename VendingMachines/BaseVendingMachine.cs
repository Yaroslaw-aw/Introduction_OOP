using Семинар_1.BaseProduct;

namespace Семинар_1.VendingMachines
{
    internal abstract class BaseVendingMachine
    {
        protected List<Product> products;
        protected int size;
        public int Size { get { return size; } }

        public BaseVendingMachine()
        {
            if (products == null)
                products = new List<Product>();
            this.size = 0;
        }

        public BaseVendingMachine(List<Product> products)
        {
            if (products == null)
            {
                this.products = new List<Product>();
                this.size = 0;
            }
            this.products = products;
            this.size = products.Count;
        }

        public void AddProduct(Product product)
        { 
            products.Add(product);
            this.size++;
        }

        public virtual Product GetProductByIndex(int index)
        {
            if (index < 0 || index > products.Count)
                throw new ArgumentOutOfRangeException("index");
            return products[index - 1];
        }

        public virtual Product GetProduct(string name, double price)
        {
            foreach (var product in products)
            {
                if (product is Product)
                {
                    if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && product.Price == price)
                    {
                        return product;
                    }
                }
            }
            return null;
        }

        public void ShowAvailability()
        {
            int number = 0;
            foreach (var product in products)
            {
                if (products != null)
                    Console.WriteLine($"{++number}. {product.ProductInfo()}");
            }
        }        
    }
}
