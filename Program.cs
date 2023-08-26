using System.Collections.Generic;
using Семинар_1.HotDrinks;
using Семинар_1.Products;
using Семинар_1.VendingMachines;



namespace Семинар_1
{
    internal class Program
    {
        static void Working(List<Product> purchases, ColdDrinksMachine coldDrinksMachine, HotDrinksMachine hotDrinksMachine)
        {
            Console.Clear();
            Console.WriteLine("Выберете пункт меню:");
            Console.WriteLine($" 1 - Купить холодный напиток\n" +
                              $" 2 - Купить горячий напиток\n" +
                              $" 3 - Добавить холодный напиток\n" +
                              $" 4 - Добавить горячий напиток\n" +
                              $" 0 - Завершить работу автомата\n");

            Console.WriteLine();
            Console.WriteLine("Ваши покупки:");
            foreach (var purchase in purchases)
            {
                if (purchase != null)
                {
                    Console.WriteLine(purchase.ProductInfo());
                }
            }
            int.TryParse(Console.ReadLine(), out int number);
            switch (number)
            {
                case 0:
                    {
                        Console.WriteLine("Спасибо за покупки.");
                        return;
                    }
                case 1:
                    {
                        string name = string.Empty;
                        double volume = 0;
                        Console.WriteLine("Выберете холодный напиток:");
                        coldDrinksMachine.ShowAvailability();
                        int.TryParse(Console.ReadLine(), out int nomCold);
                        switch (nomCold)
                        {
                            case 1:
                                {
                                    name = "Лимонная";
                                    volume = 1.5;
                                    purchases.Add(coldDrinksMachine.GetBottleOfWater(name, volume));
                                    break;
                                }
                            case 2:
                                {
                                    name = "Коровка";
                                    volume = 0.5;
                                    purchases.Add(coldDrinksMachine.GetBottleOfMilk(name, volume));
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Введен неверный номер");
                                    break;
                                }
                        }                        
                        break;
                    }
                case 2:
                    {
                        string name = string.Empty;
                        double volume = 0;
                        int temperature = 0;

                        Console.WriteLine("Выберете горячий напиток:");
                        hotDrinksMachine.ShowAvailability();
                        int.TryParse(Console.ReadLine(), out int nomHot);
                        switch (nomHot)
                        {
                            case 1:
                                {
                                    name = "Латтэ";
                                    volume = 0.4;
                                    temperature = 80;
                                    purchases.Add(hotDrinksMachine.GetProduct(name, volume, temperature));
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Введен неверный номер");
                                    break;
                                }
                        }                        
                        break;
                    }
                case 3:
                    {
                        string name = string.Empty;
                        string brand = string.Empty;
                        double price = 0;
                        double volume = 0;
                        double fat = double.NaN;
                        Console.WriteLine("Введите название напитка:");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите брэнд напитка:");
                        brand = Console.ReadLine();
                        Console.WriteLine("Введите название цену напитка:");
                        double.TryParse(Console.ReadLine(), out price);
                        Console.WriteLine("Введите объём напитка:");
                        double.TryParse(Console.ReadLine(), out volume);
                        Console.WriteLine("Введите жирность напитка, если она присутствует:");
                        double.TryParse(Console.ReadLine(), out fat);

                        if (fat != null)
                        {
                            Product product = new BottleOfMilk(name, brand, price, volume, fat);
                            coldDrinksMachine.AddProduct(product);
                        }
                        else
                        {
                            Product product = new BottleOfWater(name, brand, price, volume);
                            coldDrinksMachine.AddProduct(product);
                        }
                        break;
                    }
                case 4:
                    {
                        string name = string.Empty;
                        string brand = string.Empty;
                        double price = 0;
                        double volume = 0;
                        int temperature = 0;
                        Console.WriteLine("Введите название напитка:");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите брэнд напитка:");
                        brand = Console.ReadLine();
                        Console.WriteLine("Введите название цену напитка:");
                        double.TryParse(Console.ReadLine(), out price);
                        Console.WriteLine("Введите объём напитка:");
                        double.TryParse(Console.ReadLine(), out volume);
                        Console.WriteLine("Введите температуру напитка:");
                        int.TryParse(Console.ReadLine(), out temperature);

                        HotDrink hotDrink = new Coffee(name, brand, price, volume, temperature);
                        hotDrinksMachine.AddProduct(hotDrink);

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введен неверный номер");
                        break;
                    }
            }

            Working(purchases, coldDrinksMachine, hotDrinksMachine);

        }


        static void Main(string[] args)
        {
            List<Product> products1 = new List<Product>();

            Product water1 = new BottleOfWater("Лимонная", "Бон Аква", 125, 1.5);

            Product milk1 = new BottleOfMilk("Коровка", "Кореновка", 134, 0.5, 2.5);

            products1.Add(water1);
            products1.Add(milk1);

            Console.WriteLine(water1.ProductInfo());
            Console.WriteLine(milk1.ProductInfo());

            Product coffee1 = new Coffee("Латтэ", "МакКофе", 130, 0.4, 80);
            Console.WriteLine(((Coffee)coffee1).ProductInfo());

            ColdDrinksMachine coldDrinks1 = new ColdDrinksMachine(products1);

            Console.WriteLine("\nВы купили:");
            Console.WriteLine(coldDrinks1.GetBottleOfWater("Лимонная", 1.5).ProductInfo());

            HotDrinksMachine hotDrinks1 = new HotDrinksMachine();

            hotDrinks1.AddProduct(coffee1);
            Console.WriteLine("\nВы купили:");
            Console.WriteLine(hotDrinks1.GetProduct("Латтэ", 0.4, 80).ProductInfo());

            Console.ReadKey();

            List<Product> purchases = new List<Product>();

            Working(purchases, coldDrinks1, hotDrinks1);
        }
    }
}