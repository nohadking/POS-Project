

using Domin.Entity;
using Infarstuructre.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
		private readonly RoleManager<IdentityRole> _roleManager;
		IIUserInformation iUserInformation;
		IICompanyInformation iCompanyInformation;
		IIInvose iInvose;
		IIPurchase iPurchase;
		IIExpense iExpense;
		IISupplier iSupplier;
		IIUserService iUserService;

		public HomeController(UserManager<ApplicationUser> userManager,  MasterDbcontext dbcontext1,  IIUserInformation iUserInformation1, IICompanyInformation iCompanyInformation1,IIInvose iInvose1,IIPurchase iPurchase1,IIExpense iExpense1,IISupplier iSupplier1, RoleManager<IdentityRole> roleManager, IIUserService iUserService1)
		{
			_userManager = userManager;
			iUserInformation = iUserInformation1;
			iCompanyInformation = iCompanyInformation1;
			iInvose = iInvose1;
			iPurchase = iPurchase1;
			iExpense = iExpense1;
			iSupplier= iSupplier1;
			_roleManager = roleManager;
			iUserService = iUserService1;
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


			var TotalPrchaase=vmodel.ListViewPurchase= iPurchase.GetAll();
			var allPrchaase = TotalPrchaase.Sum(a => a.TotalAll);
			ViewBag.totaallpurches = allPrchaase;


			var maxpurshess = TotalPrchaase.DefaultIfEmpty(new TBViewPurchase { PurchaseNumber = 0 }).Max(a => a.PurchaseNumber);
			ViewBag.maxpurs = maxpurshess > 0 ? maxpurshess : 1;




			var exching=vmodel.ListViewExpense= iExpense.GetAll();
			var totalexchinh = exching.Sum(a => a.Amount);
			ViewBag.totalExch = totalexchinh;

			//جلب عدد الموردين 

			var supler=vmodel.ListViewSupplier= iSupplier.GetAll();
			var contSuplaer= supler.Count();
			ViewBag.contsupler = contSuplaer;

			//جلب  عدد العملاء

			var contcus= iUserInformation.GetAllByRole("Customer");
			var totalcontcu= contcus.Count();
			ViewBag.cont = totalcontcu;
			var online= iUserService.GetActiveCustomers();











			var onnn = online
			.GroupBy(item => item.Id) // افترضنا أن هناك ProductId لكل منتج
			.Select(group => new
			{
				ProductId = group.Key,
				name = group.FirstOrDefault().Name, // تأكد أن المنتج يحتوي على اسم
				email = group.FirstOrDefault().Email, // تأكد أن المنتج يحتوي على اسم
				PhoneNumber = group.FirstOrDefault().PhoneNumber, // تأكد أن المنتج يحتوي على اسم
			 // حساب إجمالي الكمية المباعة لكل منتج (افترض أن الكمية مخزنة في 'Quantity')
				ProductImage = group.FirstOrDefault().ImageUser // إضافة صورة المنتج
			})
			.OrderByDescending(item => item.name) // ترتيب الأصناف حسب إجمالي المبيعات
			/*.Take(10)*/ // عرض الأصناف الخمسة الأكثر مبيعًا
			.ToList();

			ViewBag.onlineuser = onnn;












			return View(vmodel);


		}


		[AllowAnonymous]
		public IActionResult Denied()
        {
            return View();
        }
    }
}
