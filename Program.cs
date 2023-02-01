using Classes;

var account = new BankAccount("Nick", 1000);

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");

Console.WriteLine(account.GetAccountHistory());

BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caugh creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}

try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attemp to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}



