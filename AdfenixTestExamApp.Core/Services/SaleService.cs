using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public class SaleService : ISaleService
    {
        public long GetTotalCommission(Franchise franchise)
        {
            return Db.SQL<long>("SELECT SUM(sale.Commission) FROM Sale sale WHERE sale.Franchise =?", franchise).First;
        }

        public QueryResultRows<Sale> GetSaleFranchiseOrderDate(Franchise franchise)
        {
            return Db.SQL<Sale>("SELECT sale FROM Sale sale WHERE sale.Franchise =? ORDER BY sale.SalesDate", franchise);
        }

        public QueryResultRows<Sale> GetSaleByFranchise(Franchise franchise)
        {
            return Db.SQL<Sale>("SELECT sale FROM Sale sale WHERE sale.Franchise =?", franchise);
        }
    }
}
