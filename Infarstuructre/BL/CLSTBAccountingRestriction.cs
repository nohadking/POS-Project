using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IIAccountingRestriction
    {
        List<TBAccountingRestriction> GetAll();
  
        TBAccountingRestriction GetById(int IdaccountingRestrictions);
        bool saveData(TBAccountingRestriction savee);
        bool UpdateData(TBAccountingRestriction updatss);
        bool deleteData(int IdaccountingRestrictions);
        List<TBAccountingRestriction> GetAllv(int IdaccountingRestrictions);
    }
    public class CLSTBAccountingRestriction: IIAccountingRestriction
    {
        MasterDbcontext dbcontext;
        public CLSTBAccountingRestriction(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBAccountingRestriction> GetAll()
        {
            List<TBAccountingRestriction> MySlider = dbcontext.TBAccountingRestrictions.OrderByDescending(n => n.IdaccountingRestrictions).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    
        public TBAccountingRestriction GetById(int IdaccountingRestrictions)
        {
            TBAccountingRestriction sslid = dbcontext.TBAccountingRestrictions.FirstOrDefault(a => a.IdaccountingRestrictions == IdaccountingRestrictions);
            return sslid;
        }
        public bool saveData(TBAccountingRestriction savee)
        {
            try
            {
                dbcontext.Add<TBAccountingRestriction>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBAccountingRestriction updatss)
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
        public bool deleteData(int IdaccountingRestrictions)
        {
            try
            {
                var catr = GetById(IdaccountingRestrictions);
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
        public List<TBAccountingRestriction> GetAllv(int IdaccountingRestrictions)
        {
            List<TBAccountingRestriction> MySlider = dbcontext.TBAccountingRestrictions.OrderByDescending(n => n.IdaccountingRestrictions == IdaccountingRestrictions).Where(a => a.IdaccountingRestrictions == IdaccountingRestrictions).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
