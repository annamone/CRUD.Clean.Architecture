using CredoTasks.CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CredoTasks.CRUD.Domain.Common;

namespace CredoTasks.CRUD.Infrastructure
{
    public class CredoTasksDbContext : DbContext
    {
        public CredoTasksDbContext(DbContextOptions<CredoTasksDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<CommonEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
