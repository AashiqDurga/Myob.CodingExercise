using System;
using Myob.CodingExercise.Employee;

namespace Myob.CodingExercise.CsvParser
{
    public class Parser
    {
        public EmployeeDetails Parse(string csvLine)
        {
            var strings = csvLine.Split(',');

            return new EmployeeDetails
            {
                FirstName = strings[0],
                Surname = strings[1],
                AnnualSalary = Convert.ToInt32(strings[2]),
                SuperRate = ParserHelperMethods.GetValidPercentAsDeciamal(strings[3]),
                PaymentPeriod = strings[4],
            };
        }
    }
}