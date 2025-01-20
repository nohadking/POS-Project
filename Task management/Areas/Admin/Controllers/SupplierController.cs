using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        MasterDbcontext dbcontext;
        IISupplier iSupplier;
        IICompanyInformation iCompanyInformation;
        IIPaymentMethod paymentMethod;
        public SupplierController(MasterDbcontext dbcontext1,IISupplier iSupplier1,IICompanyInformation iCompanyInformation1,IIPaymentMethod iPaymentMethod1)
        {
            dbcontext=dbcontext1;
            iSupplier =iSupplier1;
            iCompanyInformation = iCompanyInformation1;
            paymentMethod=iPaymentMethod1;
        }
        public IActionResult MYSupplier()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewSupplier = iSupplier.GetAll();
            ViewBag.paymentMethod = paymentMethod.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditSupplier(int? IdSupplier)
        {
            ViewBag.paymentMethod = paymentMethod.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewSupplier = iSupplier.GetAll();
            if (IdSupplier != null)
            {
                vmodel.Supplier = iSupplier.GetById(Convert.ToInt32(IdSupplier));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditSupplierImage(int? IdSupplier)
        {
            ViewBag.paymentMethod = paymentMethod.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCompanyInformation = iCompanyInformation.GetAll().Take(1).ToList();
            vmodel.ListViewSupplier = iSupplier.GetAll();
            if (IdSupplier != null)
            {
                vmodel.Supplier = iSupplier.GetById(Convert.ToInt32(IdSupplier));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBSupplier slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                // تأكد من أن الخاصية Supplier تحتوي على القيم
                if (model.Supplier == null)
                {
                    TempData["ErrorSave"] = "بيانات الفئة غير صحيحة.";
                    return RedirectToAction("AddEditSupplier");
                }
                // نسخ القيم من النموذج إلى الكائن slider
                slider.IdSupplier = model.Supplier.IdSupplier;
                slider.IdPaymentMethod = model.Supplier.IdPaymentMethod;
                slider.Photo = model.Supplier.Photo;
                slider.SupplierName = model.Supplier.SupplierName;
                slider.Specialization = model.Supplier.Specialization;
                slider.Phone = model.Supplier.Phone;
                slider.Mobile = model.Supplier.Mobile;
                slider.NameOner = model.Supplier.NameOner;
                slider.PhoneOner = model.Supplier.PhoneOner;
                slider.EmailOner = model.Supplier.EmailOner;
                slider.EmailCompany = model.Supplier.EmailCompany;
                slider.Address = model.Supplier.Address;
                slider.Debtlimit = model.Supplier.Debtlimit;
                slider.GracePeriod = model.Supplier.GracePeriod;
                slider.website = model.Supplier.website;   
                slider.DateTimeEntry = model.Supplier.DateTimeEntry;
                slider.DataEntry = model.Supplier.DataEntry;
                slider.CurrentState = model.Supplier.CurrentState;
                slider.Active = model.Supplier.Active;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdSupplier == 0 || slider.IdSupplier == null)
                {
                    if (file.Count() > 0)
                    {
                        string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        slider.Photo = Photo;
                        fileStream.Close();
                    }
                    else
                    {
                        TempData["Message"] = ResourceWeb.VLimageuplode;
                        return Redirect(returnUrl);
                    }
                    // تحقق من تكرار اسم الفئة
                    if (dbcontext.TBSuppliers.Where(a => a.SupplierName == slider.SupplierName).ToList().Count > 0)
                    {
                        TempData["Suppliers"] = ResourceWeb.VLSuppliersEnDoplceted;
                        return RedirectToAction("MYSupplier");
                    }

                  
                    // حفظ البيانات
                    var reqwest = iSupplier.saveData(slider);
                    if (reqwest)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYSupplier");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iSupplier.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditSupplier");
                    }
                }
                else
                {
                    // تحديث البيانات
                    if (file.Count() == 0)
                    {
                        slider.Photo = model.Supplier.Photo;
                        var reqestUpdate2 = iSupplier.UpdateData(slider);
                        if (reqestUpdate2)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYSupplier");
                        }
                        else
                        {
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditSupplier", model);
                        }
                    }
                    else
                    {
                        string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        slider.Photo = Photo;
                        fileStream.Close();
                        // حذف الصورة القديمة إذا لزم الأمر
                        var reqweistDeletPoto = iSupplier.DELETPHOTO(slider.IdSupplier);
                        var reqestUpdate2 = iSupplier.UpdateData(slider);
                        if (reqestUpdate2)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYSupplier");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iSupplier.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("MYSupplier");
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddEditSupplier", model);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdSupplier)
        {
            var reqwistDelete = iSupplier.deleteData(IdSupplier);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYSupplier");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYSupplier");
            }
        }
    }
}
