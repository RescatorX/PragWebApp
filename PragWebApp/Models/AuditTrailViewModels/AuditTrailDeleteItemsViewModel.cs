using PragWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Models.AuditTrailViewModels
{
    public class AuditTrailDeleteItemsViewModel
    {
        public bool DeleteAllItems { get; set; }

        public IEnumerable<AuditTrail> ItemsToDelete { get; set; }
    }
}
