using Microsoft.AspNetCore.Mvc;

namespace Task_management.Controllers
{
	public class ShopController : Controller
	{
		private readonly ILogger<HomeController> _logger;


		IIPhotoHomeSliderContent iPhotoHomeSliderContent;
		IIHomeSliderContent iHomeSliderContent;
		IICompanyInformation iCompanyInformation;
        IIHomeBackgroundimage iHomeBackgroundimage;
        public ShopController(ILogger<HomeController> logger, IIPhotoHomeSliderContent iPhotoHomeSliderContent1, IIHomeSliderContent iHomeSliderContent1,IICompanyInformation iCompanyInformation1,IIHomeBackgroundimage iHomeBackgroundimage1)
        {
			_logger = logger;
			iPhotoHomeSliderContent = iPhotoHomeSliderContent1;
			iHomeSliderContent = iHomeSliderContent1;
			iCompanyInformation = iCompanyInformation1;
            iHomeBackgroundimage= iHomeBackgroundimage1;

        }
        public IActionResult MyShop()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListViewPhotoHomeSliderContent = iPhotoHomeSliderContent.GetAll();
			vmodel.ListHomeSliderContent = iHomeSliderContent.GetAll();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();

            return View(vmodel);
		}   
		public IActionResult MyShopAr()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListViewPhotoHomeSliderContent = iPhotoHomeSliderContent.GetAll();
			vmodel.ListHomeSliderContent = iHomeSliderContent.GetAll();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();

            return View(vmodel);
		}
	}
}
