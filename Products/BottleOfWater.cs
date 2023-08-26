namespace Семинар_1.Products
{
    internal class BottleOfWater : Product
    {
        double volume; // Объём

        public double Volume { get { return volume; } }

        /// <summary>
        /// Создаёт бутылку воды
        /// </summary>
        public BottleOfWater() : base("Nonema") { }

        /// <summary>
        /// Создаёт бутылку воды
        /// </summary>
        /// <param name="name">Название</param>
        public BottleOfWater(string name)
            : base(name, "Noname") { }

        /// <summary>
        /// Создаёт бутылку воды
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        public BottleOfWater(string name, string brand)
            : base(name, brand, 100) { }

        /// <summary>
        /// Создаёт бутылку воды
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        /// <param name="price">Цена</param>
        public BottleOfWater(string name, string brand, double price)
            : this(name, brand, price, double.NaN) { }

        /// <summary>
        /// Создаёт бутылку воды
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="brand">Брэнд</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объём</param>
        public BottleOfWater(string name, string brand, double price, double volume)
            : base(name, brand, price)
        {
            this.volume = volume;
        }

        public override string ProductInfo()
        {
            return string.Format($"{base.ProductInfo()}; Объём - {Volume}");
        }
    }
}
