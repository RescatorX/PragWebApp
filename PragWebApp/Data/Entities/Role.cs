using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;

namespace PragWebApp.Data.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public RoleStatus Status { get; set; }

        public override string ToString()
        {
            return "Role: [ Id=" + this.Id
                + ", Name=" + this.Name
                + ", Created=" + this.Created.ToString("yyyy-MM-dd HH:mm:ss")
                + ", Status=" + this.Status.ToString() 
                + " ]";
        }
    }
}
