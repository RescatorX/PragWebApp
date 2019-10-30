using PragWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PragWebApp.Models.CalendarViewModels
{
    [DataContract]
    public class SelectorDay
    {
        [DataMember(Name = "day", Order = 1)]
        public int Day { get; set; }

        [DataMember(Name = "month", Order = 2)]
        public int Month { get; set; }

        [DataMember(Name = "year", Order = 3)]
        public int Year { get; set; }

        [DataMember(Name = "isInMonth", Order = 4)]
        public bool IsInMonth { get; set; }

        [DataMember(Name = "isCurrentDay", Order = 5)]
        public bool IsCurrentDay { get; set; }

        [DataMember(Name = "isSelected", Order = 6)]
        public bool IsSelected { get; set; }

        [DataMember(Name = "dayOfWeek", Order = 7)]
        public int DayOfWeek { get; set; }

        [DataMember(Name = "date", Order = 8)]
        public string Date { get; set; }
    }

    [DataContract]
    public class SelectorWeek
    {
        [DataMember(Name = "week", Order = 1)]
        public int Week { get; set; }

        [DataMember(Name = "days", Order = 2)]
        public SelectorDay[] Days { get; set; }
    }

    [DataContract]
    public class CalendarInitViewModel
    {
        [DataMember(Name = "user", Order = 1)]
        public string User { get; set; }

        [DataMember(Name = "isAdmin", Order = 2)]
        public bool IsAdmin { get; set; }

        [DataMember(Name = "year", Order = 3)]
        public int Year { get; set; }

        [DataMember(Name = "month", Order = 4)]
        public int Month { get; set; }

        [DataMember(Name = "monthName", Order = 5)]
        public string MonthName { get; set; }

        [DataMember(Name = "monthDays", Order = 6)]
        public int MonthDays { get; set; }

        [DataMember(Name = "weeks", Order = 7)]
        public SelectorWeek[] Weeks { get; set; }

        [DataMember(Name = "users", Order = 8)]
        public UserEntity[] Users { get; set; }

        [DataMember(Name = "stylists", Order = 9)]
        public UserEntity[] Stylists { get; set; }

        [DataMember(Name = "customers", Order = 10)]
        public Customer[] Customers { get; set; }

        [DataMember(Name = "eventTypes", Order = 11)]
        public CalendarEventType[] EventTypes { get; set; }

        [DataMember(Name = "statuses", Order = 12)]
        public RegisterEntity[] Statuses { get; set; }
    }

    [DataContract]
    public class SelectorDateParams
    {
        [DataMember(Name = "year", Order = 1)]
        public int Year { get; set; }

        [DataMember(Name = "month", Order = 2)]
        public int Month { get; set; }
    }

    [DataContract]
    public class RegisterEntity
    {
        [DataMember(Name = "id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class UserEntity
    {
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "email", Order = 3)]
        public string Email { get; set; }
    }
}
