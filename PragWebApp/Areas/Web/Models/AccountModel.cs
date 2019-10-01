using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Entities;

namespace PragWebApp.Areas.Web.Models
{
    public class AccountModel
    {
        public User currentUser { get; set; }

        public AccountModel()
        {
            this.currentUser = new User();
        }
    }
}
