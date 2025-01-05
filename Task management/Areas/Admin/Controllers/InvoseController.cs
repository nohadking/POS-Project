

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InvoseController : Controller
    {
        IIInvose iInvose;
        public InvoseController(IIInvose iInvose1)
        {
            iInvose=iInvose1;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
