using Семинар_1.BaseProduct;
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
            double sum = 0;
            foreach (var purchase in purchases)
            {
                if (purchase != null)
                {
                    sum += purchase.Price;
                    Console.WriteLine(purchase.ProductInfo());
                }
            }
            Console.WriteLine($"\nОбщая сумма покупок: {sum}");

            int number = InputIntValue("");
            switch (number)
            {
                case 0:
                    {
                        Console.WriteLine("Спасибо за покупки.");
                        return;
                    }
                case 1:
                    {
                        Console.WriteLine("Выберете холодный напиток:");
                        coldDrinksMachine.ShowAvailability();

                        int numCold = InputIntValue("");

                        if (0 < numCold && numCold <= coldDrinksMachine.Size)
                        {
                            string name = coldDrinksMachine.GetProductByIndex(numCold).Name;
                            double volume = coldDrinksMachine.GetProductByIndex(numCold).Volume;
                            purchases.Add(coldDrinksMachine.GetProduct(name, volume));
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод или товара нет в наличии.\r\nНажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Выберете горячий напиток:");
                        hotDrinksMachine.ShowAvailability();

                        int numHot = InputIntValue("");

                        if (0 < numHot && numHot <= hotDrinksMachine.Size)
                        {
                            string name = hotDrinksMachine.GetProductByIndex(numHot).Name;
                            double volume = hotDrinksMachine.GetProductByIndex(numHot).Volume;
                            int temperature = hotDrinksMachine.GetProductByIndex(numHot).Temperature;
                            purchases.Add(hotDrinksMachine.GetProduct(name, volume, temperature));
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод или товара нет в наличии.\r\nНажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }

                        break;
                    }
                case 3: // Добавление холодного напитка
                    {
                        string name = Input("Введите название напитка:");
                        string brand = Input("Введите название брэнда:");
                        double price = InputDoubleValue("Введите цену напитка:");
                        double volume = InputDoubleValue("Введите объём напитка:");
                        double fat = InputDoubleValue("Введите жирность напитка или 0 если жира нет:");

                        void ChoiseWaterOrMilk(string text = $" Если это вода, нажмите - 1 \r\n Если это обезжиренное молоко - 2")
                        {
                            Console.WriteLine(text);
                            bool isCorrectChoise = int.TryParse(Console.ReadLine(), out int choice);
                            if (!isCorrectChoise || choice != 1 && choice != 2)
                            {
                                ChoiseWaterOrMilk("Некорректный ввод, попробуйте ещё раз.\r\n" + $" Если это вода, нажмите - 1 \r\n Если это обезжиренное молоко - 2");
                            }
                            else if (choice == 1)
                            {
                                Product product = new BottleOfWater(name, brand, price, volume);
                                coldDrinksMachine.AddProduct(product);
                                Console.WriteLine("Вода добавлена. Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else if (choice == 2)
                            {
                                Product product = new BottleOfMilk(name, brand, price, volume, fat);
                                coldDrinksMachine.AddProduct(product);
                                Console.WriteLine("Молоко добавлено. Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                        }

                        if (fat != 0)
                        {
                            Product product = new BottleOfMilk(name, brand, price, volume, fat);
                            Console.WriteLine("Бутылка молока добавлена");
                            Console.ReadKey();
                            coldDrinksMachine.AddProduct(product);
                        }
                        else
                        {
                            ChoiseWaterOrMilk();
                        }

                        break;
                    }
                case 4: // Добавление горячего напитка
                    {
                        string name = Input("Введите название напитка:");
                        string brand = Input("Введите название брэнда:");

                        double price = InputDoubleValue("Введите цену напитка:");
                        double volume = InputDoubleValue("Введите объём напитка:");
                        int temperature = InputIntValue("Введите температуру напитка:");
                        double fat = InputDoubleValue("Введите жирность напитка или 0 если жира нет:");

                        void ChoiseCocoaOrCoffee(string text = $" Если это какао, нажмите - 1 \r\n Если это кофе - 2")
                        {
                            Console.WriteLine(text);
                            bool isCorrectChoise = int.TryParse(Console.ReadLine(), out int choice);
                            if (!isCorrectChoise || choice != 1 && choice != 2)
                            {
                                ChoiseCocoaOrCoffee("Некорректный ввод, попробуйте ещё раз.\r\n" + $" Если это какао, нажмите - 1 \r\n Если это кофе - 2");
                            }
                            else if (choice == 1)
                            {
                                HotDrink hotDrink = new Cocoa(name, brand, price, volume, temperature);
                                hotDrinksMachine.AddProduct(hotDrink);
                                Console.WriteLine("Какао добавлено. Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else if (choice == 2)
                            {
                                HotDrink hotDrink = new Coffee(name, brand, price, volume, temperature, fat);
                                hotDrinksMachine.AddProduct(hotDrink);
                                Console.WriteLine("Кофе добавлен. Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                        }

                        if (fat != 0)
                        {
                            HotDrink hotDrink = new Coffee(name, brand, price, volume, temperature, fat);
                            hotDrinksMachine.AddProduct(hotDrink);
                            Console.WriteLine("Кофе добавлен. Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        else
                        {
                            ChoiseCocoaOrCoffee();
                        }

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введен неверный номер");
                        break;
                    }
            }

            string Input(string s)
            {
                Console.WriteLine(s);
                return Console.ReadLine();
            }

            int InputIntValue(string s)
            {
                Console.WriteLine(s);
                bool isCorrectInput = int.TryParse(Console.ReadLine(), out int value);
                if (!isCorrectInput)
                {
                    return InputIntValue("Некорректный ввод. Попробуйте ещё раз");
                }
                else return value;
            }

            double InputDoubleValue(string s)
            {
                Console.WriteLine(s);
                bool isCorrectInput = double.TryParse(Console.ReadLine(), out double value);
                if (!isCorrectInput)
                {
                    return InputIntValue("Некорректный ввод. Попробуйте ещё раз");
                }
                else return value;
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

            Product cocoa = new Cocoa("Какао", "Несквик", 130, 0.4, 80);
            Console.WriteLine(((Cocoa)cocoa).ProductInfo());

            ColdDrinksMachine coldDrinks1 = new ColdDrinksMachine();
            coldDrinks1.AddProduct(water1);
            coldDrinks1.AddProduct(milk1);

            Console.WriteLine("\nВы купили:");
            Console.WriteLine(coldDrinks1.GetProduct("Лимонная", 1.5).ProductInfo());

            HotDrinksMachine hotDrinks1 = new HotDrinksMachine();

            hotDrinks1.AddProduct(cocoa);

            Console.ReadKey();

            List<Product> purchases = new List<Product>();

            Working( purchases /*new List<Product>()*/, coldDrinks1 /*new ColdDrinksMachine()*/, hotDrinks1 /*new HotDrinksMachine()*/);
        }
    }
}