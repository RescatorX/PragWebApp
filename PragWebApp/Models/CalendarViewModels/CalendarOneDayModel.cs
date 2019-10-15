using PragWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Models.CalendarViewModels
{
    public class CalendarOneDayModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<CalendarEvent> Events { get; set; }
    }
}
