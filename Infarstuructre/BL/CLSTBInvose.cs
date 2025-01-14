

namespace Infarstuructre.BL
{
    public interface IIInvose
    {
        List<TBViewInvose> GetAll();
        TBInvose GetById(int IdInvose);
        bool saveData(TBInvose savee);
        bool UpdateData(TBInvose updatss);
        bool deleteData(int IdInvose);
        TBViewInvose GetByIdview(int IdInvose);
        List<TBViewInvose> GetByInvoiceNumber(int invNum);
    }
    public class CLSTBInvose: IIInvose
    {
        MasterDbcontext dbcontext;
        public CLSTBInvose(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewInvose> GetAll()
        {
            List<TBViewInvose> MySlider = dbcontext.ViewInvose.Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBInvose GetById(int IdInvose)
        {
            TBInvose sslid = dbcontext.TBInvoses.FirstOrDefault(a => a.IdInvose == IdInvose);
            return sslid;
        }
        public bool saveData(TBInvose savee)
        {
            try
            {
                dbcontext.Add<TBInvose>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBInvose updatss)
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
        public bool deleteData(int IdInvose)
        {
            try
            {
                var catr = GetById(IdInvose);
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
        //public List<TBViewInvose> GetAllv(int IdCategory)
        //{
        //    List<TBViewInvose> MySlider = dbcontext.ViewInvose.OrderByDescending(n => n.IdCategory == IdCategory).Where(a => a.IdCategory == IdCategory).Where(a => a.CurrentState == true).ToList();
        //    return MySlider;
        //}
        public TBViewInvose GetByIdview(int IdInvose)
        {
            TBViewInvose sslid = dbcontext.ViewInvose.FirstOrDefault(a => a.IdInvose == IdInvose);
            return sslid;
        }
        /// ///////////// /API/ ////////////////////////////
        public List<TBViewInvose> GetByInvoiceNumber(int invNum)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.InvoiceNumber == invNum).ToList();
            return invoices;
        }
    }
}
