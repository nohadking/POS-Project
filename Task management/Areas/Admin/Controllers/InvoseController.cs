

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
            iInvose = iInvose1;
            iCompanyInformation = iCompanyInformation1;
        }
        public IActionResult MyInvose()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewInvose = iInvose.GetAll();
            // جلب جميع البيانات
            var allInvoices = iInvose.GetAll();

            // استخراج أسماء مدخلي البيانات بدون تكرار
            var uniqueCashers = allInvoices.Select(i => i.DataEntry).Distinct().ToList();

            // تمرير البيانات إلى ViewBag
            ViewBag.CasherName = uniqueCashers;
            //طرق الدفع
            var PymentMoted = allInvoices.Select(i => i.PaymentMethodAr).Distinct().ToList();
            ViewBag.PayMoTh = PymentMoted;


           //تاريخ الفاتورة 
            var distinctDates = allInvoices
            .Select(i => i.DateTimeEntry.Date).Distinct().ToList();
            ViewBag.dateTai = distinctDates;
            return View(vmodel);
        }
    }
}
