

namespace Dto.Dtos;

public class CustomerSendMoneyForCustomerAccountProcessDto
{
    public string ProcessType { get; set; }
    public decimal Amount { get; set; }

    public DateTime ProcessDate { get; set; }
    public string? Description { get; set; }
    public int SenderID { get; set; }
    public string ReceiverAccountNumber { get; set; }
    public int ReceiverID { get; set; }

 
}
