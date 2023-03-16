

using System.Globalization;
using System.Security.Principal;
using System.Xml.Linq;
using static Morgan_Bank.Program;

namespace Morgan_Bank;


class Program
{
    public class User
    {   //defining user class for login and pin number as well as authentication
        internal Account[] Accounts;
        public string logIn { get; set; }
        public string pinCode { get; set; }
        public bool IsAuthenticated { get; set; }
        public Account GetAccountByLabel(string label)
        {
            return Accounts.FirstOrDefault(a => a.Label == label);
        }

        public void ListAccounts()
        {
            Console.WriteLine($"Konton för användare:");
            foreach (Account account in Accounts)
            {
                Console.WriteLine($"{account.Label}: {account.Balance:C}");
            }
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("Ange från vilket konto du vill ta ut pengar:");
            string label = Console.ReadLine();
            Account account = GetAccountByLabel(label);
            if (account == null)
            {
                Console.WriteLine("Kontot finns inte.");
                return;
            }

            Console.WriteLine($"Nuvarande saldo på {label}: {account.Balance:C}");

            Console.WriteLine("Ange belopp att ta ut:");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Felaktigt belopp.");
                return;
            }

            if (account.Balance < amount)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på kontot.");
                return;
            }


            Console.WriteLine("Ange din pinkod:");
            string pin = Console.ReadLine();
            if (pin != this.pinCode)
            {
                Console.WriteLine("Felaktig pinkod.");
                return;
            }
            account.Balance -= amount;
            Console.WriteLine($"Ny saldo på {label}: {account.Balance:C}");
        }


    }
        public Account GetAccountByLabel(string label)
        {
            return Accounts.FirstOrDefault(a => a.Label == label);
        }

        public void ListAccounts()
        {
            Console.WriteLine($"Konton för användare:");
            foreach (Account account in Accounts)
            {
                Console.WriteLine($"{account.Label}: {account.Balance:C}");
            }
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("Ange från vilket konto du vill ta ut pengar:");
            string label = Console.ReadLine();
            Account account = GetAccountByLabel(label);
            if (account == null)
            {
                Console.WriteLine("Kontot finns inte.");
                return;
            }

            Console.WriteLine($"Nuvarande saldo på {label}: {account.Balance:C}");

            Console.WriteLine("Ange belopp att ta ut:");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Felaktigt belopp.");
                return;
            }

            if (account.Balance < amount)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på kontot.");
                return;
            }

            account.Balance -= amount;
            Console.WriteLine($"Ny saldo på {label}: {account.Balance:C}");
        }

    }
    public class Account
    {
        public string Label { get; set; }
        public decimal Balance { get; set; }

        public void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på kontot.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Ny saldo på {Label}: {Balance:C}");
        }
    }



    static void Transfer(User user)
    {
        Console.WriteLine("Ange från vilket konto du vill överföra pengarna:");
        string sourceLabel = Console.ReadLine();
        Account sourceAccount = user.GetAccountByLabel(sourceLabel);
        if (sourceAccount == null)
        {
            Console.WriteLine("Kontot finns inte.");
            return;
        }

        Console.WriteLine("Ange till vilket konto du vill att pengarna ska gå till:");
        string destinationLabel = Console.ReadLine();
        Account destinationAccount = user.GetAccountByLabel(destinationLabel);
        if (destinationAccount == null)
        {
            Console.WriteLine("Kontot finns inte.");
            return;
        }

        Console.WriteLine("Ange hur mycket pengar du vill föra över:");
        decimal amount;
        if (!decimal.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Felaktigt belopp.");
            return;
        }

        if (sourceAccount.Balance < amount)
        {
            Console.WriteLine("Det finns inte tillräckligt med pengar på källkontot.");
            return;
        }

        decimal oldSourceBalance = sourceAccount.Balance;
        decimal oldDestinationBalance = destinationAccount.Balance;

        sourceAccount.Balance -= amount;
        destinationAccount.Balance += amount;

        Console.WriteLine($"Överföring genomförd. Källkonto: {sourceAccount.Label}, ny balans: {sourceAccount.Balance:C}. " +
            $"Målkonto: {destinationAccount.Label}, ny balans: {destinationAccount.Balance:C}.");

        Console.WriteLine($"Tidigare balanser:\n{sourceAccount.Label}: {oldSourceBalance:C}\n{destinationAccount.Label}: {oldDestinationBalance:C}");
    }
    static void Main(string[] args)
    {

        //creating the users in the console application using array
        //each with their own login credentials
        User[] users = new User[5];
        //testing new branch using this lol
        users[0] = new User { logIn = "Elina", pinCode = "3333" };
        users[1] = new User { logIn = "Emily", pinCode = "9797" };
        users[2] = new User { logIn = "Michaela", pinCode = "9898" };
        users[3] = new User { logIn = "Bella", pinCode = "2020" };
        users[4] = new User { logIn = "Molly", pinCode = "2121" };

        users[0].Accounts = new Account[] {

    new Account { Label = "Konto", Balance = 1000.00M },
    new Account { Label = "Sparkonto", Balance = 5000.00M },
    new Account { Label = "Resekonto", Balance = 5000.00M },
    new Account { Label = "Matkonto", Balance = 5000.00M },
    new Account { Label = "Investeringskonto", Balance = 5000.00M }
};
        users[1].Accounts = new Account[] {
        new Account { Label = "Konto", Balance = 2500.00M },
        new Account { Label = "Sparkonto", Balance = 100.50M }
    };
        users[2].Accounts = new Account[] {
        new Account { Label = "Konto", Balance = 15000.00M },
        new Account { Label = "Sparkonto", Balance = 8000.00M },
        new Account { Label = "Matkonto", Balance = 500.75M }
    };
        users[3].Accounts = new Account[] {
        new Account { Label = "Konto", Balance = 200.00M }
    };
        users[4].Accounts = new Account[] {
        new Account { Label = "Konto", Balance = 3000.00M },
        new Account { Label = "Sparkonto", Balance = 15000.00M },
        new Account { Label = "Resekonto", Balance = 20000.50M },
        new Account { Label = "Matkonto", Balance = 5000.00M }
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
                        //list current useer accounts
                        currentUser.ListAccounts();
                        Console.WriteLine("Överföring av konton:");
                        //Transfer operation
                        Transfer(currentUser);

                        //list current useer accounts
                        currentUser.ListAccounts();
                        Console.WriteLine("Överföring av konton:");
                        //Transfer operation
                        Transfer(currentUser);
                        
                        Console.WriteLine("Press ENTER to return to the main menu...");
                        Console.ReadLine();
                    }
                    else if (input == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Withdraw money:");

                        // List available accounts
                        Console.WriteLine("Available accounts:");
                        foreach (Account account in currentUser.Accounts)
                        {
                            Console.WriteLine("{0}: {1:C}", account.Label, account.Balance);
                        }

                        // Prompt user to choose an account
                        Console.Write("Enter the label of the account you want to withdraw from: ");
                        string accountLabel = Console.ReadLine();

                        // Check if account exists
                        Account withdrawAccount = currentUser.GetAccountByLabel(accountLabel);
                        if (withdrawAccount == null)
                        {
                            Console.WriteLine("Invalid account label.");
                            Console.WriteLine("Press ENTER to return to the main menu...");
                            Console.ReadLine();
                            continue;
                        }

                        // Prompt user to enter withdrawal amount
                        Console.Write("Enter the amount you want to withdraw: ");
                        decimal amount;
                        if (!decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.WriteLine("Invalid amount.");
                            Console.WriteLine("Press ENTER to return to the main menu...");
                            Console.ReadLine();
                            continue;
                        }

                        // Withdraw money from account
                        try
                        {
                            withdrawAccount.Withdraw(amount);
                            Console.WriteLine("{0:C} has been withdrawn from {1}.", amount, withdrawAccount.Label);
                            Console.WriteLine("New balance: {0:C}", withdrawAccount.Balance);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

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












