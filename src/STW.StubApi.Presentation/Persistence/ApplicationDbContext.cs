namespace STW.StubApi.Presentation.Persistence;

using Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<HttpTransaction> HttpTransactions { get; set; }
}
