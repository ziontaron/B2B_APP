using Microsoft.EntityFrameworkCore;
using DB_MNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace B2B_BACKEND.EF
{
  public interface IB2B_APP_Context
  {
    DbSet<B2B_Users> B2B_Users { get; set; }

    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    void RemoveRange(IEnumerable<object> entities);
    EntityEntry Update(object entity);

  }
}
