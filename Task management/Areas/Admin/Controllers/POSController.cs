using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class POSController : Controller
    {
        IICategory iCategory;
        IIProduct iProduct;
        public POSController(IICategory iCategory1,IIProduct iProduct1)
        {
            iCategory = iCategory1;
            iProduct = iProduct1;
        }
        public IActionResult MyPOS()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCategory = iCategory.GetAll();
            vmodel.ListViewProduct = iProduct.GetAll();
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
