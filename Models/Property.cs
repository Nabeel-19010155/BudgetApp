namespace BudgetWebApp19010155.Models
{
    public class Property
    {
        public static int counter = 0;
        public static int rentOrBuy = 0;
        public double PropRentalAmt { get; set; }   //get and set for the rental amount of the property
        public double PropPurPrice { get; set; }    //get and set for the purchase price of the property
        public double PropDeposit { get; set; }     //get and set for the deposit of the property
        public double PropIntRate { get; set; }     //get and set for the interest rate percentage of the property
        public int PropRepayMonths { get; set; } //get and set for the number of months to pay off the property
        public double PropRentPerMonth { get; set; }
        public double PropBuyCostPerMonth { get; set; }
    }
}
