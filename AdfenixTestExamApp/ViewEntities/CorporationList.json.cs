using AdfenixTestExamApp.DataAccess;
using Starcounter;

namespace AdfenixTestExamApp.ViewEntities
{
    partial class CorporationList : Json
    {
        protected override void OnData()
        {
            base.OnData();
            var a = this.Name;
            var f = this.Franchises;
        }
        static CorporationList()
        {
            DefaultTemplate.Franchises.ElementType.InstanceType = typeof(FranchiseList);
        }

        void Handle(Input.FranchiseSaveTrigger action)
        {
            new Franchise()
            {
                Corporation = this.Data as Corporation,
                Name = this.NewFranchiseName
            };
            Transaction.Commit();
        }
    }
}
