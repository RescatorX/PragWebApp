using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using PragWebApp.Data.Enums;
using PragWebApp.Extensions;
using PragWebApp.Models;

namespace PragWebApp.Data.Entities
{
    [DataContract]
    public class CalendarEvent : BaseEntity
    {
        [DataMember(Name = "title", Order = 1)]
        public string Title { get; set; }

        [DataMember(Name = "owner", Order = 2)]
        public ApplicationUser Owner { get; set; }

        [DataMember(Name = "eventType", Order = 3)]
        public CalendarEventType EventType { get; set; }

        [DataMember(Name = "start", Order = 4)]
        public DateTime Start { get; set; }

        [DataMember(Name = "end", Order = 5)]

        public DateTime End { get; set; }
        [DataMember(Name = "customer", Order = 6)]
        public Customer Customer { get; set; }

        [DataMember(Name = "customerName", Order = 7)]
        public string CustomerName { get; set; }

        [DataMember(Name = "customerEmail", Order = 8)]
        public string CustomerEmail { get; set; }

        [DataMember(Name = "customerPhoneNumber", Order = 9)]
        public string CustomerPhoneNumber { get; set; }

        [DataMember(Name = "sendEmail", Order = 10)]
        public bool SendEmail { get; set; }

        [DataMember(Name = "sendSms", Order = 11)]
        public bool SendSms { get; set; }

        [DataMember(Name = "allDay", Order = 12)]
        public bool AllDay { get; set; }

        [DataMember(Name = "created", Order = 13)]
        public DateTime Created { get; set; }

        [DataMember(Name = "createdBy", Order = 14)]
        public ApplicationUser CreatedBy { get; set; }

        [DataMember(Name = "status", Order = 15)]
        public EventStatus Status { get; set; }

        [DataMember(Name = "note", Order = 16)]
        public string Note { get; set; }

        public override string ToString()
        {
            return "CalendarEvent: [ Id=" + this.Id
                + ", Title=" + this.Title
                + ", Owner=" + this.Owner.ToString()
                + ", Event=" + this.EventType.ToString()
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
                + ", Note=" + this.Note
                + " ]";
        }
    }
}
