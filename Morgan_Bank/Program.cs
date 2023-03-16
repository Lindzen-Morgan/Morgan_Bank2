

using System.Security.Principal;

namespace Morgan_Bank;


class Program
{
    public class User
    {   //defining user class for login and pin number
        internal Account[] Accounts;
        public string logIn { get; set; }
        public string pinCode { get; set; }
        public bool IsAuthenticated { get; set; }
    }
    public class Account
    {
        public string Label { get; set; }
        public decimal Balance { get; set; }
    }
    static void Main(string[] args)
    {

        //creating the users in the console application using array
        //each with their own login credentials
        User[] users = new User[5];

        users[0] = new User { logIn = "Elina", pinCode = "3333" };
        users[1] = new User { logIn = "Emily", pinCode = "9797" };
        users[2] = new User { logIn = "Michaela", pinCode = "9898" };
        users[3] = new User { logIn = "Bella", pinCode = "2020" };
        users[4] = new User { logIn = "Molly", pinCode = "2121" };

        users[0].Accounts = new Account[] {

    new Account { Label = "Checking", Balance = 1000.00M },
    new Account { Label = "Savings", Balance = 5000.00M }
};
        users[1].Accounts = new Account[] {
        new Account { Label = "Main", Balance = 2500.00M },
        new Account { Label = "Secondary", Balance = 100.50M }
    };
        users[2].Accounts = new Account[] {
        new Account { Label = "Personal", Balance = 15000.00M },
        new Account { Label = "Business", Balance = 8000.00M },
        new Account { Label = "Savings", Balance = 500.75M }
    };
        users[3].Accounts = new Account[] {
        new Account { Label = "Primary", Balance = 200.00M }
    };
        users[4].Accounts = new Account[] {
        new Account { Label = "Checking", Balance = 3000.00M },
        new Account { Label = "Savings", Balance = 15000.00M },
        new Account { Label = "Investment", Balance = 20000.50M }
    };
        User currentUser = null;

        //making the user enter the pin + login and creating while loop so the user says in program
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter your login:");
            string login = Console.ReadLine();

            Console.WriteLine("Enter your PIN:");
            string pin = Console.ReadLine();

            //creating fail message if user enters wrong login or pin
            bool validUser = false;

            foreach (User user in users)
            {
                if (user.logIn == login && user.pinCode == pin)
                {
                    currentUser = user;
                    validUser = true;
                    break;
                }
            }

            if (validUser)
            {
                Console.WriteLine("Login successful!");
                currentUser.IsAuthenticated = true;

                if (currentUser.Accounts != null)
                {
                    // Display account information here
                }

                // Display menu options and handle user input
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen till Morgan_Bank! Var god välj någon av dessa alternativ:");
                    Console.WriteLine("1. Se dina konton och saldon");
                    Console.WriteLine("2. Överföring mellan konton");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");

                    //reads the user input
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Accounts and balances:");
                        foreach (Account account in currentUser.Accounts)
                        {
                            Console.WriteLine("{0}: {1:C}", account.Label, account.Balance);
                        }
                        Console.WriteLine("Press ENTER to return to the main menu...");
                        Console.ReadLine();
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Transfer between accounts:");
                        // Perform transfer operation here
                        Console.WriteLine("Press ENTER to return to the main menu...");
                        Console.ReadLine();
                    }
                    else if (input == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Withdraw money:");
                        // Perform withdrawal operation here
                        Console.WriteLine("Press ENTER to return to the main menu...");
                        Console.ReadLine();
                    }
                    else if (input == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("Logout successful.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine("Press ENTER to return to the main menu...");
                        Console.ReadLine();
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid login or PIN.");
            }



        }
    }
}

                

        
    
  
        
    





