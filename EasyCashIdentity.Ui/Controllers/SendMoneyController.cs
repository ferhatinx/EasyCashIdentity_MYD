using Business.Abstract;
using DataAccess.Concrete;
using Dto.Dtos;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;
        private readonly EasyCashContext _context;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService, EasyCashContext context)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomerSendMoneyForCustomerAccountProcessDto dto)
        {
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberId = _context.CustomerAccounts.Where(x => x.AccountNumber == dto.ReceiverAccountNumber).Select(x => x.Id).FirstOrDefault();

            var senderAccountNumberId = _context.CustomerAccounts.Where(x => x.AppUserId == user.Id)
                .Where(x => x.Currency == "TürkLirası")
                .Select(x => x.Id).FirstOrDefault();
                
            var values = new CustomerAccountProcess()
            {
             
                ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                SenderID = senderAccountNumberId,
                ProcessType="Havale",
                ReceiverID=receiverAccountNumberId,
                Amount=dto.Amount,
                Description = dto.Description
             };



            await _customerAccountProcessService.CreateAsync(values);
            return RedirectToAction("Index","Deneme");
        }
        

    }
}
