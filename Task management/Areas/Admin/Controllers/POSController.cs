using Grpc.Core;
using Infarstuructre.BL;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Printing;

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



        [HttpPost]
        public async Task<IActionResult> PrintReceipt([FromBody] string receiptContent)
        {
            // تأكد من أن `receiptContent` يحتوي على البيانات المرسلة
            if (string.IsNullOrEmpty(receiptContent))
            {
                return BadRequest("Content is empty");
            }

            // إنشاء مستند الطباعة
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF"; // اسم الطابعة

            pd.PrintPage += (sender, e) =>
            {
                // تحديد الخطوط التي سيتم استخدامها للطباعة
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 12);

                // تنسيق المحتوى
                e.Graphics.DrawString("Receipt", headerFont, Brushes.Black, 100, 50);

                // إضافة محتوى الفاتورة (receiptContent) مع تنسيق إضافي
                e.Graphics.DrawString(receiptContent, bodyFont, Brushes.Black, 100, 100);

                // إضافة بعض التفاصيل الإضافية على الطباعة
                e.Graphics.DrawString("VAT Payable through central registration", bodyFont, Brushes.Black, 100, 200);
                e.Graphics.DrawString("Thank you for shopping with us!", bodyFont, Brushes.Black, 100, 230);
            };

            // تنفيذ الطباعة بشكل غير متزامن لضمان استمرار العملية دون توقف
            await Task.Run(() => pd.Print());

            // إعادة التوجيه إلى صفحة MyPOS بعد الطباعة
            return RedirectToAction("MyPOS");
        }
    }
}
