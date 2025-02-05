using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExpenseController : Controller
    {
        IIExpense iExpense;
        IICompanyInformation iCompanyInformation;
        IIExpenseCategory iExpenseCategory;
        IILevelForeAccount iLevelForeAccount ;
        public ExpenseController(IIExpense iExpense1,IICompanyInformation  iCompanyInformation1,IIExpenseCategory iExpenseCategory1,IILevelForeAccount iLevelForeAccount1)
        {
            iExpense=iExpense1;
            iCompanyInformation=iCompanyInformation1;
            iExpenseCategory =iExpenseCategory1;
            iLevelForeAccount =iLevelForeAccount1;

        }
        public IActionResult MyExpense()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewExpense = iExpense.GetAll();
          ViewBag.ExpenseCategory= vmodel.ListExpenseCategory = iExpenseCategory.GetAll();
          ViewBag.LevelForeAccount = vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();





            var numberinvose = vmodel.ListViewExpense = iExpense.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.BondNumber) + 1
        : 1;
            return View(vmodel);
        }
        public IActionResult AddExpense(int? IdExpense)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewExpense = iExpense.GetAll();
            var numberinvose = vmodel.ListViewExpense = iExpense.GetAll();
            ViewBag.nomberMax = numberinvose.Any()

        ? numberinvose.Max(c => c.BondNumber) + 1
        : 1;
            vmodel.ListViewExpense = iExpense.GetAll();
            ViewBag.ExpenseCategory = vmodel.ListExpenseCategory = iExpenseCategory.GetAll();
            if (IdExpense != null)
            {
                vmodel.Expense = iExpense.GetById(Convert.ToInt32(IdExpense));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBExpense slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdExpense = model.Expense.IdExpense;
                slider.IdExpenseCategory = model.Expense.IdExpenseCategory;
                slider.IdLevelForeAccount = model.Expense.IdLevelForeAccount;
                slider.BondNumber = model.Expense.BondNumber;
                slider.Statement = model.Expense.Statement;
                slider.Amount = model.Expense.Amount;
                slider.DateTimeEntry = model.Expense.DateTimeEntry;
                slider.DataEntry = model.Expense.DataEntry;
                slider.CurrentState = model.Expense.CurrentState;           
                if (slider.IdExpense == 0 || slider.IdExpense == null)
                {                     
                    var reqwest = iExpense.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyExpense");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddExpense");
                    }
                }
                else
                {
                    var reqestUpdate = iExpense.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyExpense");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddExpense");
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
        public IActionResult DeleteData(int IdExpense)
        {
            var reqwistDelete = iExpense.deleteData(IdExpense);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyExpense");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyExpense");

            }
        }

    }
}
