using System;
using Myob.CodingExercise.Employee;
using Myob.CodingExercise.IncomeTax;

namespace Myob.CodingExercise.PaySlip
{
    public class PayslipGenerator
    {
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
                Super = Math.Round(grossIncome * (employeeDetails.SuperRate / 100), MidpointRounding.AwayFromZero)
            };
        }

        private static int CalculateGrossIncome(int annualSalary)
        {
            return annualSalary / 12;
        }
    }
}