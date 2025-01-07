using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task_management.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHeaderController : ControllerBase
    {
        IIInvoseHeder iInvoseHeder;
        UserManager<ApplicationUser> userManager;
        public InvoiceHeaderController(IIInvoseHeder iInvoseHeder, UserManager<ApplicationUser> userManager)
        {
            this.iInvoseHeder = iInvoseHeder;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddHeaderForInvoice(TBInvoseHeder model)
        {
            var user = await userManager.GetUserAsync(User);

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var invoiceHeader = new TBInvoseHeder
            {
                IdInvoseHeder = model.IdInvoseHeder,
                 IdCustomerCategorie = model.IdCustomerCategorie,
                 InvoiceNumber = model.InvoiceNumber,
                 IdPaymentMethod = model.IdPaymentMethod,
                 DataEntry = user.UserName,
                 DateInvos = DateTime.UtcNow,
                 DateTimeEntry = DateTime.UtcNow,
                 IdUser = user.Id,
                 OutstandingBill = true,
                 CurrentState = true,
            };

            iInvoseHeder.saveData(invoiceHeader);
            return Ok(invoiceHeader.IdInvoseHeder); 
        }
    }
}
