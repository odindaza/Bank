namespace Classes;

public class BankAccount
{
    private readonly decimal _minimumBalance;
    private static int accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { 
        get 
        { 
            decimal balance = 0;
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        } 
        
    }
    public BankAccount(string name, decimal initialBalance) : 
        this(name, initialBalance, 0) { }
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {  
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if(initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transactions> allTransactions = new List<Transactions>();
    public virtual void PerformMonthEndTransactinos() { }
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if(amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transactions(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if(Balance - amount < _minimumBalance)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transactions(amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach(var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }
}