using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Entities;
using PragWebApp.Utils.Attributes;

namespace PragWebApp.Models.AuditTrailViewModels
{
    public class AuditTrailListViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date from")]
        [DateTimeNotAfter("ListTo", ErrorMessage = "'{0}' value cannot be after '{1}' value")]
        public DateTime? ListFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date to")]
        [DateTimeNotBefore("ListFrom", ErrorMessage = "'{0}' value cannot be before '{1}' value")]
        public DateTime? ListTo { get; set; }

        public IEnumerable<AuditTrail> Items { get; set; }
    }
}
