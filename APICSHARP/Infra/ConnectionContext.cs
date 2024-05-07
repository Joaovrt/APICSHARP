using APICSHARP.Domain.Model.CompanyAggregate;
using APICSHARP.Domain.Model.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace APICSHARP.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432;Database=APICSHARP;" +
              "User Id=postgres;" +
              "Password=123;");
    }
}
