namespace Myob.CodingExercise.IncomeTax
{
    public class TaxBracket
    {
        public TaxBracket()
        {
            Surplus = 0;
            CentsPerDollar = 0m;
            Threshold = 0;
        }
        public int Surplus { get; set; }
        public decimal CentsPerDollar { get; set; }
        public int Threshold { get; set; }
    }
}