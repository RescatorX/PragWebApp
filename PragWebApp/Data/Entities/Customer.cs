using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;
using PragWebApp.Extensions;
using PragWebApp.Resources;
using PragWebApp.Utils;

namespace PragWebApp.Data.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.FirstName, ResourceType = typeof(Controllers_CustomerController))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.LastName, ResourceType = typeof(Controllers_CustomerController))]
        public string LastName { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.Email, ResourceType = typeof(Controllers_CustomerController))]
        public string Email { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.PhoneNumber, ResourceType = typeof(Controllers_CustomerController))]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.SendEmails, ResourceType = typeof(Controllers_CustomerController))]
        public bool SendEmails { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.SendSmss, ResourceType = typeof(Controllers_CustomerController))]
        public bool SendSmss { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.Description, ResourceType = typeof(Controllers_CustomerController))]
        public string Description { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.Created, ResourceType = typeof(Controllers_CustomerController))]
        public DateTime Created { get; set; }

        [Required]
        [Display(Name = ResourceKeys.Controllers.CustomerController.Status, ResourceType = typeof(Controllers_CustomerController))]
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
