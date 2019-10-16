﻿using System;
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

        [DataMember(Name = "isInMonth", Order = 2)]
        public bool IsInMonth { get; set; }

        [DataMember(Name = "isCurrentDay", Order = 3)]
        public bool IsCurrentDay { get; set; }

        [DataMember(Name = "isSelected", Order = 4)]
        public bool IsSelected { get; set; }
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

        [DataMember(Name = "weeks", Order = 6)]
        public SelectorWeek[] Weeks { get; set; }

        [DataMember(Name = "viewRange", Order = 7)]
        public string ViewRange { get; set; }
    }

    [DataContract]
    public class SelectorDateParams
    {
        [DataMember(Name = "year", Order = 1)]
        public int Year { get; set; }

        [DataMember(Name = "month", Order = 2)]
        public int Month { get; set; }
    }
}