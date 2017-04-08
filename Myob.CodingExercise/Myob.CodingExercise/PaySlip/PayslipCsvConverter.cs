using System.Globalization;

namespace Myob.CodingExercise.PaySlip
{
    public class PayslipCsvConverter
    {
        public string ConvertToCsv(PaySlip payslip)
        {
            return string.Join(",", ConvertPayslipToArray(payslip));
        }

        private static string[] ConvertPayslipToArray(PaySlip payslip)
        {
            return new[]
            {
                payslip.Name,
                payslip.PayPeriod,
                payslip.GrossIncome.ToString(CultureInfo.InvariantCulture),
                payslip.IncomeTax.ToString(CultureInfo.InvariantCulture),
                payslip.NetIncome.ToString(CultureInfo.InvariantCulture),
                payslip.Super.ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}