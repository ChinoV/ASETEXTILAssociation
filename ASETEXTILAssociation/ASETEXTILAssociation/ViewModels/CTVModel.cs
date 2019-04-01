using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.ViewModels
{
    public class CTVModel
    {
        public int CreditId { get; set; }
        public int State { get; set; }
        public bool Aproved { get; set; }
        public string Purpose { get; set; }
        public double Amount { get; set; }
        public int CreditTypeId { get; set; }
        public string Name { get; set; }
        public int MonthTerm { get; set; }
        public int Interest { get; set; }
        public IEnumerable<SelectListItem> CreditTypes { get; set; }
        
    }
}
