

using Entitiy.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EasyCashContext : IdentityDbContext<AppUser,AppRole,string>
{
    public EasyCashContext(DbContextOptions<EasyCashContext> options) : base(options)
    {

    }

    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
}
