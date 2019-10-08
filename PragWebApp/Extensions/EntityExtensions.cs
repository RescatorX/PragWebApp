using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PragWebApp.Data.Entities;

namespace PragWebApp.Extensions
{
    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : BaseEntity
        {
            if (dbSet != null)
            {
                dbSet.RemoveRange(dbSet);
            }
        }
    }
}
