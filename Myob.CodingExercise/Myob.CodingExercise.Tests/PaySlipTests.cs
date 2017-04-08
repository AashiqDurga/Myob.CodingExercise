using Myob.CodingExercise.CsvParser;
using Myob.CodingExercise.PaySlip;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class PaySlipTests
    {
        private Parser _csvParser;
        private PayslipGenerator _payslipGenerator;

        [SetUp]
        public void SetUp()
        {
            _csvParser = new Parser();
            _payslipGenerator = new PayslipGenerator();
        }

        [TestCase("David,Rudd,60050,9%,01 March – 31 March")]
        public void GivenACsvline_GenerateAPayslip(string csvLine)
        {
            var employeeDetails = _csvParser.Parse(csvLine);

            var payslip = _payslipGenerator.Generate(employeeDetails);

            Assert.That(payslip.Name, Is.EqualTo("David Rudd"));
            Assert.That(payslip.PayPeriod, Is.EqualTo("01 March – 31 March"));
            Assert.That(payslip.GrossIncome, Is.EqualTo(5004));
            Assert.That(payslip.IncomeTax, Is.EqualTo(922));
            Assert.That(payslip.NetIncome, Is.EqualTo(4082));
            Assert.That(payslip.Super, Is.EqualTo(450));
        }
    }
}