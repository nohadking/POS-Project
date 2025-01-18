using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IIExpense
    {
        List<TBViewExpense> GetAll();
        TBExpense GetById(int IdExpense);
        bool saveData(TBExpense savee);
        bool UpdateData(TBExpense updatss);
        bool deleteData(int IdExpense);
        List<TBViewExpense> GetAllv(int IdExpense);
        TBViewExpense GetByIdview(int IdExpense);
    }
    public class CLSTBExpense: IIExpense
    {
        MasterDbcontext dbcontext;
        public CLSTBExpense(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewExpense> GetAll()
        {
            List<TBViewExpense> MySlider = dbcontext.ViewExpense.OrderByDescending(n => n.IdExpense).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBExpense GetById(int IdExpense)
        {
            TBExpense sslid = dbcontext.TBExpenses.FirstOrDefault(a => a.IdExpense == IdExpense);
            return sslid;
        }
        public bool saveData(TBExpense savee)
        {
            try
            {
                dbcontext.Add<TBExpense>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBExpense updatss)
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
        public bool deleteData(int IdExpense)
        {
            try
            {
                var catr = GetById(IdExpense);
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
        public List<TBViewExpense> GetAllv(int IdExpense)
        {
            List<TBViewExpense> MySlider = dbcontext.ViewExpense.OrderByDescending(n => n.IdExpense == IdExpense).Where(a => a.IdExpense == IdExpense).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBViewExpense GetByIdview(int IdExpense)
        {
            TBViewExpense sslid = dbcontext.ViewExpense.FirstOrDefault(a => a.IdExpense == IdExpense);
            return sslid;
        }
    }
}
