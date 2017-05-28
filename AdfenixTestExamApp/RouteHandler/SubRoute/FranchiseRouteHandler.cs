using AdfenixTestExamApp.Core;
using AdfenixTestExamApp.ViewEntities;
using Starcounter;

namespace AdfenixTestExamApp
{
    public class FranchiseRouteHandler : IFranchiseRouteHandler
    {
        private readonly IFranchiseService _franchiseService;
        public FranchiseRouteHandler()
        {
            this._franchiseService = new FranchiseService();
        }

        public void RegisterSub()
        {
            Franchises();
        }

        private void Franchises()
        {
            Handle.GET("/AdfenixTestExamApp/Franchise/{?}", (string key) =>
            {
                return Db.Scope(() =>
                {

                    var franchise = this._franchiseService.GetFranchiseById(key);
                    var json = new FranchiseDetails()
                    {
                        Data = franchise
                    };

                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    return json;
                });

            });
        }
    }
}
