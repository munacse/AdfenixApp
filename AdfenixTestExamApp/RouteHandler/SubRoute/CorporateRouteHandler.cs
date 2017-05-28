using AdfenixTestExamApp.Core;
using AdfenixTestExamApp.DataAccess;
using AdfenixTestExamApp.ViewEntities;
using Starcounter;

namespace AdfenixTestExamApp
{
    public class CorporateRouteHandler : ICorporateRouteHandler
    {
        private readonly ICorporationService _corporationService;
        public CorporateRouteHandler()
        {
            this._corporationService = new CorporationService();
        }

        public void RegisterSub()
        {
            Corporation();

            CorporationById();
        }

        private void Corporation()
        {
            Handle.GET("/AdfenixTestExamApp", () =>
            {
                return Db.Scope(() =>
                {
                    var corporation = new Corporation()
                    {
                        Name = ""
                    };
                    var json = new CorporationCreate()
                    {
                        Data = corporation
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

        private void CorporationById()
        {
            Handle.GET("/AdfenixTestExamApp/Corporation/{?}", (string key) =>
            {
                return Db.Scope(() =>
                {
                    var corporation = this._corporationService.GetCorporationById(key);
                    var json = new CorporationCreate()
                    {
                        Data = corporation
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
