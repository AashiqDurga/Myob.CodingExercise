using System;
using Myob.CodingExercise.CsvParser;
using Myob.CodingExercise.IncomeTax;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class IncomeTaxCalculatorTests
    {
        private IncomeTaxCalculator _incomeTaxCalculator;

        [SetUp]
        public void SetUp()
        {
           _incomeTaxCalculator = new IncomeTaxCalculator();
        }

        [Test]
        [TestCase(5000, 0)]
        [TestCase(20000, 29)]
        [TestCase(60050, 922)]
        [TestCase(120000, 2696)]
        [TestCase(300000, 9046)]
        public void GivenAnAnnualSalary_CalculateTheMonthlyIncomeTax(int annualSalary, int expectedResult)
        {
            var result = _incomeTaxCalculator.Calculate(annualSalary);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GivenAnAnnualSalary_WhenTheSalaryIsLessThanZero_ThenThrowAnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _incomeTaxCalculator.Calculate(-1));
        }
    }
}