using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public interface ISaleService
    {
        long GetTotalCommission(Franchise franchise);

        QueryResultRows<Sale> GetSaleFranchiseOrderDate(Franchise franchise);

        QueryResultRows<Sale> GetSaleByFranchise(Franchise franchise);
    }
}
