using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Models
{
    public class User
    {
        public User()
        {

        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public virtual UserType UserType { get; set; }

    }
}
