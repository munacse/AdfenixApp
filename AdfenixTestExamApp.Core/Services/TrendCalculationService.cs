using AdfenixTestExamApp.DataAccess;
using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdfenixTestExamApp.Core
{
    public class TrendCalculationService : ITrendCalculationService
    {
        public long Calculate(QueryResultRows<Sale> sales)
        {
            decimal weight = .01m;
            var tredItem = CreateTrendItem(sales);

            var averageSlope = GetAverageSlopeCalculation(tredItem);

            return Convert.ToInt64(averageSlope * weight);
        }

        private IEnumerable<TrendPocoItem> CreateTrendItem(QueryResultRows<Sale> sales)
        {
            var salesDate = sales.Any() ? sales.Min(s => s.SalesDate) : DateTime.Today;

            var trendItem = sales.GroupBy(date => date.SalesDate).Select(item => new TrendPocoItem()
            {
                Horizontal = (item.Key - salesDate).Days,
                Vertical = item.Sum(c => c.Commission)
            });
            return trendItem;
        }

        private decimal GetAverageSlopeCalculation(IEnumerable<TrendPocoItem> trendItems)
        {
            var slopes = new List<decimal>();
            var counter = 1;
            var previousValue = new TrendPocoItem();

            foreach (var value in trendItems)
            {
                if(counter == 1)
                {
                    previousValue = value;
                    ++counter;
                    continue;
                }

                var horizontal1 = previousValue.Horizontal;
                var vertical1 = previousValue.Vertical;
                var horizontal2 = value.Horizontal;
                var vertical2 = value.Vertical;
                var slope = 0m;

                var differentHorizontal = Math.Abs(horizontal2 - horizontal1);
                if(differentHorizontal != 0)
                {
                    slope = (vertical2 - vertical1) / (decimal)differentHorizontal;
                }
                slopes.Add(slope);

                previousValue = value;
                ++counter;
            }
            return slopes.Count > 0 ? slopes.Average() : 0m;
        }
    }
}
