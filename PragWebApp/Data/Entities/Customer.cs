using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;
using PragWebApp.Extensions;

namespace PragWebApp.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool SendEmails { get; set; }
        public bool SendSmss { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public CustomerStatus Status { get; set; }

        public override string ToString()
        {
            return "Customer: [ Id=" + this.Id
                + ", FirstName=" + this.FirstName
                + ", LastName=" + this.LastName
                + ", Email=" + this.Email
                + ", PhoneNumber=" + this.PhoneNumber
                + ", SendEmails=" + this.SendEmails
                + ", SendSmss=" + this.SendSmss
                + ", Description=" + this.Description
                + ", Created=" + this.Created.ToCzString()
                + ", Status=" + this.Status.ToString()
                + " ]";
        }
    }
}
