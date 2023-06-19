
namespace Entitiy.Concrete;

public class CustomerAccountProcess
{
    public Guid Id { get; set; }
    public string ProcessType { get; set; }
    public decimal Amount { get; set; }

    public DateTime ProcessDate { get; set; }
}

