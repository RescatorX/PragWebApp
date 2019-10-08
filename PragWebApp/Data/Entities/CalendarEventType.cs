using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Data.Entities
{
    public class CalendarEventType : BaseEntity
    {
        public string Name { get; set; }
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
