using System;
using Myob.CodingExercise.CsvParser;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class CsvParserTests
    {
        [Test]
        public void GivenAVaildCsv_CanParseLineToEmployeeObject()
        {
            const string csvLine = "David,Rudd,60050,9%,01 March – 31 March";

            var csvParser = new Parser();
            var result = csvParser.Parse(csvLine);

            Assert.That(result.FirstName, Is.EqualTo("David"));
            Assert.That(result.Surname, Is.EqualTo("Rudd"));
            Assert.That(result.AnnualSalary, Is.EqualTo(60050));
            Assert.That(result.SuperRate, Is.EqualTo(9m));
            Assert.That(result.PaymentPeriod, Is.EqualTo("01 March – 31 March"));
        }

        [Test]
        [TestCase("9%",9)]
        [TestCase("25%",25)]
        public void GivenAValidPercentageReturnTheDecimal(string valueUnderTest, decimal expecteDecimal)
        {
            Assert.That(ParserHelperMethods.GetValidPercentAsDeciamal(valueUnderTest), Is.EqualTo(expecteDecimal));
        } 

        [Test]
        [TestCase("51%")]
        [TestCase("100%")]
        public void GivenAInvalidPercentage_ThrowException(string valueUnderTest)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ParserHelperMethods.GetValidPercentAsDeciamal(valueUnderTest));
        }
    }
}
