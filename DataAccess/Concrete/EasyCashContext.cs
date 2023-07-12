

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CustomerAccountProcess>()
            .HasOne(x => x.SenderCustomer)
            .WithMany(x => x.CustomerSender)
            .HasForeignKey(x => x.SenderID)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.Entity<CustomerAccountProcess>()
            .HasOne(x => x.ReceiverCustomer)
            .WithMany(x => x.CustomerReceiver)
            .HasForeignKey(x => x.ReceiverID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        base.OnModelCreating(builder);
    }
}
