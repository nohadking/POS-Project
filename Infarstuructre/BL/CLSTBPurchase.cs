

namespace Infarstuructre.BL
{
	public interface IIPurchase
	{
		List<TBViewPurchase> GetAll();
		TBPurchase GetById(int IdPurchase);
		bool saveData(TBPurchase savee);
		bool UpdateData(TBPurchase updatss);
		bool deleteData(int IdPurchase);
		List<TBViewPurchase> GetAllv(int IdPurchase);
		TBViewPurchase GetByIdview(int IdPurchase);
	}
	public class CLSTBPurchase: IIPurchase
	{
		MasterDbcontext dbcontext;
		public CLSTBPurchase(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1;

		}

		public List<TBViewPurchase> GetAll()
		{
			List<TBViewPurchase> MySlider = dbcontext.ViewPurchase.OrderByDescending(n => n.IdPurchase).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBPurchase GetById(int IdPurchase)
		{
			TBPurchase sslid = dbcontext.TBPurchases.FirstOrDefault(a => a.IdPurchase == IdPurchase);
			return sslid;
		}
		public bool saveData(TBPurchase savee)
		{
			try
			{
				dbcontext.Add<TBPurchase>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBPurchase updatss)
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
		public bool deleteData(int IdPurchase)
		{
			try
			{
				var catr = GetById(IdPurchase);
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
		public List<TBViewPurchase> GetAllv(int IdPurchase)
		{
			List<TBViewPurchase> MySlider = dbcontext.ViewPurchase.OrderByDescending(n => n.IdPurchase == IdPurchase).Where(a => a.IdPurchase == IdPurchase).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBViewPurchase GetByIdview(int IdPurchase)
		{
			TBViewPurchase sslid = dbcontext.ViewPurchase.FirstOrDefault(a => a.IdPurchase == IdPurchase);
			return sslid;
		}

	}
}
