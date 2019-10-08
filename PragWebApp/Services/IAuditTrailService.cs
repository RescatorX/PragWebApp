using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data;
using PragWebApp.Data.Entities;
using PragWebApp.Models;

namespace PragWebApp.Services
{
    public interface IAuditTrailService
    {
        Task<AuditTrail> CreateAuditTrailAsync(ApplicationDbContext db, ApplicationUser user, string title, string operation, string detail = null);
    }
}
