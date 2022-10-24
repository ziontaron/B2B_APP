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
using System.Data;
using B2B_BACKEND.ViewModels;

namespace B2B_BACKEND.EF
{
  public interface IB2B_APP_Context
  {
    DbSet<B2B_Users> B2B_Users { get; set; }
    DbSet<B2B_ASN> B2B_ASN { get; set; }
    DbSet<B2B_Rel_Acknowledge> B2B_Rel_Acknowledge { get; set; }
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    int SaveChanges();
    void RemoveRange(IEnumerable<object> entities);
    EntityEntry Update(object entity);

    string RandomSalt(int length);
    string GenerateSHA(string toEncrypt);
    DataTable GetOpenOrders(string VendorID);

    public B2B_PO_Report Load_POln_RepData(string PO);

    public string B2B_User_Verifivation(B2B_User_ViewModel User_Req);
  }
}
