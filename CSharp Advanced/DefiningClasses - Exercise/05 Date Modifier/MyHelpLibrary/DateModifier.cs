using System;

namespace MyHelpLibrary
{
    public static class DateModifier
    {
        public static double GetDifferenceInDaysBetweenTwoDates(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            var diff = (endDate - startDate).TotalDays;

            var absoluteValue = Math.Abs(diff);

            return absoluteValue;
        }
    }
}
