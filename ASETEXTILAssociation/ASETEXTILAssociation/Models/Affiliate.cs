using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class Affiliate
    {
        public Affiliate()
        {
            Credits = new List<Credit>();
        }

        public int AffiliateId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string JobPosition { get; set; }
        public double NetSalary { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
        public virtual UserType UserType { get; set; }

    }
}
