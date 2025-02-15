using Microsoft.AspNetCore.Mvc;

namespace Task_management.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IICompanyInformation iCompanyInformation;
        IIHomeBackgroundimage iHomeBackgroundimage;
        public CheckOutController(ILogger<HomeController> logger, IICompanyInformation iCompanyInformation1, IIHomeBackgroundimage iHomeBackgroundimage1)
        {
            _logger = logger;
            iCompanyInformation = iCompanyInformation1;
            iHomeBackgroundimage = iHomeBackgroundimage1;
        }
        public IActionResult MYCheckOut()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();
            return View(vmodel);
        }
        public IActionResult MYCheckOutAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll();
            vmodel.ListHomeBackgroundimage = iHomeBackgroundimage.GetAll().Take(1).ToList();
            return View(vmodel);
        }
    }
}
