namespace market.Models
{
    internal static class Categories
    {
        public static List<string> basket = new List<string>();
        public static void ShowCategories()
        {
            Console.WriteLine("Categories");
            Console.WriteLine("1. Dairy products");
            Console.WriteLine("2. Fruit, vegetable");
            Console.WriteLine("3. Flour products");
            Console.WriteLine("4. Beverage");
        }
        public static void ShowProducts(string category)
        {
            switch (category)
            {
                case "1":
                    Console.WriteLine("1.Cheese");
                    Console.WriteLine("2.Butter");
                    Console.WriteLine("3.Yoghurt");
                    break;
                case "2":
                    Console.WriteLine("1. Apple");
                    Console.WriteLine("2. Pepper");
                    Console.WriteLine("3. Cabbage");
                    break;
                case "3":
                    Console.WriteLine("1. Factory bread");
                    Console.WriteLine("2. Diabetic bread");
                    break;
                case "4":
                    Console.WriteLine("1. Water");
                    Console.WriteLine("2. Juice");
                    Console.WriteLine("3. Lemonade");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;

            }
            Console.Write("Choose product: ");
            var opt = Console.ReadLine();
            Console.Clear();
            Categories.AboutProducts(category, opt);
        }

        public static void DetailsProducts(string name, double price, string info)
        {
            Console.WriteLine($"Product: {name}");
            Console.WriteLine($"Price: {price} azn");
            Console.WriteLine($"Desc: {info}");

            Console.WriteLine("Add to basket: 1. yes 2. no");
            Console.Write("Make choice: 1 or 2 ? ");
            string option = Console.ReadLine();
            if (option == "1")
            {
                basket.Add($"{name}*{price}*AZN");
                Console.WriteLine($"{name} added to basket");
                Thread.Sleep(2000);
            }
        }
        public static void AboutProducts(string category, string product)
        {
            switch (category)
            {
                case "1":
                    switch (product)
                    {
                        case "1":
                            DetailsProducts("Cheese", 13.99, "NOVA GAUDA yellow cheese");
                            break;
                        case "2":
                            DetailsProducts("Butter", 16.99, "VIOLETTO 100% natural butter");
                            break;
                        case "3":
                            DetailsProducts("Yoghurt", 3.49, "YAYLA Sour Village Natural Yoghurt");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    break;
                case "2":
                    switch (product)
                    {
                        case "1":
                            DetailsProducts("Apple", 2.19, "Red apple FUJI");
                            break;
                        case "2":
                            DetailsProducts("Pepper", 3.59, "Green pepper");
                            break;
                        case "3":
                            DetailsProducts("Cabbage", 1.15, "White cabbage");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    break;
                case "3":
                    switch (product)
                    {
                        case "1":
                            DetailsProducts("Factory bread", 0.95, "Sliced white bread");
                            break;
                        case "2":
                            DetailsProducts("Diabetic bread", 2.30, "IVANOVKA 100% Natural");
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    break;
                case "4":
                    switch (product)
                    {
                        case "1":
                            DetailsProducts("Water", 0.95, "SIRAB Still water");
                            break;
                        case "2":
                            DetailsProducts("Juice", 2.20, "NATURA MULTIVITAMIN no sugar mixed fruits");
                            break;
                        case "3":
                            DetailsProducts("Lemonade", 2.05, "NATAKHTARI Pear lemonade");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        public static void GetBasket()
        {
            Console.WriteLine("Basket contents:");

            for (int i = 0; i < basket.Count; i++)
            {
                string[] parts = basket[i].Split('*');
                Console.Write($"{i + 1}. ");
                foreach (string part in parts)
                {
                    Console.Write(part + " ");
                }
                Console.WriteLine();
            }
        }
        public static void RemoveFromBasket()
        {
            if (basket.Count == 0)
            {
                Console.WriteLine("Basket is empty");
                Thread.Sleep(2000);
                return;
            }

            Console.Write("Enter row number of product to remove, else 0 to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice >= 1 && choice <= basket.Count)
                {
                    string removedProduct = basket[choice - 1];
                    basket.RemoveAt(choice - 1);
                    Console.WriteLine($"{removedProduct} removed from basket");
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Canceled");
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }

        public static void CalculateTotal()
        {
            double total = 0;

            foreach (var item in basket)
            {


                string[] parts = item.Split('*');
                if (parts.Length >= 2 && double.TryParse(parts[1], out double price))
                {

                    total += price;
                }
            }
            Console.WriteLine($"Total amount: {total} AZN");
            Console.WriteLine("1. Make payment 2. Go to menu");
            Console.WriteLine("Make choice: ");
            var opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    while (true)
                    {
                        Console.WriteLine("Enter payment:");
                        var pay = Console.ReadLine();
                        if (double.TryParse(pay, out double payment))
                        {
                            if (payment - total == 0)
                            {
                                Console.WriteLine("Thanks for the payment");
                                Thread.Sleep(2000);
                                basket.Clear();
                                break;
                            }
                            else if (payment > total)
                            {
                                Console.WriteLine($"Take your change: {payment - total} AZN");
                                Thread.Sleep(2000);
                                basket.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Payment not enough");
                            }
                        }
                    }
                    break;

                case "2":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}