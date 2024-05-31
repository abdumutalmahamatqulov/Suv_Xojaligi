using Microsoft.AspNetCore.Identity;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Entities.Mains;
using Suv_Xojaligi.Data.Entities.Monitorings;
using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Contexts.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Suv_Xojaligi.Data.Contexts;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
    {
        this.Services = services;
    }
    public IServiceProvider Services { get; set; }
    public DbSet<Appeal> Appeals { get; set; }

    public DbSet<Entities.DWSH_Legal_Documents.Document> Documents { get; set; }
    public DbSet<Mains> Mains { get; set; }
    public DbSet<Monitoring> Monitorings { get; set; }
    public DbSet<New> News { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.ApplyConfiguration(new RoleConfiguration(Services));
        builder.ApplyConfiguration(new UserRoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
