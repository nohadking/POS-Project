

namespace Infarstuructre.BL
{
    public interface IISupplier
    {
        List<TBViewSupplier> GetAll();
        TBSupplier GetById(int IdSupplier);
        bool saveData(TBSupplier savee);
        bool UpdateData(TBSupplier updatss);
        bool deleteData(int IdSupplier);
        List<TBViewSupplier> GetAllv(int IdSupplier);
        bool DELETPHOTO(int IdSupplier);
        bool DELETPHOTOWethError(string PhotoNAme);
        TBViewSupplier GetByIdview(int IdSupplier);

    }
    public class CLSTBSupplier: IISupplier
    {
        MasterDbcontext dbcontext;
        public CLSTBSupplier(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBViewSupplier> GetAll()
        {
            List<TBViewSupplier> MySlider = dbcontext.ViewSupplier.OrderByDescending(n => n.IdSupplier).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBSupplier GetById(int IdSupplier)
        {
            TBSupplier sslid = dbcontext.TBSuppliers.FirstOrDefault(a => a.IdSupplier == IdSupplier);
            return sslid;
        }
        public bool saveData(TBSupplier savee)
        {
            try
            {
                dbcontext.Add<TBSupplier>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBSupplier updatss)
        {
            try
            {
                dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteData(int IdSupplier)
        {
            try
            {
                var catr = GetById(IdSupplier);
                catr.CurrentState = false;
                //TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                //dbcontex.TbSubCateegoorys.Remove(dele);
                dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<TBViewSupplier> GetAllv(int IdSupplier)
        {
            List<TBViewSupplier> MySlider = dbcontext.ViewSupplier.OrderByDescending(n => n.IdSupplier == IdSupplier).Where(a => a.IdSupplier == IdSupplier).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPHOTO(int IdSupplier)
        {
            try
            {
                var catr = GetById(IdSupplier);
                //using (FileStream fs = new FileStream(catr.Photo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //{
                if (!string.IsNullOrEmpty(catr.Photo))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", catr.Photo);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DELETPHOTOWethError(string PhotoNAme)
        {
            try
            {
                if (!string.IsNullOrEmpty(PhotoNAme))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", PhotoNAme);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // يفضل ألا تترك البرنامج يتجاوز الأخطاء بصمت، يفضل تسجيل الخطأ أو إعادة رميه
                return false;
            }
        }
        public TBViewSupplier GetByIdview(int IdSupplier)
        {
            TBViewSupplier sslid = dbcontext.ViewSupplier.FirstOrDefault(a => a.IdSupplier == IdSupplier);
            return sslid;
        }
    }
}
