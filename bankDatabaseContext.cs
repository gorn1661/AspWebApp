using bankWebApi.Services.DatabaseModels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace bankWebApi.Services.Contexts
{
    public class bankDatabaseContext : DbContext
    {
        public DbSet<ClientModel> ClientModel { get; set; }
        public DbSet<ClientAccountModel> ClientAccountModel { get; set; }
        public DbSet<TransactionModel> TransactionModel { get; set; }
        public DbSet<EmployeeModel> EmployeeModel { get; set; }

        public bankDatabaseContext(DbContextOptions options): base(options){
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}