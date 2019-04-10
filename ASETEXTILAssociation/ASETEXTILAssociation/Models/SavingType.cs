using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class SavingType
    {
        public SavingType()
        {
            Savings = new List<Saving>();
        }

        public int SavingTypeId { get; set; }
        public string Name { get; set; }
        public int MonthTerm { get; set; }
        public int Interest { get; set; }

        public virtual ICollection<Saving> Savings { get; set; }

    }
}
