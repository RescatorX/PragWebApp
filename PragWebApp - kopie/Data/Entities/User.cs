using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;

namespace PragWebApp.Data.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public UserStatus Status { get; set; }

        public override string ToString()
        {
            return "User: [ Id=" + this.Id 
                + ", FirstName=" + this.FirstName + ", LastName=" + this.LastName 
                + ", Login=" + this.Login + ", Password=" + this.Password 
                + ", Created=" + this.Created.ToString("yyyy-MM-dd HH:mm:ss") 
                + ", Status=" + this.Status.ToString() 
                + " ]";
        }
    }
}
