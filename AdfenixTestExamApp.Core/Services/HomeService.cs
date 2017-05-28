using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public class HomeService : IHomeService
    {
        public long GetTotalHomeSold(Franchise franchise)
        {
            return Db.SQL<long>("SELECT COUNT(home.Number) FROM HOME home WHERE home.Franchise =?", franchise).First;
        }
    }
}
