namespace Семинар_1.BaseProduct
{
    internal abstract class Product
    {
        protected string name;
        protected string brand;
        protected double price;

        public string Name { get { return name; } set { CheckName(value); } }
        public string Brand { get { return brand; } set { CheckBrand(value); } }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 100)
                {
                    price = 100;
                }
                else price = value;
            }
        }

        public Product()
            : this("Noname") { }

        public Product(string name)
            : this(name, "Noname") { }

        public Product(string name, string brand)
            : this(name, brand, 100) { }

        public Product(string name, string brand, double price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
                this.name = "Noname";
            else this.name = name;
        }

        void CheckBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
                this.brand = "Noname";
            else this.brand = brand;
        }

        public virtual string ProductInfo()
        {
            return string.Format($"{GetType().Name}   {Name}; Брэнд - {Brand}; Цена - {Price}");
        }
    }
}
