

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LevelThreeAccountController : Controller
    {
        MasterDbcontext dbcontext;
        IICompanyInformation iCompanyInformation;
        IIMainAccount iMainAccount;
        IILevelTwoAccount  iLevelTwoAccount;
        IIBLevelThreeAccount iLevelThreeAccount;
        public LevelThreeAccountController(MasterDbcontext dbcontext1, IICompanyInformation iCompanyInformation1, IIMainAccount iMainAccount1, IILevelTwoAccount iLevelTwoAccount1, IIBLevelThreeAccount iBLevelThreeAccount1)
        {
            dbcontext = dbcontext1;
            iCompanyInformation = iCompanyInformation1;
            iMainAccount = iMainAccount1;
            iLevelTwoAccount = iLevelTwoAccount1;
            iLevelThreeAccount = iBLevelThreeAccount1;
        }
        public IActionResult MyLevelThreeAccount()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewViewLevelThreeAccount = iLevelThreeAccount.GetAll();
            var numberinvose = vmodel.ListViewViewLevelThreeAccount = iLevelThreeAccount.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.NumberAccount) + 001
        : 001;
            ViewBag.minAccount = vmodel.ListMainAccount = iMainAccount.GetAll();
            return View(vmodel);
        }
        public IActionResult AddLevelThreeAccount(int? IdLevelThreeAccount)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewViewLevelThreeAccount = iLevelThreeAccount.GetAll();
            var numberinvose = vmodel.ListViewViewLevelThreeAccount = iLevelThreeAccount.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.NumberAccount) + 1
        : 001;
            vmodel.ListViewViewLevelThreeAccount = iLevelThreeAccount.GetAll();
            ViewBag.minAccount = vmodel.ListMainAccount = iMainAccount.GetAll();
            if (IdLevelThreeAccount != null)
            {
                vmodel.LevelThreeAccount = iLevelThreeAccount.GetById(Convert.ToInt32(IdLevelThreeAccount));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBLevelThreeAccount slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdLevelThreeAccount = model.LevelThreeAccount.IdLevelThreeAccount;
                slider.IdMainAccount = model.LevelThreeAccount.IdMainAccount;
                slider.NumberAccount = model.LevelThreeAccount.NumberAccount;
                slider.AccountName = model.LevelThreeAccount.AccountName;
                slider.Active = model.LevelThreeAccount.Active;
                slider.DateTimeEntry = model.LevelThreeAccount.DateTimeEntry;
                slider.DataEntry = model.LevelThreeAccount.DataEntry;
                slider.CurrentState = model.LevelThreeAccount.CurrentState;
                if (slider.IdLevelThreeAccount == 0 || slider.IdLevelThreeAccount == null)
                {

                    if (dbcontext.TBLevelThreeAccounts.Where(a => a.NumberAccount == slider.NumberAccount).ToList().Count > 0)
                    {
                        TempData["NumberAccount"] = ResourceWeb.VLNumberAccountDoplceted;
                        return RedirectToAction("MyLevelThreeAccount");
                    }
                    if (dbcontext.TBLevelThreeAccounts.Where(a => a.AccountName == slider.AccountName).ToList().Count > 0)
                    {
                        TempData["AccountName"] = ResourceWeb.VLAccountNameDoplceted;
                        return RedirectToAction("MyLevelThreeAccount");
                    }
                    var reqwest = iLevelThreeAccount.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyLevelThreeAccount");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddLevelThreeAccount");
                    }
                }
                else
                {
                    var reqestUpdate = iLevelThreeAccount.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyLevelThreeAccount");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddLevelThreeAccount");
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
        public IActionResult DeleteData(int IdLevelThreeAccount)
        {
            var reqwistDelete = iLevelThreeAccount.deleteData(IdLevelThreeAccount);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyLevelThreeAccount");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyLevelThreeAccount");

            }
        }

        [HttpGet]
        public JsonResult GetAccountNumber(int mainAccountId)
        {
            // جلب رقم الحساب من قاعدة البيانات بناءً على الحساب الرئيسي المختار
            var accountNumber = dbcontext.TBMainAccounts
                                       .Where(a => a.IdMainAccount == mainAccountId)
                                       .Select(a => a.NumberAccount) // رقم الحساب في الجدول
                                       .FirstOrDefault();

            return Json(accountNumber);
        }
    }
}
