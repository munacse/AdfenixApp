using AdfenixTestExamApp.Core;
using Starcounter;

namespace AdfenixTestExamApp.ViewEntities
{
    partial class FranchiseList : Json
    {
        private IFranchiseService _franchiseService;
        protected override void OnData()
        {
            base.OnData();
            this.Key = this.Data.GetObjectID();
            this._franchiseService = new FranchiseService();

            var franchise = this._franchiseService.GetFranchiseById(this.Key);
            this.TotalHomeSold = this._franchiseService.GetFranchiseTotalHomeSold(franchise);
            this.TotalCommission = this._franchiseService.GetFranchiseTotalCommission(franchise);
            this.AverageCommission = this._franchiseService.GetFranchiseAverageCommission(franchise);
            this.Trend = this._franchiseService.GetTrandByFranchise(franchise);
        }
    }
}
