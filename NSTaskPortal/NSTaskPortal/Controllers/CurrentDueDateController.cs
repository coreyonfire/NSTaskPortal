using NSTaskPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NSTaskPortal.Controllers
{
    public class CurrentDueDateController : Controller
    {
        private NSTaskPortalContext db = new NSTaskPortalContext();

        // GET: CurrentDueDate
        public ActionResult CurrentDueDate()
        {
            double taskHours = 0;

            foreach (NSTask task in db.NSTasks.ToList())
            {
                taskHours += task.Hours;
            }

            int TSECount = int.Parse(WebConfigurationManager.AppSettings["TSECount"]);
            int TSEPerDay = int.Parse(WebConfigurationManager.AppSettings["TSEPerDay"]);

            double days = Math.Ceiling(taskHours / (TSEPerDay * TSECount * 1.0));

            DateTime dueDate = DateTime.Today.AddDays(days).Date;

            // now adjust it for holidays
            HashSet<DateTime> holidays = GetHolidays(DateTime.Today.Year);

            // for every holiday that falls between now and the due date, add a day
            // for every weekend that falls between now and the due date, add a day
            DateTime d = DateTime.Today;
            while (d != dueDate)
            {
                if (holidays.Contains(d) || d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday)
                {
                    dueDate = dueDate.AddDays(1);
                }
                d = d.AddDays(1);
            }


            ViewData["hours"] = taskHours;
            ViewData["dueDate"] = dueDate;
            

            return View();
        }

        /* helper methods to fix dates for holidays                                     */
        /* http://stackoverflow.com/questions/3709584/business-holiday-date-handling    */
        private static HashSet<DateTime> GetHolidays(int year)
        {
            HashSet<DateTime> holidays = new HashSet<DateTime>();
            //NEW YEARS 
            DateTime newYearsDate = AdjustForWeekendHoliday(new DateTime(year, 1, 1).Date);
            holidays.Add(newYearsDate);
            //MEMORIAL DAY  -- last monday in May 
            DateTime memorialDay = new DateTime(year, 5, 31);
            DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
            while (dayOfWeek != DayOfWeek.Monday)
            {
                memorialDay = memorialDay.AddDays(-1);
                dayOfWeek = memorialDay.DayOfWeek;
            }
            holidays.Add(memorialDay.Date);

            //INDEPENCENCE DAY 
            DateTime independenceDay = AdjustForWeekendHoliday(new DateTime(year, 7, 4).Date);
            holidays.Add(independenceDay);

            //LABOR DAY -- 1st Monday in September 
            DateTime laborDay = new DateTime(year, 9, 1);
            dayOfWeek = laborDay.DayOfWeek;
            while (dayOfWeek != DayOfWeek.Monday)
            {
                laborDay = laborDay.AddDays(1);
                dayOfWeek = laborDay.DayOfWeek;
            }
            holidays.Add(laborDay.Date);

            //THANKSGIVING DAY - 4th Thursday in November 
            var thanksgiving = (from day in Enumerable.Range(1, 30)
                                where new DateTime(year, 11, day).DayOfWeek == DayOfWeek.Thursday
                                select day).ElementAt(3);
            DateTime thanksgivingDay = new DateTime(year, 11, thanksgiving);
            holidays.Add(thanksgivingDay.Date);

            DateTime christmasDay = AdjustForWeekendHoliday(new DateTime(year, 12, 25).Date);
            holidays.Add(christmasDay);
            return holidays;
        }

        public static DateTime AdjustForWeekendHoliday(DateTime holiday)
        {
            if (holiday.DayOfWeek == DayOfWeek.Saturday)
            {
                return holiday.AddDays(-1);
            }
            else if (holiday.DayOfWeek == DayOfWeek.Sunday)
            {
                return holiday.AddDays(1);
            }
            else
            {
                return holiday;
            }
        }

        /* helper method to enumerate over days */
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }


}