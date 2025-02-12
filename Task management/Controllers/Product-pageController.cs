

namespace Task_management.Controllers
{
    public class Product_pageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IICompanyInformation iCompanyInformation;
        IICategory iCategory;
        IIProduct iProduct;
        IIHomeBackgroundimage iHomeBackgroundimage;
        public Product_pageController(ILogger<HomeController> logger, IICompanyInformation iCompanyInformation1, IICategory iCategory1, IIProduct iProduct1,IIHomeBackgroundimage iHomeBackgroundimage1)
        {
            _logger = logger;
            iCompanyInformation = iCompanyInformation1;
            iCategory = iCategory1;
            iProduct = iProduct1;   
            iHomeBackgroundimage = iHomeBackgroundimage1;

        }
        public IActionResult MYProduct(int ProductId)
        {

            //https://localhost:7102/Product_page/MYProduct
     

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
           
     
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
   
      
            vmodel.ListCategory = iCategory.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();
            vmodel.Productsng = iProduct.GetByIdview(ProductId);









            return View(vmodel);
        }  
        public IActionResult MYProductAr(int ProductId)
        {

            //https://localhost:7102/Product_page/MYProduct
     

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();          
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
   
      
            vmodel.ListCategory = iCategory.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();
            vmodel.Productsng = iProduct.GetByIdview(ProductId);








            return View(vmodel);
        }
    }
}
