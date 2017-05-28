using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.ViewEntities
{
    partial class SalesList : Json, IBound<Sale>
    {
        protected override void OnData()
        {
            base.OnData();
            this.Address = this.Data.Home.Address;
        }
    }
}
