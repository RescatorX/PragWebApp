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
        [Required(ErrorMessageResourceType = typeof(Controllers_CustomerController), ErrorMessageResourceName = ResourceKeys.Controllers.CustomerController.FirstNameRequired)]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Controllers_CustomerController), ErrorMessageResourceName = ResourceKeys.Controllers.CustomerController.LastNameRequired)]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Controllers_CustomerController), ErrorMessageResourceName = ResourceKeys.Controllers.CustomerController.EmailRequired)]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.Email)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Controllers_CustomerController), ErrorMessageResourceName = ResourceKeys.Controllers.CustomerController.PhoneNumberRequired)]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.SendEmails)]
        public bool SendEmails { get; set; }

        [Required]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.SendSmss)]
        public bool SendSmss { get; set; }

        [Required]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.Description)]
        public string Description { get; set; }

        [Required]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.Created)]
        public DateTime Created { get; set; }

        [Required]
        [Display(ResourceType = typeof(Controllers_CustomerController), Name = ResourceKeys.Controllers.CustomerController.Status)]
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
