using Infarstuructre.BL;
using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Cashier")]
    public class POSController : Controller
    {
        IICategory iCategory;
        IIProduct iProduct;
		IIInvoseHeder iInvoseHeder;
		IIUserInformation iUserInformation;
		IIPaymentMethod iPaymentMethod;
		public POSController(IICategory iCategory1,IIProduct iProduct1,IIInvoseHeder iInvoseHeder1, IIUserInformation iUserInformation1,IIPaymentMethod iPaymentMethod1)
        {
            iCategory = iCategory1;
            iProduct = iProduct1;
			iInvoseHeder = iInvoseHeder1;
			iUserInformation = iUserInformation1;
			iPaymentMethod = iPaymentMethod1;

		}
        public IActionResult MyPOS()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCategory = iCategory.GetAll();
            vmodel.ListViewProduct = iProduct.GetAll();
			var numberinvose = vmodel.ListViewInvoseHede = iInvoseHeder.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.InvoiceNumber) + 1
        : 1;
            ViewBag.user = iUserInformation.GetAllByRole("Customer");
			vmodel.ListPaymentMethod = iPaymentMethod.GetAllActive();

            var payMeth = vmodel.ListPaymentMethod.FirstOrDefault(p => p.PaymentMethodAr.Contains("نقد"));
            TempData["idForPay"] = payMeth.IdPaymentMethod;
			TempData["ArDesForPay"] = payMeth.PaymentMethodAr;
            return View(vmodel); 
        }

		public IActionResult GetProductsByCategory(int IdCategory)
		{
			if (IdCategory <= 0)
			{
				return BadRequest("Invalid category ID");
			}

			var products = iProduct.GetAllv(IdCategory);
			if (products == null || !products.Any())
			{
				return NotFound("No products found for this category");
			}

			// عرض المنتجات باستخدام PartialView
			return PartialView("_ProductsPartial", products);
		}
	}
}
