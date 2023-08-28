using Семинар_1.BaseProduct;
using Семинар_1.HotDrinks;
using Семинар_1.Products;

namespace Семинар_1.VendingMachines
{
    internal interface IVendingMachine
    {
        public Product GetProduct(string name, double volume, int temperature);
    }
}
