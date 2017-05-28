using AdfenixTestExamApp.DataAccess;

namespace AdfenixTestExamApp.Core
{
    public interface IFranchiseService
    {
        Franchise GetFranchiseById(string key);

        long GetFranchiseTotalHomeSold(Franchise franchise);

        decimal GetFranchiseAverageCommission(Franchise franchise);

        long GetFranchiseTotalCommission(Franchise franchise);

        long GetTrandByFranchise(Franchise franchise);
    }
}
