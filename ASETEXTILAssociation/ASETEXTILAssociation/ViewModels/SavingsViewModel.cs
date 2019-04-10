using ASETEXTILAssociation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.ViewModels
{
    public class SavingsViewModel
    {
        public int SavingId { get; set; }
        public double Amount { get; set; }
        public int SavingTypeId { get; set; }
        public string Name { get; set; }
        public int MonthTerm { get; set; }
        public int Interest { get; set; }
        public IEnumerable<SavingType> SavingTypesObject { get; set; }
        public IEnumerable<SelectListItem> SavingTypes { get; set; }

    }
}
