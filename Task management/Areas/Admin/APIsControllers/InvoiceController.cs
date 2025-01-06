using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IIInvose iInvose;
        UserManager<ApplicationUser> userManager;
        public InvoiceController(IIInvose iInvose, UserManager<ApplicationUser> userManager)
        {
            this.iInvose = iInvose;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(TBInvoiceHelper model)
        {
            var user = await userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var invoice = new TBInvose
            {
                IdInvoseHeder = model.IdInvoseHeder,
                IdProduct = model.IdProduct,
                Quantity = model.Quantity,
                price = model.price,
                total = model.total,
                CurrentState = true,
                DataEntry = user.UserName,
                DateTimeEntry = DateTime.Now,
            };

            iInvose.saveData(invoice);
            return Ok(invoice);
        }
    }
}
