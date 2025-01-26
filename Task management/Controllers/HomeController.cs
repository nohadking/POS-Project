using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_management.Models;

namespace Task_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        IIPhotoHomeSliderContent iPhotoHomeSliderContent;
        IIHomeSliderContent iHomeSliderContent;
        IIServiceSectionStartHomeContent iServiceSectionStartHomeContent;
        IIAboutSectionStartHomeContent iAboutSectionStartHomeContent;
        IICategoryServic iCategoryServic;
        IIBrandProduct iBrandProduct;
        IICompanyInformation iCompanyInformation;
        IIInvose iInvose;
        public HomeController(ILogger<HomeController> logger, IIPhotoHomeSliderContent iPhotoHomeSliderContent1, IIHomeSliderContent iHomeSliderContent1, IIServiceSectionStartHomeContent iServiceSectionStartHomeContent1, IIAboutSectionStartHomeContent iAboutSectionStartHomeContent1, IICategoryServic iCategoryServic1, IIBrandProduct iBrandProduct1,IICompanyInformation iCompanyInformation1,IIInvose iInvose1)
        {
            _logger = logger;
            iPhotoHomeSliderContent = iPhotoHomeSliderContent1;
            iHomeSliderContent = iHomeSliderContent1;
            iServiceSectionStartHomeContent = iServiceSectionStartHomeContent1;
            iAboutSectionStartHomeContent = iAboutSectionStartHomeContent1;
            iCategoryServic = iCategoryServic1;

            iBrandProduct = iBrandProduct1;
            iCompanyInformation= iCompanyInformation1;
            iInvose = iInvose1; 
        }

        public IActionResult Index()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPhotoHomeSliderContent = iPhotoHomeSliderContent.GetAll();
            vmodel.ListHomeSliderContent = iHomeSliderContent.GetAll();
            vmodel.ListServiceSectionStartHomeContent = iServiceSectionStartHomeContent.GetAll().Take(1).ToList();
            vmodel.ListAboutSectionStartHomeContent = iAboutSectionStartHomeContent.GetAll().Take(1).ToList();
            vmodel.ListCategoryServic = iCategoryServic.GetAll();
            vmodel.ListBrandProduct = iBrandProduct.GetAll();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();


            // جلب كل  المبيعا 
            var total = vmodel.ListViewInvose = iInvose.GetAll(); 
            var totalAmount = total.Sum(a => a.total);
            ViewBag.TotalAmount = totalAmount;
            //كود جلب الاكثر مبيعا 
            var topSellingItems = total
                .GroupBy(item => item.IdProduct) 
                .Select(group => new
                {
                    ProductId = group.Key,
                    ProductName = group.FirstOrDefault().ProductNameAr, 
                    TotalSales = group.Sum(item => item.total), 
                    SalesCount = group.Sum(item => item.Quantity), 
                    ProductImage = group.FirstOrDefault().Photo, 
                    Price = group.FirstOrDefault().price 
                                                               
                })
                .OrderByDescending(item => item.SalesCount) 
                //.Take(10)
                .ToList();

            ViewBag.TopSellingItems = topSellingItems;
          

            return View(vmodel);
        }
        public IActionResult IndexAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPhotoHomeSliderContent = iPhotoHomeSliderContent.GetAll();
            vmodel.ListHomeSliderContent = iHomeSliderContent.GetAll();
            vmodel.ListServiceSectionStartHomeContent = iServiceSectionStartHomeContent.GetAll().Take(1).ToList();
            vmodel.ListAboutSectionStartHomeContent = iAboutSectionStartHomeContent.GetAll().Take(1).ToList();
            vmodel.ListCategoryServic = iCategoryServic.GetAll();
            vmodel.ListBrandProduct = iBrandProduct.GetAll();



			// جلب كل  المبيعا 
			var total = vmodel.ListViewInvose = iInvose.GetAll();
			var totalAmount = total.Sum(a => a.total);
			ViewBag.TotalAmount = totalAmount;
			//كود جلب الاكثر مبيعا 
			var topSellingItems = total
				.GroupBy(item => item.IdProduct)
				.Select(group => new
				{
					ProductId = group.Key,
					ProductName = group.FirstOrDefault().ProductNameAr,
					TotalSales = group.Sum(item => item.total),
					SalesCount = group.Sum(item => item.Quantity),
					ProductImage = group.FirstOrDefault().Photo,
					Price = group.FirstOrDefault().price

				})
				.OrderByDescending(item => item.SalesCount)
				//.Take(10)
				.ToList();

			ViewBag.TopSellingItems = topSellingItems;

			return View(vmodel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
