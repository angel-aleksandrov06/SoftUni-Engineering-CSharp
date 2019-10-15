using System;
using MyHelpLibrary;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            var result = DateModifier.GetDifferenceInDaysBetweenTwoDates(startDate, endDate);

            Console.WriteLine(result);
        }
    }


}
