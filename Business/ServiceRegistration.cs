

using Business.Abstract;
using Business.Concrete;
using Business.Configurations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entitiy.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class ServiceRegistration
{
    public static void AddDepedency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EasyCashContext>(opt =>
        {

            opt.UseSqlServer(configuration.GetConnectionString("local"));

        });

        services.AddIdentity<AppUser,AppRole>(opt => { 
            opt.Password.RequireNonAlphanumeric = false; 
            opt.Password.RequireDigit = false;    
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
           
        
        }).AddEntityFrameworkStores<EasyCashContext>().AddErrorDescriber<CustomIdentityValidator>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICustomerAccountProcessService,CustomerAccountProcessManager>();
    }
}
