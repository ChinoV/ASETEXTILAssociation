using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class Saving
    {
        public Saving()
        {

        }

        public int SavingId { get; set; }
        public double Amount { get; set; }

        public SavingType Type { get; set; }
        public Affiliate Affiliate { get; set; }

    }
}
