using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class PaymentPlan
    {
        public PaymentPlan()
        {

        }

        public int PaymentPlanId { get; set; }
        public int Month { get; set; }
        public double InitialBalance { get; set; }
        public double Amortization { get; set; }
        public int Interest { get; set; }
        public int MonthlyFee { get; set; }
        public double FinalBalance { get; set; }
    }
}
