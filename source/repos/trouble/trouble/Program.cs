namespace trouble
{
    internal class Program
    {
        public static void CreateAccountPage()
        {
        Register:
            Console.WriteLine("Create account");
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Date of birth (dd.MM.yyyy): ");
            var birth = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            try
            {
                Helpers.UserManager.CreateAccount(firstName!, lastName!, birth!, email!.ToLower().Trim(), password!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Register;

            }
        }
        public static bool LoginPage()
        {
            while (true)
            {
                Console.WriteLine("Login");
                Console.Write("Email: ");
                var loginEmail = Console.ReadLine();
                Console.Write("Password: ");
                var loginPassword = Console.ReadLine();

                if (Helpers.UserManager.Login(loginEmail!, loginPassword!))
                {
                    Console.WriteLine("Login successful!");
                    if (Helpers.UserManager.User is not null)
                    {
                        Console.WriteLine($"Welcome {Helpers.UserManager.User.Name}!");
                        Thread.Sleep(2000);

                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                }
            }
        }
        public static void MainPage()
        {
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Login");
        }

        static void Main(string[] args)
        {
            bool loggedin = false;
            while (true)
            {
                if (!loggedin)
                {

                    MainPage();
                    Console.Write("Make choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            CreateAccountPage();
                            loggedin = LoginPage();
                            break;
                        case "2":
                            Console.Clear();
                            loggedin = LoginPage();
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                if (loggedin)
                {
                    while (loggedin)
                    {
                        Console.Clear();
                        Console.WriteLine("Menu:");
                        Console.WriteLine("1. Categories");
                        Console.WriteLine("2. Basket");
                        Console.WriteLine("3. Payment");
                        Console.WriteLine("4. Exit");
                        Console.Write("Make choice: ");
                        var choice = Console.ReadLine();
                        Console.Clear();
                        switch (choice)
                        {
                            case "1":
                                Console.Clear();
                                Helpers.Categories.ShowCategories();

                                Console.Write("Choose category: ");
                                var categoryChoice = Console.ReadLine();
                                Console.Clear();
                                Helpers.Categories.ShowProducts(categoryChoice);
                                break;
                            case "2":
                                Console.Clear();
                                Helpers.Categories.GetBasket();
                                Helpers.Categories.RemoveFromBasket();
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine("Payment: ");
                                Helpers.Categories.CalculateTotal();
                                break;
                            case "4":
                                loggedin = false;
                                Helpers.UserManager.Logout();
                                return;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }
                }
            }
        }
    }
}
