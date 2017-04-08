using System;
using Myob.CodingExercise.CsvParser;
using Myob.CodingExercise.PaySlip;

namespace Myob.CodingExercise
{
    class Program
    {
        private static readonly Parser CsvParser;
        private static readonly PayslipGenerator PayslipPaySlipGenerator;
        private static readonly PayslipCsvConverter PayslipCsvConverter;

        static Program()
        {
            CsvParser = new Parser();
            PayslipPaySlipGenerator = new PayslipGenerator();
            PayslipCsvConverter = new PayslipCsvConverter();
        }

        static void Main(string[] args)
        {
            const string csv = "Ryan,Chen,120000,10%,01 March – 31 March";

            var employeeDetails = CsvParser.Parse(csv);
            var payslip = PayslipPaySlipGenerator.Generate(employeeDetails);
            var payslipCsv = PayslipCsvConverter.ConvertToCsv(payslip);

            Console.WriteLine(payslipCsv);
            Console.ReadLine();
        }
    }
}
