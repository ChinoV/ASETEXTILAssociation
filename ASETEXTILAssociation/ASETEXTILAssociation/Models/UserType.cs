using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class UserType
    {

        public UserType()
        {
            Users = new List<User>();
            Affiliates = new List<Affiliate>();
        }

        public int UserTypeId{ get; set; }
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Affiliate> Affiliates { get; set; }

    }
}
