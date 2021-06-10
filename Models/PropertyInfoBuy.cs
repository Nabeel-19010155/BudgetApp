using System;
using System.Collections.Generic;

namespace BudgetWebApp19010155.Models
{
    public partial class PropertyInfoBuy
    {
        public int UId { get; set; }
        public decimal PurPrice { get; set; }
        public decimal TotDeposit { get; set; }
        public decimal IntRate { get; set; }
        public int NoOfMonths { get; set; }
        public decimal TotRepayment { get; set; }

        public virtual LoginInfo U { get; set; }
    }
}
