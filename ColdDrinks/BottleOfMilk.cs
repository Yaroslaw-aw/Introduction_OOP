namespace Семинар_1.Products
{
    internal class BottleOfMilk : BottleOfWater
    {
        double fat; // Жирность

        public double Fat { get { return fat; } }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        //public BottleOfMilk() : base("Nonema") { }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        /// <param name="name">Название</param>
        public BottleOfMilk(string name)
            : base(name, "Noname") { }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        public BottleOfMilk(string name, string brand)
            : base(name, brand, 100) { }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        /// <param name="price">Цена</param>
        public BottleOfMilk(string name, string brand, double price)
            : base(name, brand, price, double.NaN) { }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объём</param>
        public BottleOfMilk(string name, string brand, double price, double volume)
            : this(name, brand, price, volume, double.NaN) { }

        /// <summary>
        /// Создаёт бутылку молока
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объём</param>
        /// <param name="fat">Жирность</param>
        public BottleOfMilk(string name, string brand, double price, double volume, double fat)
            : base(name, brand, price, volume)
        {
            this.fat = fat;
        }

        public override string ProductInfo()
        {
            return string.Format($"{base.ProductInfo()}; Жирность - {Fat}%");
        }
    }
}
