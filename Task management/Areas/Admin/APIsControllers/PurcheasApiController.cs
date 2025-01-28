using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurcheasApiController : ControllerBase
    {
        MasterDbcontext dbcontext;
        IIPurchase iPurchase;
        public PurcheasApiController(MasterDbcontext dbcontext, IIPurchase iPurchase)
        {
            this.dbcontext = dbcontext;
            this.iPurchase = iPurchase;
        }


        [HttpPost]
        public IActionResult AddPurcheas([FromBody] TBPurchase purchase)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = iPurchase.saveData(purchase);
            return Ok(result);
        }
    }
}
