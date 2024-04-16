using Microsoft.EntityFrameworkCore;
using TesteSenior.Datas.Maps;
using TesteSenior.Models;

namespace TesteSenior.Datas
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SeniorDB");
        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
