using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.Core
{
    public interface ITrendCalculationService
    {
        long Calculate(QueryResultRows<Sale> sales);
    }
}
