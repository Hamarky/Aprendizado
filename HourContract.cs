using System;

namespace _03_RLPCSharp.Entities
{
    class HourContract
    {

        public DateTime Date { get; set; }
        public double ValuerPerHour { get; set; }
        public int Hours { get; set; }
        public HourContract()
        {

        }
        public HourContract(DateTime date, double valuerPerHour, int hours)
        {
            Date = date;
            ValuerPerHour = valuerPerHour;
            Hours = hours;
        }
        public double TotalValue()
        {
            return Hours * ValuerPerHour;
        }

    }
}
