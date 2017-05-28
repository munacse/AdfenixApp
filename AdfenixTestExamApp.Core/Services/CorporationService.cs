using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public class CorporationService : ICorporationService
    {
        public QueryResultRows<Corporation> GetAllCorporates()
        {
            return Db.SQL<Corporation>("SELECT corporation FROM Corporation corporation");
        }

        public Corporation GetCorporationById(string key)
        {
            return Db.SQL<Corporation>("SELECT corporation FROM Corporation corporation WHERE corporation.ObjectId=?", key).First;
        }

    }
}
