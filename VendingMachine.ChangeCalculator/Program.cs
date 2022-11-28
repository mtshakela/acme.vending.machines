using VendingMachineChangeCalculator.Domains;

namespace VendingMachineChangeCalculator;
class Program
{
    static void Main(string[] args)
    {
        
        if (args.Length == 0)
        {
            Console.WriteLine("Missing coin denominations list.");
            return;
        }
        int[] coinDenominations = args[0].Split(',').Select(x=>int.Parse(x)).ToArray();
        var machine = new VendingMachine(coinDenominations);
        var purchaseAmount = 0m;
        var tenderAmount = 0m;

        if (args.Length > 1)
        {
            if (!decimal.TryParse(args[1], out purchaseAmount))
            {
                Console.WriteLine("You provided invalid purchase amount.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Please enter purchase amount?");
            var input = Console.ReadLine();
            if (!decimal.TryParse(input, out purchaseAmount))
            {
                Console.WriteLine("You entered invalid purchase amount.");
                return;
            }
        }

        if (args.Length > 2)
        {
            if (!decimal.TryParse(args[1], out tenderAmount))
            {
                Console.WriteLine("You provided invalid tender amount.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Please enter tender amount?");
            var input = Console.ReadLine();
            
            if (!decimal.TryParse(input, out tenderAmount))
            {
                Console.WriteLine("You entered invalid tender amount.");
                return;
            }
        }

        Console.WriteLine();
        var changeCoins = machine.CalculateChange(purchaseAmount, tenderAmount);
        for(var i= 0; i<changeCoins.Length; i++)
        {
            Console.WriteLine("change[{0}] = {1}",i, changeCoins[i]);
        }
    }
}