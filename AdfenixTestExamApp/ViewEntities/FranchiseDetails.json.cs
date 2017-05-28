using AdfenixTestExamApp.Core;
using AdfenixTestExamApp.DataAccess;
using Starcounter;
using System;

namespace AdfenixTestExamApp.ViewEntities
{
    partial class FranchiseDetails : Json, IBound<Franchise>
    {
        protected override void OnData()
        {
            base.OnData();

            this.CoporationKey = this.Data.Corporation.GetObjectID();
        }

        static FranchiseDetails()
        {
            DefaultTemplate.Sales.ElementType.InstanceType = typeof(SalesList);
        }

        void Handle(Input.SaveSettingTrigger action)
        {
            Transaction.Commit();
        }

        void Handle(Input.SaveRegisterTrigger action)
        {
            var franchiseService = new FranchiseService();
            var franchise = franchiseService.GetFranchiseById(this.Data.GetObjectID());

            Db.Transact(() =>
            {
                var home = new Home()
                {
                    Franchise = franchise,
                    Street = this.HomeStreet,
                    Number = this.Number,
                    City = this.City,
                    Country = this.Country
                };
                new Sale()
                {
                    Home = home,
                    Franchise = franchise,
                    Commission = this.Commission,
                    Price = this.Price,
                    SalesDate = DateTime.Parse(this.SalesDate)
                };
            });

            Transaction.Commit();
        }
    }
}
