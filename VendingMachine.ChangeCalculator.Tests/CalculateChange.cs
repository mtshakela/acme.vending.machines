using VendingMachineChangeCalculator.Domains;

namespace VendingMachineChangeCalculator.Tests
{
    public class CalculateChange
    {
        [Fact]
        public void Should_Return_IntArray_That_Sum_To_65_Cents()
        {
            var coinDenominations = new int[4] { 1, 5, 10, 25 };
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = 1.35m; // amount the item cost
            var tenderAmount = 2m; // amount the user input for the purchase
            var result = machine.CalculateChange(purchaseAmount,tenderAmount);

            Assert.Equal(65, result.Sum());
        }

        [Fact]
        public void Should_Return_No_Change()
        {
            var coinDenominations = new int[4] { 1, 5, 10, 25 };
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = 2m; // amount the item cost
            var tenderAmount = 2m; // amount the user input for the purchase
            var result = machine.CalculateChange(purchaseAmount, tenderAmount);

            Assert.Equal(0, result.Sum());
        }
    }
}