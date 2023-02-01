using Classes;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Transactions;
using System;

var account = new BankAccount("Nick", 1000);

Console.WriteLine($"Account: {account.Number}\tName: {account.Owner}\tInitial Balance: {account.Balance}\n");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.GetAccountHistory());

var giftCard = new GiftCardAccount("gift card", 100, 50);
Console.WriteLine($"Account: {giftCard.Number}\tName: {giftCard.Owner}\tInitial Balance: {giftCard.Balance}\n");
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy goroceries");
giftCard.PerformMonthEndTransactinos();
//can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some aditional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 1000);
Console.WriteLine($"Account: {savings.Number}\tName: {savings.Owner}\tInitial Balance: {savings.Balance}\n");
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactinos();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 0);
Console.WriteLine($"Account: {lineOfCredit.Number}\tName: {lineOfCredit.Owner}\tInitial Balance: {lineOfCredit.Balance}\n");
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactinos();
Console.WriteLine(lineOfCredit.GetAccountHistory());

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



