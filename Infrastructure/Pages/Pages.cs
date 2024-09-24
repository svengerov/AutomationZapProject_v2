
using Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infra.Pages
{
    public class Pages
    {
        private static LoginPage _loginPage;
        public static LoginPage loginPage => _loginPage ?? (_loginPage = new LoginPage());
        //public static   AdminPage getAdminPage()
        //{
        //    if( _adminPage == null )
        //    {
        //        _adminPage = new AdminPage();
        //    }
        //    return _adminPage;
        //}

      
        private static TrainSearchPage _trainSearchPage;
        public static TrainSearchPage trainSearchPage => _trainSearchPage ?? (_trainSearchPage = new TrainSearchPage());

        private static ParallelTestPage _parallelPage;
        public static ParallelTestPage parallelPage => _parallelPage ?? (_parallelPage = new ParallelTestPage());

        private static ZapPage _zapPage;
        public static ZapPage zapPage => _zapPage ?? (_zapPage = new ZapPage());

        private static GooglePage _googlePage;
        public static GooglePage googlePage => _googlePage ?? (_googlePage = new GooglePage());

        private static ProductPage _productPage;
        public static ProductPage productPage => _productPage ?? (_productPage = new ProductPage());

        private static DrierPage _drierPage;
        public static DrierPage drierPage => _drierPage ?? (_drierPage = new DrierPage());

        private static HeadphonesPage _headphonesPage;
        public static HeadphonesPage headphonesPage => _headphonesPage ?? (_headphonesPage = new HeadphonesPage());

        private static LaptopPage _laptopPage;
        public static LaptopPage laptopPage => _laptopPage ?? (_laptopPage = new LaptopPage());

        private static HddPage _hddPage;
        public static HddPage hddPage => _hddPage ?? (_hddPage = new HddPage());

        private static TelescopesPage _telescopesPage;
        public static TelescopesPage telescopesPage => _telescopesPage ?? (_telescopesPage = new TelescopesPage());

    }

  
}
