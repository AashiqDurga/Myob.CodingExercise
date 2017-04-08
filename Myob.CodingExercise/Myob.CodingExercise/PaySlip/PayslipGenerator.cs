using System;
using Myob.CodingExercise.Employee;
using Myob.CodingExercise.IncomeTax;

namespace Myob.CodingExercise.PaySlip
{
    public class PayslipGenerator
    {
        private const int MonthsInYear = 12;

        public PaySlip Generate(EmployeeDetails employeeDetails)
        {
            return BuildPaySlip(employeeDetails);
        }

        private static PaySlip BuildPaySlip(EmployeeDetails employeeDetails)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var incomeTax = incomeTaxCalculator.Calculate(employeeDetails.AnnualSalary);
            var grossIncome = CalculateGrossIncome(employeeDetails.AnnualSalary);

            return new PaySlip()
            {
                Name = $"{employeeDetails.FirstName} {employeeDetails.Surname}",
                PayPeriod = employeeDetails.PaymentPeriod,
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                NetIncome = grossIncome - incomeTax,
                Super = CalculateSuper(employeeDetails.SuperRate, grossIncome)
            };
        }

        private static int CalculateGrossIncome(int annualSalary)
        {
            return annualSalary / MonthsInYear;
        }

        private static decimal CalculateSuper(decimal superRate, int grossIncome)
        {
            return Math.Round(grossIncome * (superRate / 100), MidpointRounding.AwayFromZero);
        }
    }
}