

using Microsoft.AspNetCore.Identity;

namespace Entitiy.Concrete;

public class AppUser : IdentityUser<string>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string ImageUrl { get; set; }
    public int ConfirmCode { get; set; }
    public List<CustomerAccount> CustomerAccounts { get; set; }
}
