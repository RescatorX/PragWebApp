using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PragWebApp.Data;
using PragWebApp.Data.Entities;
using PragWebApp.Models;

namespace PragWebApp.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        public async Task<AuditTrail> CreateAuditTrailAsync(ApplicationDbContext db, ApplicationUser user, string title, string operation, string detail = null)
        {
            AuditTrail at = new AuditTrail() { Id = Guid.NewGuid(), User = user, Title = title, Operation = operation, Detail = detail, Created = DateTime.Now };
            db.AuditTrails.Add(at);
            await db.SaveChangesAsync();

            return at;
        }
    }
}
