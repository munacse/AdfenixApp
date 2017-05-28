using AdfenixTestExamApp.DataAccess;

namespace AdfenixTestExamApp.Core
{
    public interface IHomeService
    {
        long GetTotalHomeSold(Franchise franchise);
    }
}
