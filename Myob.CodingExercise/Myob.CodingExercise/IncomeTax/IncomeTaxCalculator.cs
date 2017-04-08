using System;
using System.Collections.Generic;

namespace Myob.CodingExercise.IncomeTax
{
    public class IncomeTaxCalculator
    {
        public int Calculate(int annualSalary)
        {
            var taxBracket = FindTaxBracket(annualSalary);

            var monthlyIncomeTax = Math.Round(CalculateMonthlyIncomeTax(annualSalary, taxBracket), MidpointRounding.AwayFromZero);
            return (int)monthlyIncomeTax;
        }

        private static decimal CalculateMonthlyIncomeTax(int annualSalary, TaxBracket taxBracket)
        {
            return (taxBracket.Surplus + (annualSalary - taxBracket.Threshold) * (taxBracket.CentsPerDollar / 100)) / 12;
        }

        private static TaxBracket FindTaxBracket(int annualSalary)
        {
            if (annualSalary < 1)
                throw new ArgumentOutOfRangeException(nameof(annualSalary),"Annual salary cannot be less than 1");

            if (annualSalary < 18201)
                return new TaxBracket();

            if (annualSalary < 37001)
            {
                return new TaxBracket
                {
                    Surplus = 0,
                    CentsPerDollar = 19m,
                    Threshold = 18200
                };
            }

            if (annualSalary < 80001)
            {
                return new TaxBracket
                {
                    Surplus = 3572,
                    CentsPerDollar = 32.5m,
                    Threshold = 37000
                };
            }

            if (annualSalary < 180001)
            {
                return new TaxBracket
                {
                    Surplus = 17547,
                    CentsPerDollar = 37m,
                    Threshold = 80000
                };
            }

            return new TaxBracket
            {
                Surplus = 54547,
                CentsPerDollar = 45m,
                Threshold = 180000
            };
        }
    }
}