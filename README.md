# Morgan_Bank2
School project

This program simulates a simple banking operation within the console app of C#.

The program allows pre made users to log in, check their account balances, withdraw money, and transfer money to other accounts.

The program consists of two classes: User and Account.

The User class defines the user, which has pre-made login credentials, and one or more accounts. It also has methods for listing the user's accounts, withdrawing money from an account, and fetching an account by label for withdrawals and transfers ( Konto", "Sparkonto", etc.).

The Account class defines an account, which has a label and a balance. It also has a method for withdrawing money from the account.

The Main method creates an array of five users, each with their own login credentials and accounts. It then allows the user to log in and select an account, after which they can view their balance, withdraw money, or transfer money to another account.

