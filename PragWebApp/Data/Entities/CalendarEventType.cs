using PragWebApp.Resources;
using PragWebApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Data.Entities
{
    public class CalendarEventType : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(Controllers_CalendarEventTypeController), ErrorMessageResourceName = ResourceKeys.Controllers.CalendarEventTypeController.NameRequired)]
        [Display(ResourceType = typeof(Controllers_CalendarEventTypeController), Name = ResourceKeys.Controllers.CalendarEventTypeController.Name)]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Controllers_CalendarEventTypeController), ErrorMessageResourceName = ResourceKeys.Controllers.CalendarEventTypeController.ColorRequired)]
        [Display(ResourceType = typeof(Controllers_CalendarEventTypeController), Name = ResourceKeys.Controllers.CalendarEventTypeController.Color)]
        public string Color { get; set; }

        public override string ToString()
        {
            return "CalendarEventType: [ Id=" + this.Id
                + ", Name=" + this.Name
                + ", Color=" + this.Color.ToString()
                + " ]";
        }
    }
}
