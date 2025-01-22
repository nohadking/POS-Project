using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountingRestrictionController : Controller
    {
        MasterDbcontext dbcontext;
        IIAccountingRestriction iAccountingRestriction;
        IICompanyInformation iCompanyInformation;
        public AccountingRestrictionController(MasterDbcontext dbcontext1,IIAccountingRestriction iAccountingRestriction1,IICompanyInformation iCompanyInformation1)
        {
            dbcontext=dbcontext1;
            iAccountingRestriction =iAccountingRestriction1;
            iCompanyInformation = iCompanyInformation1;
        }
        public IActionResult MyAccountingRestriction()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListAccountingRestriction = iAccountingRestriction.GetAll();
            var numberinvose = vmodel.ListAccountingRestriction = iAccountingRestriction.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.NumberaccountingRestrictions) + 1
        : 1;
            return View(vmodel);
        }
        public IActionResult AddAccountingRestriction(int? IdaccountingRestrictions)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListAccountingRestriction = iAccountingRestriction.GetAll();
            if (IdaccountingRestrictions != null)
            {
                vmodel.AccountingRestriction = iAccountingRestriction.GetById(Convert.ToInt32(IdaccountingRestrictions));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBAccountingRestriction slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdaccountingRestrictions = model.AccountingRestriction.IdaccountingRestrictions;
                slider.NumberaccountingRestrictions = model.AccountingRestriction.NumberaccountingRestrictions;
                slider.AccountingName = model.AccountingRestriction.AccountingName;
                slider.BondType = model.AccountingRestriction.BondType;
                slider.Debtor = model.AccountingRestriction.Debtor;
                slider.creditor = model.AccountingRestriction.creditor;
                slider.Statement = model.AccountingRestriction.Statement;
                slider.Nouts = model.AccountingRestriction.Nouts;       
                slider.DateTimeEntry = model.AccountingRestriction.DateTimeEntry;
                slider.DataEntry = model.AccountingRestriction.DataEntry;
                slider.CurrentState = model.AccountingRestriction.CurrentState;            
                if (slider.IdaccountingRestrictions == 0 || slider.IdaccountingRestrictions == null)
                {            
                    var reqwest = iAccountingRestriction.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyAccountingRestriction");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddAccountingRestriction");
                    }
                }
                else
                {
                    var reqestUpdate = iAccountingRestriction.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyAccountingRestriction");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddAccountingRestriction");
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
        public IActionResult DeleteData(int IdaccountingRestrictions)
        {
            var reqwistDelete = iAccountingRestriction.deleteData(IdaccountingRestrictions);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyAccountingRestriction");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyAccountingRestriction");

            }
        }
    }
}
