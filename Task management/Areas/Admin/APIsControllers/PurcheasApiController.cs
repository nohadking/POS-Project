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
        IIClassCard iClassCard;
        public PurcheasApiController(MasterDbcontext dbcontext, IIPurchase iPurchase, IIClassCard iClassCard)
        {
            this.dbcontext = dbcontext;
            this.iPurchase = iPurchase;
            this.iClassCard = iClassCard;
        }

        [HttpGet("/api/PurcheasApi/GetByPurcheasNu/{purchaseNumber}")]
        public IActionResult GetByPurcheasNu(int purchaseNumber)
        {
            var purcheas = iPurchase.GetByPurcheasNu(purchaseNumber);
            return Ok(purcheas);
        }

        [HttpGet("/api/PurcheasApi/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var purcheas = iClassCard.GetById(id);
            return Ok(purcheas);
        }


        [HttpPost]
        public IActionResult AddPurcheas([FromBody] TBPurchase purchase)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = iPurchase.saveData(purchase);
            return Ok(result);
        }


        [HttpDelete("DeletePurcheases")]
        public IActionResult DeletePurcheases(List<int> idsList)
        {
            foreach(var id in idsList)
            {
                var purcheas = dbcontext.TBPurchases.Find(id);

                if (purcheas == null)
                    continue;

                dbcontext.TBPurchases.Remove(purcheas);
                dbcontext.SaveChanges();
            }

            return Ok(new TBPurchase());
        }
    }
}
