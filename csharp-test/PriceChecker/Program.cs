using System;

namespace PriceChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var priceChecker = new PriceChecker();
			var minimumNumberOfPrices = 100;
			var numberOfDatesWithAtLeast100prices = priceChecker.CheckPrices(null, minimumNumberOfPrices);
			Console.WriteLine($"Number of dates with at least {minimumNumberOfPrices} prices : {numberOfDatesWithAtLeast100prices}.");
        }
    }
}
