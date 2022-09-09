using Microsoft.EntityFrameworkCore;
using Contact.Center.Api.Models;


namespace Contact.Center.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Channel> Channels => Set<Channel>();
        public DbSet<Group>? Groups => Set<Group>();
        public DbSet<Kpi>? Kpis => Set<Kpi>();
    }
}