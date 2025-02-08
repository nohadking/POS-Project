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

        [HttpDelete("{accountId}")]
        public IActionResult DeleteAccountRe(int accountId)
        {
            var result = iAccountingRestriction.deleteData(accountId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = iAccountingRestriction.GetAll();
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetBySupAndPeriodDate/{sup}/{start}/{end}")]
        public IActionResult GetBySupAndPeriodDate(string sup, string start, string end)
        {
            var startDt = Convert.ToDateTime(start);
            var endDt = Convert.ToDateTime(end);
            var accounts = iAccountingRestriction.GetBySupAndPeriodDate(sup, startDt, endDt);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetByPeriodDate/{start}/{end}")]
        public IActionResult GetByPeriodDate(string start, string end)
        {
            var startDt = Convert.ToDateTime(start);
            var endDt = Convert.ToDateTime(end);
            var accounts = iAccountingRestriction.GetByPeriodDate(startDt, endDt);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetBySupAndDetectedDt/{sup}/{date}")]
        public IActionResult GetBySupAndDetectedDt(string sup, string date)
        {
            var dt = Convert.ToDateTime(date);
            var accounts = iAccountingRestriction.GetBySupAndDetectedDt(sup, dt);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetByTypeAndPeriodDate/{type}/{start}/{end}")]
        public IActionResult GetByTypeAndPeriodDate(string type, string start, string end)
        {
            var startDt = Convert.ToDateTime(start);
            var endDt = Convert.ToDateTime(end);
            var accounts = iAccountingRestriction.GetByTypeAndPeriodDate(type, startDt, endDt);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetByTypeAndDetectedDt/{type}/{date}")]
        public IActionResult GetByTypeAndDetectedDt(string type, string date)
        {
            var dt = Convert.ToDateTime(date);
            var accounts = iAccountingRestriction.GetByTypeAndDetectedDt(type, dt);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetByDetectedDt/{date}")]
        public IActionResult GetByDetectedDt(string date)
        {
            var dt = Convert.ToDateTime(date);
            var accounts = iAccountingRestriction.GetByDetectedDt(dt);
            return Ok(accounts);
        }


        [HttpGet("/api/AccountRestrection/GetBySup/{sup}")]
        public IActionResult GetBySup(string sup)
        {
            var accounts = iAccountingRestriction.GetBySup(sup);
            return Ok(accounts);
        }

        [HttpGet("/api/AccountRestrection/GetByType/{type}")]
        public IActionResult GetByType(string type)
        {
            var accounts = iAccountingRestriction.GetByType(type);
            return Ok(accounts);
        }
    }
}
