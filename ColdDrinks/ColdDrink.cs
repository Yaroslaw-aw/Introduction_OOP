using Семинар_1.BaseProduct;

namespace Семинар_1.Products
{
    internal class ColdDrink : Product
    {
        protected double volume;
        public double Volume { get { return volume; } set {volume = value; } }

        public ColdDrink(string name, string brand, double price)
            : base(name, brand, price) { }
    }
}
