using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;
using Configuration;

public class DBEntities : DbContext
{
    public DBEntities() : base("DBEntities")
    {
        this.Configuration.LazyLoadingEnabled = false;
        this.Configuration.AutoDetectChangesEnabled = false;
    }

    public void Commit()
    {
       base.SaveChanges();
    }

    public DbSet<Log> Logs { get; set; }
    public DbSet<LogType> LogTypes { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        modelBuilder.Configurations.Add(new LogConfiguration());
        modelBuilder.Configurations.Add(new LogTypeConfiguration());
    }

}