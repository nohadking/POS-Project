

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InvoseController : Controller
    {
        IIInvose iInvose;
		IICompanyInformation iCompanyInformation;
		public InvoseController(IIInvose iInvose1, IICompanyInformation iCompanyInformation1)
        {
            iInvose=iInvose1;
			iCompanyInformation = iCompanyInformation1;
		}
        public IActionResult Index()
        {
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			
			return View(vmodel);
		}
    }
}
