

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LevelForeAccountController : Controller
    {
        MasterDbcontext dbcontext;
        IICompanyInformation iCompanyInformation;
        IIMainAccount iMainAccount;
        IILevelTwoAccount iLevelTwoAccount;
        IIBLevelThreeAccount iBLevelThreeAccount;
        IILevelForeAccount iLevelForeAccount;
        public LevelForeAccountController(MasterDbcontext dbcontext1, IICompanyInformation iCompanyInformation1, IIMainAccount iMainAccount1, IILevelTwoAccount iLevelTwoAccount1,IIBLevelThreeAccount iBLevelThreeAccount1,IILevelForeAccount iLevelForeAccount1)
        {
            dbcontext = dbcontext1;
            iCompanyInformation = iCompanyInformation1;
            iMainAccount = iMainAccount1;
            iLevelTwoAccount = iLevelTwoAccount1;
            iLevelForeAccount = iLevelForeAccount1;
            iBLevelThreeAccount = iBLevelThreeAccount1;
        }
        public IActionResult MyLevelForeAccount()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();
            ViewBag.minAccount = vmodel.ListMainAccount = iMainAccount.GetAll();
            ViewBag.LevelTwoAccount = vmodel.ListViewLevelTwoAccount = iLevelTwoAccount.GetAll();
            ViewBag.LevelThreeAccount = iBLevelThreeAccount.GetAll();
            var numberinvose = vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.LevelForeAccountsNumber) + 0001
        : 0001;       
            return View(vmodel);
        }
        public IActionResult AddMyLevelForeAccount(int? IdLevelForeAccount)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();
            ViewBag.minAccount = vmodel.ListMainAccount = iMainAccount.GetAll();
            ViewBag.LevelTwoAccount = vmodel.ListViewLevelTwoAccount = iLevelTwoAccount.GetAll();
            ViewBag.LevelThreeAccount = iBLevelThreeAccount.GetAll();
            var numberinvose = vmodel.ListViewLevelForeAccount = iLevelForeAccount.GetAll();
            ViewBag.nomberMax = numberinvose.Any()
        ? numberinvose.Max(c => c.LevelForeAccountsNumber) + 0001
        : 0001;
            if (IdLevelForeAccount != null)
            {
                vmodel.LevelForeAccount = iLevelForeAccount.GetById(Convert.ToInt32(IdLevelForeAccount));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBLevelForeAccount slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdLevelForeAccount = model.LevelForeAccount.IdLevelForeAccount;
                slider.IdLevelThreeAccount = model.LevelForeAccount.IdLevelThreeAccount;
                slider.IdLevelTwoAccount = model.LevelForeAccount.IdLevelTwoAccount;
                slider.IdMainAccount = model.LevelForeAccount.IdMainAccount;
                slider.NumberAccount = model.LevelForeAccount.NumberAccount;
                slider.AccountName = model.LevelForeAccount.AccountName;
                slider.Active = model.LevelForeAccount.Active;
                slider.DateTimeEntry = model.LevelForeAccount.DateTimeEntry;
                slider.DataEntry = model.LevelForeAccount.DataEntry;
                slider.CurrentState = model.LevelForeAccount.CurrentState;
                if (slider.IdLevelForeAccount == 0 || slider.IdLevelForeAccount == null)
                {

                    if (dbcontext.TBLevelForeAccounts.Where(a => a.NumberAccount == slider.NumberAccount).ToList().Count > 0)
                    {
                        TempData["NumberAccount"] = ResourceWeb.VLNumberAccountDoplceted;
                        return RedirectToAction("MyLevelForeAccount");
                    }
                    if (dbcontext.TBLevelForeAccounts.Where(a => a.AccountName == slider.AccountName).ToList().Count > 0)
                    {
                        TempData["AccountName"] = ResourceWeb.VLAccountNameDoplceted;
                        return RedirectToAction("MyLevelForeAccount");
                    }
                    var reqwest = iLevelForeAccount.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyLevelForeAccount");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddMyLevelForeAccount");
                    }
                }
                else
                {
                    var reqestUpdate = iLevelForeAccount.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyLevelForeAccount");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddMyLevelForeAccount");
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
        public IActionResult DeleteData(int IdLevelForeAccount)
        {
            var reqwistDelete = iLevelForeAccount.deleteData(IdLevelForeAccount);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyLevelForeAccount");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyLevelForeAccount");

            }

        }
        [HttpGet]
        public JsonResult GetLevelTwoAccounts(int mainAccountId)
        {
            var levelTwoAccounts = dbcontext.TBLevelTwoAccounts
                .Where(a => a.IdMainAccount == mainAccountId)
                .Select(a => new
                {
                    idLevelTwoAccount = a.IdLevelTwoAccount,
                    accountName = a.AccountName,
                    AccountNumber = a.NumberAccount // إضافة رقم الحساب
                })
                .ToList();

            return Json(levelTwoAccounts);
        }

        [HttpGet]
        public JsonResult GetLevelThreeAccounts(int levelTwoAccountId)
        {
            var levelThreeAccounts = dbcontext.ViewLevelThreeAccount
                .Where(a => a.IdLevelTwoAccount == levelTwoAccountId)
                .Select(a => new
                {
                    idLevelThreeAccount = a.IdLevelThreeAccount,
                    accountName = a.NameLevelThreeAccounts,
                    AccountNumber = a.NumberLevelThreeAccounts // إضافة رقم الحساب
                })
                .ToList();

            return Json(levelThreeAccounts);
        }

        [HttpGet]
        public JsonResult GetNextLevelFourAccountNumber(int levelThreeAccountId)
        {
            var maxLevelFourAccount = dbcontext.TBLevelForeAccounts
                .Where(a => a.IdLevelThreeAccount == levelThreeAccountId)
                .OrderByDescending(a => a.NumberAccount)
                .FirstOrDefault();

            string newAccountNumber = "0002"; // القيمة الافتراضية إذا لم يكن هناك حسابات في المستوى الرابع
            if (maxLevelFourAccount != null)
            {
                int nextNumber = maxLevelFourAccount.NumberAccount + 1;
                newAccountNumber = nextNumber.ToString().PadLeft(4, '0');
            }

            return Json(new { accountNumber = newAccountNumber });
        }



    }
}
