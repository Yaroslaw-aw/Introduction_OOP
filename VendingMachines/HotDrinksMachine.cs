using Семинар_1.BaseProduct;
using Семинар_1.HotDrinks;

namespace Семинар_1.VendingMachines
{
    internal class HotDrinksMachine : ColdDrinksMachine, IVendingMachine
    {
        public HotDrinksMachine()
            : base() { }

        public HotDrinksMachine(List<Product> products)
        : base(products) { }

        public HotDrink GetProductByIndex(int index)
        {
            if (index < 0 || index > products.Count)
                throw new ArgumentOutOfRangeException("index");
            return (HotDrink)products[index - 1];
        }

        public Product GetProduct(string name, double volume, int temperature)
        {
            foreach (var product in products)
            {
                if (product is HotDrink)
                {
                    HotDrink hotProduct = (HotDrink)product;
                    if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && hotProduct.Volume == volume && hotProduct.Temperature == temperature)
                    {
                        return hotProduct;
                    }
                }
            }
            return null;
        }


    }
}

