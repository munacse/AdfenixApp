using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public interface ICorporationService
    {
        QueryResultRows<Corporation> GetAllCorporates();

        Corporation GetCorporationById(string key);
    }
}
