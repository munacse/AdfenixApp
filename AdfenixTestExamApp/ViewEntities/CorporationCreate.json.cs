using AdfenixTestExamApp.Core;
using Starcounter;
using System.Linq;

namespace AdfenixTestExamApp.ViewEntities
{
    partial class CorporationCreate : Json
    {
        private ICorporationService _corporationService;
        protected override void OnData()
        {
            base.OnData();
            this._corporationService = new CorporationService();
            InitiateAllCorporates();
        }

        static CorporationCreate()
        {
            DefaultTemplate.Corporates.ElementType.InstanceType = typeof(CorporationList);
        }

        void Handle(Input.SaveCorporationTrigger action)
        {
            Transaction.Commit();
            InitiateAllCorporates();
        }

        private void InitiateAllCorporates()
        {
            this.Corporates = this._corporationService.GetAllCorporates();

            this.IsShowCorporateList = this.Corporates.Where(item => !string.IsNullOrEmpty(item.Name)).ToList().Count > 0;
        }
    }
}
