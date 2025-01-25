

using Microsoft.Kiota.Abstractions;

namespace Infarstuructre.BL
{
    public interface IIInvose
    {
        List<TBViewInvose> GetAll();
        TBInvose GetById(int IdInvose);
        List<TBViewInvose> GetByCacherName(string name);
        bool saveData(TBInvose savee);
        bool UpdateData(TBInvose updatss);
        bool deleteData(int IdInvose);
        TBViewInvose GetByIdview(int IdInvose);
        List<TBViewInvose> GetByInvoiceNumber(int invNum);
        List<TBViewInvose> GetByCacherNameAndPay(string name, string pay);
        List<TBViewInvose> GetByDateTimeEntry(DateTime date);
        List<TBViewInvose> GetByCasherNameAndPayMethAndDateTimeEntry(string name, string pay, DateTime date);
        List<TBViewInvose> GetByCasherNameAndPayMethodAndPeriodDate(string name, string pay, DateTime start, DateTime end);
        List<TBViewInvose> GetByCasherNameAndPeriodDate(string name, DateTime start, DateTime end);
        List<TBViewInvose> GetByPeriodDate(DateTime start, DateTime end);
        List<TBViewInvose> GetBySearchWord(string word);
        List<TBViewInvose> GetByPayMeth(string payMeth);
        List<TBViewInvose> GetByPayMethAndPeriodDate(string pay, DateTime start, DateTime end);
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

        public List<TBViewInvose> GetByCacherName(string name)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == name).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByCacherNameAndPay(string name, string pay)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == name && a.PaymentMethodAr == pay).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByDateTimeEntry(DateTime date)
        {
            var invoices = dbcontext.ViewInvose
                .Where(a => a.DateTimeEntry.Date == date.Date) // مقارنة التاريخ فقط
                .ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByCasherNameAndPayMethAndDateTimeEntry(string name, string pay, DateTime date)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == name && a.PaymentMethodAr == pay && a.DateTimeEntry.Date == date.Date).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByCasherNameAndPayMethodAndPeriodDate(string name, string pay, DateTime start, DateTime end)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == name && a.PaymentMethodAr == pay
            && a.DateTimeEntry.Date >= start.Date && a.DateTimeEntry.Date <= end.Date).ToList();
            return invoices;
        }


        public List<TBViewInvose> GetBySearchWord(string word)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == word 
            || a.PaymentMethodAr == word
            || a.InvoiceNumber == int.Parse(word)
            || a.Quantity == int.Parse(word)
            || a.price == decimal.Parse(word)
            || a.total == decimal.Parse(word)
            || a.PaymentMethodEn == word
            || a.ProductNameEn == word
            || a.PhoneNumber == word
            || a.DateTimeEntry == Convert.ToDateTime(word)
            || a.DateInvos == Convert.ToDateTime(word)
            || a.ProductNameAr == word).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByPayMeth(string payMeth)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.PaymentMethodAr == payMeth).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByCasherNameAndPeriodDate(string name, DateTime start, DateTime end)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DataEntry == name
            && a.DateTimeEntry.Date >= start.Date && a.DateTimeEntry.Date <= end.Date).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByPayMethAndPeriodDate(string pay, DateTime start, DateTime end)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.PaymentMethodAr == pay
            && a.DateTimeEntry.Date >= start.Date && a.DateTimeEntry.Date <= end.Date).ToList();
            return invoices;
        }

        public List<TBViewInvose> GetByPeriodDate(DateTime start, DateTime end)
        {
            var invoices = dbcontext.ViewInvose.Where(a => a.DateTimeEntry.Date >= start.Date && a.DateTimeEntry.Date <= end.Date).ToList();
            return invoices;
        }
    }
}
