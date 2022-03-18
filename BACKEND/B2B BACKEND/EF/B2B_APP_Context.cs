using Microsoft.EntityFrameworkCore;
using DB_MNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.Models;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace B2B_BACKEND.EF
{
  public partial class B2B_APP_Context : DbContext, IB2B_APP_Context
  {
    private static Random random = new Random();
    public SQL DB_MNG;
    public SQL DB_MNG_FS;
    public B2B_APP_Context(DbContextOptions<B2B_APP_Context> opt) : base(opt)
    {     
      DB_MNG_FS = new SQL("192.168.0.9", "FSDBMR", "AmalAdmin", "Amalgamma16");
    }
    public DbSet<B2B_Users> B2B_Users { get; set; }
    public DbSet<B2B_Rel_Acknowledge> B2B_Rel_Acknowledge { get; set; }
    public DbSet<B2B_ASN> B2B_ASN { get; set; }

  }
}
