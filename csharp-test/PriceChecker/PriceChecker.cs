using System;
using System.Collections.Generic;

namespace PriceChecker
{
    public class PriceChecker
	{
		/// <summary>
		/// Application COLT reads prices in application MSD, between 2 dates and a given product id.
		/// At one date and for a product id, we have 0 to n prices and these prices can be official or not.
		/// To have an indicator on price quality and for monitoring purpose, COLT has a control that counts number of dates with more that n official prices by date.
		/// </summary>
		/// <returns>
		/// The number of dates with at least n official prices.
		/// </returns>
		/// <param name="prices">Input prices coming from MSD.</param>
		/// <param name="n">The threshold on number of prices.</param>
		public int CheckPrices(List<PriceDto> prices, int n)
		{
		    	//body to add
		    	int count = 0;

			// first choice
			var datesList = prices.Where(x => x.IsOfficial);
			var dates = datesList.GroupBy(x => x.Date);
			
			foreach (var date in dates)
			{
				if (date.Count() > n)
				{
					count++;
				}
			}			

			// second choice
			count = prices
				.Where(price => price.IsOfficial)
				.GroupBy(groupPrices => groupPrices.Date)
				.Where(pricesCount => pricesCount.Count() > n)
				.Count();

		    return count;
		}
	}

	public class PriceDto
	{
		public long ProductId { get; set; }
		public DateTime Date { get; set; }
		public bool IsOfficial { get; set; }
		public double Value { get; set; }
	}
}

