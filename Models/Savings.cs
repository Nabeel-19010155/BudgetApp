namespace BudgetWebApp19010155.Models
{
    public class Savings
    {
        public double GoalAmt { get; set; }
        public double MonthlyAmt { get; set; }
        public double IntRate { get; set; }
        public int NoOfYears { get; set; }
        public string Reason { get; set; }

        public Savings()
        {
        }

        public Savings(double goalAmt, double monthlyAmt, double intRate, int noOfYears, string reason)
        {
            GoalAmt = goalAmt;
            MonthlyAmt = monthlyAmt;
            IntRate = intRate;
            NoOfYears = noOfYears;
            Reason = reason;
        }
    }
}
