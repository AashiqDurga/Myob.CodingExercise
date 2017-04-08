using System;
using System.Linq;

namespace Myob.CodingExercise.CsvParser
{
    public class ParserHelperMethods
    {
        private const int MinimumSuperRate = 0;
        private const int MaximumSuperRate = 50;
        public static decimal GetValidPercentAsDeciamal(string percentageWithSymbol)
        {
            var superRatePercentage = Convert.ToDecimal(percentageWithSymbol.Split('%').First());

            ValidateSuperRateIsInRange(superRatePercentage);

            return superRatePercentage;
        }

        private static void ValidateSuperRateIsInRange(decimal superRatePercentage)
        {
            if (superRatePercentage < MinimumSuperRate || superRatePercentage > MaximumSuperRate)
                throw new ArgumentOutOfRangeException(nameof(superRatePercentage));
        }
    }
}