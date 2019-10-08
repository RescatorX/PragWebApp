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
        [DataType(DataType.DateTime)]
        [Display(Name = "Time from")]
        [DateTimeNotAfter("Time to", ErrorMessage = "Time from value cannot be after '{0}' value")]
        public DateTime? ListFrom { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Time to")]
        [DateTimeNotBefore("Time from", ErrorMessage = "Time to value cannot be before '{0}' value")]
        public DateTime? ListTo { get; set; }

        public IEnumerable<AuditTrail> Items { get; set; }
    }
}
