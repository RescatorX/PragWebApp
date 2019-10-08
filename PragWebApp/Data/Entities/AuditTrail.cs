﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Extensions;
using PragWebApp.Models;

namespace PragWebApp.Data.Entities
{
    public class AuditTrail : BaseEntity
    {
        public string Title { get; set; }
        public ApplicationUser User { get; set; }
        public string Operation { get; set; }
        public string Detail { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return "AuditTrail: [ Id=" + this.Id
                + ", Title=" + this.Title
                + ", User=" + this.User.ToString()
                + ", Operation=" + this.Operation
                + ", Detail=" + this.Detail
                + ", Created=" + this.Created.ToCzString()
                + " ]";
        }
    }
}
