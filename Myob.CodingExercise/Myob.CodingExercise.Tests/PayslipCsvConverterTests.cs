using Myob.CodingExercise.PaySlip;
using NUnit.Framework;

namespace Myob.CodingExercise.Tests
{
    [TestFixture]
    public class PayslipCsvConverterTests
    {
        [Test]
        public void GivenAPayslipObject_OutputACsvLine()
        {
            var payslip = new PaySlip.PaySlip { GrossIncome = 5004, IncomeTax = 922, Name = "David Rudd", NetIncome = 4082, PayPeriod = "01 March – 31 March", Super = 450 };
            var payslipCsvConverter = new PayslipCsvConverter();

            var result = payslipCsvConverter.ConvertToCsv(payslip);

            Assert.That(result, Is.EqualTo("David Rudd,01 March – 31 March,5004,922,4082,450"));
        }
    }
}