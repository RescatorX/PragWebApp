using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Models.AuditTrailViewModels
{
    public class AuditTrailListByUserViewModel : AuditTrailListViewModel
    {
        [Required]
        public ApplicationUser ListUser { get; set; }
    }
}
