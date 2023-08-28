namespace Семинар_1.HotDrinks
{
    internal class Coffee : Cocoa
    {
        double fat; // жирность
        public double Fat { get { return fat; } }

        public Coffee(string name, string brand, double price, double volume, int temperarure, double fat)
            : base(name, brand, price, volume, temperarure)
        {
            this.fat = fat;
        }
    }
}
