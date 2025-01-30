

namespace Infarstuructre.BL
{
    public interface IIMainAccount
    {

    }
    public class CLSTBMainAccount: IIMainAccount
    {
        MasterDbcontext dbcontext;
        public CLSTBMainAccount(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }


    }
}
