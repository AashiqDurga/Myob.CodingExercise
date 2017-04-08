using System;
using Myob.CodingExercise.CsvParser;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class CsvParserTests
    {
        private Parser _csvParser;

        [SetUp]
        public void SetUp()
        {
            _csvParser = new Parser();
        }

        [TestCase("David,Rudd,60050,9%,01 March – 31 March")]
        public void GivenAVaildCsv_CanParseLineToEmployeeObject(string csvLine)
        {
            var result = _csvParser.Parse(csvLine);

            Assert.That(result.FirstName, Is.EqualTo("David"));
            Assert.That(result.Surname, Is.EqualTo("Rudd"));
            Assert.That(result.AnnualSalary, Is.EqualTo(60050));
            Assert.That(result.SuperRate, Is.EqualTo(9m));
            Assert.That(result.PaymentPeriod, Is.EqualTo("01 March – 31 March"));
        }

        [TestCase("9%",9)]
        [TestCase("25%",25)]
        public void GivenAValidPercentage_ReturnTheDecimal(string valueUnderTest, decimal expecteDecimal)
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
