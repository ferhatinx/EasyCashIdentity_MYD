
namespace Entitiy.Concrete;

public class CustomerAccountProcess
{
    public Guid Id { get; set; }
    public string ProcessType { get; set; }
    public decimal Amount { get; set; }

    public DateTime ProcessDate { get; set; }

    public Guid? SenderID { get; set; }
    public Guid? ReceiverID { get; set; }

    public CustomerAccount SenderCustomer { get; set; }
    public CustomerAccount ReceiverCustomer { get; set; }
}

