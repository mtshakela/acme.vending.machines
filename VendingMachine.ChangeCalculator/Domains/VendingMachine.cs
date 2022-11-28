namespace VendingMachineChangeCalculator.Domains
{
    public class VendingMachine
    {
        public int[] CoinDenominations { get; private set; }
        public VendingMachine() { CoinDenominations = Array.Empty<int>(); }
        public VendingMachine(int[] coinDenominations) {
            CoinDenominations = coinDenominations;
        }
        /// <summary>
        /// Calculates the change in cents
        /// </summary>
        /// <param name="purchaseAmount"></param>
        /// <param name="tenderAmount"></param>
        /// <returns></returns>
        public int[] CalculateChange(decimal purchaseAmount, decimal tenderAmount) {
        
           
            if (tenderAmount <= purchaseAmount) return Array.Empty<int>();
            var change = new List<int>();

            var amountDifference = tenderAmount - purchaseAmount;

            var changeInCents = ConvertToCents(amountDifference);

            foreach (var coin in CoinDenominations.OrderByDescending(x=>x))
            {
                if (changeInCents <= 0) break;
                var value = changeInCents / coin;
                change.AddRange(Enumerable.Range(0, value).Select(i => coin));
                changeInCents -= coin * value;
            }
            return change.ToArray();
        }

        /// <summary>
        /// Converts amount into cents
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static int ConvertToCents(decimal amount)
        {
            return (int)(amount * 100);
        }
    }
}
