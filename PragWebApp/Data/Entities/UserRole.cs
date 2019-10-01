using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Data.Entities
{
    public class UserRole : BaseEntity
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime Added { get; set; }

        public override string ToString()
        {
            return "User: [ Id=" + this.Id
                + ", User=" + this.User.ToString()
                + ", Role=" + this.Role.ToString()
                + ", Added=" + this.Added.ToString("yyyy-MM-dd HH:mm:ss")
                + " ]";
        }
    }
}
