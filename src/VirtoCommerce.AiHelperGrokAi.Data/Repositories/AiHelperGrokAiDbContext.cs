using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace VirtoCommerce.AiHelperGrokAi.Data.Repositories;

public class AiHelperGrokAiDbContext : DbContextBase
{
    public AiHelperGrokAiDbContext(DbContextOptions<AiHelperGrokAiDbContext> options)
        : base(options)
    {
    }

    protected AiHelperGrokAiDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<AiHelperGrokAiEntity>().ToTable("AiHelperGrokAi").HasKey(x => x.Id);
        //modelBuilder.Entity<AiHelperGrokAiEntity>().Property(x => x.Id).HasMaxLength(IdLength).ValueGeneratedOnAdd();

        switch (Database.ProviderName)
        {
            case "Pomelo.EntityFrameworkCore.MySql":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.AiHelperGrokAi.Data.MySql"));
                break;
            case "Npgsql.EntityFrameworkCore.PostgreSQL":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.AiHelperGrokAi.Data.PostgreSql"));
                break;
            case "Microsoft.EntityFrameworkCore.SqlServer":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.AiHelperGrokAi.Data.SqlServer"));
                break;
        }
    }
}
