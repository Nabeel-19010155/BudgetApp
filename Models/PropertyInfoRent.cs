using System;
using System.Collections.Generic;

namespace BudgetWebApp19010155.Models
{
    public partial class PropertyInfoRent
    {
        public int UId { get; set; }
        public decimal RentAmt { get; set; }

        public virtual LoginInfo U { get; set; }
    }
}
