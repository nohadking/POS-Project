

namespace Infarstuructre.BL
{
    public interface IIStaff
    {
        List<TBStaff> GetAll();
        TBStaff GetById(int IdStaff);
        bool saveData(TBStaff savee);
        bool UpdateData(TBStaff updatss);
        bool deleteData(int IdStaff);
        List<TBStaff> GetAllv(int IdStaff);
        bool DELETPHOTO(int IdStaff);
        bool DELETPHOTOWethError(string PhotoNAme);
    }
    public class CLSTBStaff: IIStaff
    {
        MasterDbcontext dbcontext;
        public CLSTBStaff(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBStaff> GetAll()
        {
            List<TBStaff> MySlider = dbcontext.TBStaffs.OrderByDescending(n => n.IdStaff).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBStaff GetById(int IdStaff)
        {
            TBStaff sslid = dbcontext.TBStaffs.FirstOrDefault(a => a.IdStaff == IdStaff);
            return sslid;
        }
        public bool saveData(TBStaff savee)
        {
            try
            {
                dbcontext.Add<TBStaff>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBStaff updatss)
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
        public bool deleteData(int IdStaff)
        {
            try
            {
                var catr = GetById(IdStaff);
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
        public List<TBStaff> GetAllv(int IdStaff)
        {
            List<TBStaff> MySlider = dbcontext.TBStaffs.OrderByDescending(n => n.IdStaff == IdStaff).Where(a => a.IdStaff == IdStaff).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPHOTO(int IdStaff)
        {
            try
            {
                var catr = GetById(IdStaff);
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



    }
}
