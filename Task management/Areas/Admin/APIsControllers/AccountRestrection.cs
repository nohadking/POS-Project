using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRestrectionController : ControllerBase
    {
        IIAccountingRestriction iAccountingRestriction;
        public AccountRestrectionController(IIAccountingRestriction iAccountingRestriction = null)
        {
            this.iAccountingRestriction = iAccountingRestriction;
        }


        [HttpPost]
        public IActionResult AddAccountRe([FromBody] TBAccountingRestriction model)
        {
            var result = iAccountingRestriction.saveData(model);
            return Ok(result);
        }


        [HttpGet("/api/AccountRestrection/GetByBondNuAndBondType/{bond}/{type}")]
        public IActionResult GetByBondNuAndBondType(int bond, string type)
        {
            var accountRe = iAccountingRestriction.GetByBondNuAndBondType(bond, type);
            if(accountRe == null)
            {
                return Ok(new TBAccountingRestriction());
            }
            return Ok(accountRe);
        }

        [HttpDelete]
        public IActionResult DeleteAccountRe(int accountId)
        {
            var result = iAccountingRestriction.deleteData(accountId);
            return Ok(result);
        }
    }
}
