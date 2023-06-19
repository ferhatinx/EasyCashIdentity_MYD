

using Business.Abstract;
using DataAccess.Abstract;
using Entitiy.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class CustomerAccountManager : Service<CustomerAccount>, ICustomerAccountService
{
    public CustomerAccountManager(IRepository<CustomerAccount> repository) : base(repository)
    {
    }
}
