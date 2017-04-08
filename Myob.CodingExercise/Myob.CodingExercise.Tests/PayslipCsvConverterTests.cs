using Myob.CodingExercise.PaySlip;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class PayslipCsvConverterTests
    {
        private PayslipCsvConverter _payslipCsvConverter;

        [SetUp]
        public void SetUp()
        {
            _payslipCsvConverter = new PayslipCsvConverter();
        }

        [Test]
        public void GivenAPayslipObject_OutputACsvLine()
        {
            var payslip = CreatePayslip();
            var result = _payslipCsvConverter.ConvertToCsv(payslip);

            Assert.That(result, Is.EqualTo("David Rudd,01 March – 31 March,5004,922,4082,450"));
        }

        private static PaySlip.PaySlip CreatePayslip()
        {
            return new PaySlip.PaySlip { GrossIncome = 5004, IncomeTax = 922, Name = "David Rudd", NetIncome = 4082, PayPeriod = "01 March – 31 March", Super = 450 };
        }
    }
}