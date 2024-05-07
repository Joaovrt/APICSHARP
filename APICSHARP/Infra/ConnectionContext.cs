﻿using APICSHARP.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace APICSHARP.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432;Database=APICSHARP;" +
              "User Id=postgres;" +
              "Password=123;");
    }
}
