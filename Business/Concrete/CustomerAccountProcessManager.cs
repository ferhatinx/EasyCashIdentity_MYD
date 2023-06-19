

using Business.Abstract;
using DataAccess.Abstract;
using Entitiy.Concrete;

namespace Business.Concrete;

public class CustomerAccountProcessManager : Service<CustomerAccountProcess>, ICustomerAccountProcessService
{
    public CustomerAccountProcessManager(IRepository<CustomerAccountProcess> repository) : base(repository)
    {
    }
}
