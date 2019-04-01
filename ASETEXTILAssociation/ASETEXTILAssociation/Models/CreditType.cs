using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class CreditType
    {
        public CreditType()
        {
            Credits = new List<Credit>();
        }

        public int CreditTypeId { get; set; }
        public string Name { get; set; }
        public int MonthTerm { get; set; }
        public int Interest { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }

    }
}
