using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;
using PragWebApp.Extensions;
using PragWebApp.Models;

namespace PragWebApp.Data.Entities
{
    public class CalendarEvent : BaseEntity
    {
        public string Title { get; set; }
        public ApplicationUser Owner { get; set; }
        public CalendarEventType Event { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public bool SendEmail { get; set; }
        public bool SendSms { get; set; }
        public bool AllDay { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public EventStatus Status { get; set; }

        public override string ToString()
        {
            return "CalendarEvent: [ Id=" + this.Id
                + ", Title=" + this.Title
                + ", Owner=" + this.Owner.ToString()
                + ", Event=" + this.Event.ToString()
                + ", Start=" + this.Start.ToCzString()
                + ", End=" + this.End.ToCzString()
                + ", Customer=" + this.Customer.ToString()
                + ", CustomerName=" + this.CustomerName
                + ", CustomerEmail=" + this.CustomerEmail
                + ", CustomerPhoneNumber=" + this.CustomerPhoneNumber
                + ", SendEmail=" + this.SendEmail.ToString()
                + ", SendSms=" + this.SendSms.ToString()
                + ", AllDay=" + this.AllDay.ToString()
                + ", Created=" + this.Created.ToCzString()
                + ", Status=" + this.Status.ToString()
                + " ]";
        }
    }
}
