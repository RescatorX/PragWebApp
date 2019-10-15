using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Models.CalendarViewModels
{
    public class CalendarMonthViewModel
    {
        public DateTime FirstDay { get; set; }
        public List<int> SelectedDays { get; set; }
    }
}
