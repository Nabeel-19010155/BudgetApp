namespace BudgetWebApp19010155.Models
{
    public partial class VehicleInfo
    {
        public static int counter = 0;
        public int UId { get; set; }
        public string ModelMake { get; set; }
        public double PurPrice { get; set; }
        public double TotDeposit { get; set; }
        public double IntRate { get; set; }
        public double InsurancePrem { get; set; }
        public double TotRepayment { get; set; }

        public virtual LoginInfo U { get; set; }

        public VehicleInfo()
        {
        }

        public VehicleInfo(string modelMake, double purPrice, double totDeposit, double intRate, double insurancePrem, double totRepayment)
        {
            ModelMake = modelMake;
            PurPrice = purPrice;
            TotDeposit = totDeposit;
            IntRate = intRate;
            InsurancePrem = insurancePrem;
            TotRepayment = totRepayment;
        }
    }
}
