using Microsoft.EntityFrameworkCore;
using SitesApi.Models;

namespace SitesApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Site> Sites { get; set; }
}
