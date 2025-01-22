

using Infarstuructre.BL;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Immutable;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
	
		IIUserInformation iUserInformation;
		IICompanyInformation iCompanyInformation;
		IIInvose iInvose;

        public HomeController(UserManager<ApplicationUser> userManager,  MasterDbcontext dbcontext1,  IIUserInformation iUserInformation1, IICompanyInformation iCompanyInformation1,IIInvose iInvose1)
		{
			_userManager = userManager;
			iUserInformation = iUserInformation1;
			iCompanyInformation = iCompanyInformation1;
			iInvose = iInvose1;
        }

		public async Task<IActionResult> Index(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			//vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			var userd = vmodel.sUser = iUserInformation.GetById(userId);

			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();
			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserRole = role.FirstOrDefault();



			// جلب البيانات من الـ View أو من المصدر المطلوب
			var total = vmodel.ListViewInvose = iInvose.GetAll();
			// حساب المجموع من القائمة أو قاعدة البيانات
			var totalAmount = total.Sum(a => a.total);
			ViewBag.TotalAmount = totalAmount;


			// حساب الأصناف الأكثر مبيعًا وعدد المبيعات
			var topSellingItems = total
				.GroupBy(item => item.IdProduct) // افترضنا أن هناك ProductId لكل منتج
				.Select(group => new
				{
					ProductId = group.Key,
					ProductName = group.FirstOrDefault().ProductNameAr, // تأكد أن المنتج يحتوي على اسم
					TotalSales = group.Sum(item => item.total), // حساب مجموع المبيعات لكل منتج
					SalesCount = group.Sum(item => item.Quantity), // حساب إجمالي الكمية المباعة لكل منتج (افترض أن الكمية مخزنة في 'Quantity')
					ProductImage = group.FirstOrDefault().Photo // إضافة صورة المنتج
				})
				.OrderByDescending(item => item.SalesCount) // ترتيب الأصناف حسب إجمالي المبيعات
				/*.Take(10)*/ // عرض الأصناف الخمسة الأكثر مبيعًا
				.ToList();

			ViewBag.TopSellingItems = topSellingItems;
			// إضافة الأصناف الأكثر مبيعًا إلى ViewBag

			//إجمالي الكمية المباعة 
			var Quantity = total.Sum(a => a.Quantity);
			ViewBag.Quantity = Quantity;


			var maxnomb = total.Max(a => a.InvoiceNumber);
			ViewBag.max = maxnomb;
			return View(vmodel);
		}


		[AllowAnonymous]
		public IActionResult Denied()
        {
            return View();
        }
    }
}
