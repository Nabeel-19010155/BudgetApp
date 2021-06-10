namespace BudgetWebApp19010155.Models
{
    public partial class BasicInfo
    {
        public static int counter = 0;

        public int UId { get; set; }
        public decimal GrossInc { get; set; }
        public decimal MonthlyExp { get; set; }
        public decimal Groceries { get; set; }
        public decimal WaterLights { get; set; }
        public decimal TravelCosts { get; set; }
        public decimal PhoneCosts { get; set; }
        public decimal OtherExp { get; set; }
        public decimal NetIncome { get; set; }

        public virtual LoginInfo U { get; set; }
    }
}
