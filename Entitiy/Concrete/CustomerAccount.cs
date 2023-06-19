

namespace Entitiy.Concrete;

public class CustomerAccount
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }

    public string Currency { get; set; }

    public decimal Balance { get; set; }

    public string  BankBranch { get; set; }

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

}
