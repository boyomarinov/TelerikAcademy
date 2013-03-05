using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_AbstractHuman
{
    class Worker : Human
    {
        public int WeekSalary { get; set; }
        public short WorkHoursPerDay { get; set; }

        public Worker(string fname, string lname, int weeksalary, short workHoursPerDay)
            : base(fname, lname)
        {
            WeekSalary = weeksalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return (decimal)WeekSalary / (7 * WorkHoursPerDay);
        }

    }
}
