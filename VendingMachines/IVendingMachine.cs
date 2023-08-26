using Семинар_1.HotDrinks;

namespace Семинар_1.VendingMachines
{
    internal interface IVendingMachine
    {
        public Coffee GetProduct(string name, double volume, int temperature);
    }
}
