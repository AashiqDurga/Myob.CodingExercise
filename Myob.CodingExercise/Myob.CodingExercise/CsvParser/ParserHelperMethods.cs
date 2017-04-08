using System;
using System.Linq;

namespace Myob.CodingExercise.CsvParser
{
    public class ParserHelperMethods
    {
        public static decimal GetValidPercentAsDeciamal(string percentageWithSymbol)
        {
            var superRatePercentage = Convert.ToDecimal(percentageWithSymbol.Split('%').First());

            ValidateSuperRateIsInRange(superRatePercentage);

            return superRatePercentage;
        }

        private static void ValidateSuperRateIsInRange(decimal superRatePercentage)
        {
            if (superRatePercentage < 0 || superRatePercentage > 50)
                throw new ArgumentOutOfRangeException(nameof(superRatePercentage));
        }
    }
}