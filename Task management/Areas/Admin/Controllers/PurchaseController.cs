

namespace Task_management.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class PurchaseController : Controller
	{
		MasterDbcontext dbcontext;
		IICompanyInformation iCompanyInformation;
		IISupplier iSupplier;
		IIPaymentMethod iPaymentMethod;
		IIUnit iUnit;
		IIClassCard iClassCard;
		IIPurchase iPurchase;

		public PurchaseController(MasterDbcontext dbcontext1,IICompanyInformation iCompanyInformation1,IISupplier iSupplier1,IIPaymentMethod iPaymentMethod1,IIUnit iUnit1,IIClassCard iClassCard1,IIPurchase iPurchase1 )
        {
			dbcontext = dbcontext1;
			iCompanyInformation = iCompanyInformation1;
			iSupplier = iSupplier1;
			iPaymentMethod = iPaymentMethod1;
			iUnit = iUnit1;
			iClassCard = iClassCard1;
			iPurchase= iPurchase1;

		}
		public IActionResult MyPurchase()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			vmodel.ListViewPurchase = iPurchase.GetAll();
			ViewBag.Supplier = vmodel.ListViewSupplier = iSupplier.GetAll();
			ViewBag.PaymentMethod = vmodel.ListPaymentMethod = iPaymentMethod.GetAll();
			ViewBag.Unit = vmodel.ListUnit = iUnit.GetAll();
			ViewBag.ClassCard = vmodel.ListViewClassCard = iClassCard.GetAll();
			var numberinvose = vmodel.ListViewPurchase = iPurchase.GetAll();
			ViewBag.nomberMax = numberinvose.Any()
		? numberinvose.Max(c => c.PurchaseNumber) + 1
		: 1;
			return View(vmodel);
		}
		public IActionResult AddPurchase(int? IdPurchase)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
			vmodel.ListViewPurchase = iPurchase.GetAll();
			ViewBag.Supplier = vmodel.ListViewSupplier = iSupplier.GetAll();
			ViewBag.PaymentMethod = vmodel.ListPaymentMethod = iPaymentMethod.GetAll();
			ViewBag.Unit = vmodel.ListUnit = iUnit.GetAll();
			ViewBag.ClassCard = vmodel.ListViewClassCard = iClassCard.GetAll();
			var numberinvose = vmodel.ListViewPurchase = iPurchase.GetAll();
			ViewBag.nomberMax = numberinvose.Any()
		? numberinvose.Max(c => c.PurchaseNumber) + 1
		: 1;
			if (IdPurchase != null)
			{
				vmodel.Purchase = iPurchase.GetById(Convert.ToInt32(IdPurchase));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPurchase slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdPurchase = model.Purchase.IdPurchase;
				slider.IdSupplier = model.Purchase.IdSupplier;
				slider.IdPaymentMethod = model.Purchase.IdPaymentMethod;
				slider.Statement = model.Purchase.Statement;
				slider.PurchaseDate = model.Purchase.PurchaseDate;
				slider.PurchaseNumber = model.Purchase.PurchaseNumber;
				slider.PurchaseSubNumber = model.Purchase.PurchaseSubNumber;
				slider.IdProduct = model.Purchase.IdProduct;
				slider.IdUnit = model.Purchase.IdUnit;
				slider.Quantity = model.Purchase.Quantity;
				slider.FreeQuantity = model.Purchase.FreeQuantity;
				slider.AllQuantity = (model.Purchase.Quantity) + (model.Purchase.FreeQuantity ?? 0);
				slider.PurchasePrice = model.Purchase.PurchasePrice;
				slider.Total = model.Purchase.Total;
				slider.SingleDiscount = model.Purchase.SingleDiscount;
				slider.shipping = model.Purchase.shipping;
				slider.Nouts = model.Purchase.Nouts;
				slider.TotalDiscount = model.Purchase.TotalDiscount;
				slider.TotalQuantity = model.Purchase.TotalQuantity;
				slider.TotalAll = model.Purchase.TotalAll;
				slider.DateTimeEntry = model.Purchase.DateTimeEntry;
				slider.DataEntry = model.Purchase.DataEntry;
				slider.CurrentState = model.Purchase.CurrentState;
				if (slider.IdPurchase == 0 || slider.IdPurchase == null)
				{

					var reqwest = iPurchase.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyPurchase");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return RedirectToAction("AddPurchase");
					}
				}
				else
				{
					var reqestUpdate = iPurchase.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyPurchase");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
						return RedirectToAction("AddPurchase");
					}
				}
			}
			catch
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
				return Redirect(returnUrl);
			}
		}
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteData(int IdPurchase)
		{
			var reqwistDelete = iPurchase.deleteData(IdPurchase);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyPurchase");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyPurchase");

			}
		}
	}
}
