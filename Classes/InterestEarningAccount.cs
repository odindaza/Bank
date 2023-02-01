using Classes;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance): base(name, initialBalance)
    {

    }

    public override void PerformMonthEndTransactinos()
    {
        if(Balance > 500m)
        {
            decimal interest = Balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "apply montly interest");
        }
    }

}
