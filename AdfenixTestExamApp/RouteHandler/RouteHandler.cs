using Starcounter;

namespace AdfenixTestExamApp
{
    public class RouteHandler : IRouteHandler
    {
        private readonly ICorporateRouteHandler _corporateRouteHandler;
        private readonly IFranchiseRouteHandler _franchiseRouteHandler;

        public RouteHandler()
        {
            this._corporateRouteHandler = new CorporateRouteHandler();
            this._franchiseRouteHandler = new FranchiseRouteHandler();
       
        }
        public void RegisterRoute()
        {
            AddMiddleWare();

            this._corporateRouteHandler.RegisterSub();

            this._franchiseRouteHandler.RegisterSub();
        }

        private void AddMiddleWare()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());
        }
    }
}
