using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class Credit
    {
        public Credit()
        {

        }

        public int CreditId { get; set; }
        public int State { get; set; }
        public bool Aproved { get; set; }
        public string Purpose { get; set; }
        public double Amount { get; set; }

        public CreditType Type { get; set; }
        public Affiliate Affiliate { get; set; }
    }
}
