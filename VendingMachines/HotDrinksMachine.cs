using Семинар_1.HotDrinks;
using Семинар_1.Products;

namespace Семинар_1.VendingMachines
{
    internal class HotDrinksMachine : ColdDrinksMachine, IVendingMachine
    {
        public Coffee GetProduct(string name, double volume, int temperature)
        {
            foreach (var product in products)
            {
                if (product is HotDrink)
                {
                    Coffee coffee = (Coffee)product;
                    if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && coffee.Volume == volume)
                    {
                        return coffee;
                    }
                }
            }
            return null;
        }
    }
}
