using AdfenixTestExamApp.DataAccess;
using Starcounter;
using System;
using System.Linq;

namespace AdfenixTestExamApp.Core
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IHomeService _homeService;
        private readonly ISaleService _saleService;
        private readonly ITrendCalculationService _trendCalculationService;

        public FranchiseService()
        {
            this._saleService = new SaleService();
            this._homeService = new HomeService();
            this._trendCalculationService = new TrendCalculationService();
        }
        public Franchise GetFranchiseById(string key)
        {
            return Db.SQL<Franchise>("SELECT franchise FROM Franchise franchise WHERE franchise.ObjectId =?", key).First;
        }

        public long GetFranchiseTotalHomeSold(Franchise franchise)
        {
            return this._homeService.GetTotalHomeSold(franchise);
        }

        public decimal GetFranchiseAverageCommission(Franchise franchise)
        {
            var sales =  this._saleService.GetSaleByFranchise(franchise);
            var average = sales.Count() > 0 ? sales.Select(item => (decimal)item.Commission).ToList().Average() : 0;
            return Math.Round(average, 2);
        }

        public long GetFranchiseTotalCommission(Franchise franchise)
        {
            return this._saleService.GetTotalCommission(franchise);
        }

        public long GetTrandByFranchise(Franchise franchise)
        {
            var sales = this._saleService.GetSaleFranchiseOrderDate(franchise);
            return this._trendCalculationService.Calculate(sales);
        }
    }
}
