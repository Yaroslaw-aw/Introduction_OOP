using Семинар_1.BaseProduct;

namespace Семинар_1.HotDrinks
{
    internal abstract class HotDrink : Product
    {
        readonly int temperature;
        readonly double volume;
        public double Volume { get { return volume; } }

        public int Temperature { get { return temperature; } }

        public HotDrink(string name, string brand, double price, double volume, int temperarure)
            :base(name, brand, price)
        {
            this.volume = volume;
            this.temperature = temperarure;
        }

        public override string ProductInfo()
        {
            return string.Format($"{base.ProductInfo()}; Объём - {this.volume}; Температура - {this.Temperature}");
        }
    }
}
