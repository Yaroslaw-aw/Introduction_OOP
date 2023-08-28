using Семинар_1.BaseProduct;
using Семинар_1.Products;

namespace Семинар_1.VendingMachines
{
    internal class ColdDrinksMachine : BaseVendingMachine
    {
        public ColdDrinksMachine()
            : base() { }

        public ColdDrinksMachine(List<Product> products)
        : base(products) { }

        public ColdDrink GetProductByIndex(int index)
        {
            if (index < 0 || index > products.Count)
                throw new ArgumentOutOfRangeException("index");
            return (ColdDrink)products[index - 1];
        }

        public override Product GetProduct(string name, double volume)
        {
            foreach (var product in products)
            {
                if (product is ColdDrink)
                {
                    ColdDrink coldDrink = (ColdDrink)product;
                    if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && coldDrink.Volume == volume)
                    {
                        return coldDrink;
                    }
                }
            }
            return null;
        }      
    }
}
