using Microsoft.EntityFrameworkCore;
using DB_MNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.Models;
using System.Threading;

namespace B2B_BACKEND.EF
{
  public class B2B_APP_Context : DbContext, IB2B_APP_Context
  {
    public SQL DB_MNG;
    public SQL DB_MNG_FS;
    private string ConnString= @"Server = 192.168.0.11; Database = B2B_APP; User Id = AmalAdmin; Password = Amalgamma16; trustServerCertificate=true; ";
    public B2B_APP_Context()
    {
    }
    public B2B_APP_Context(DbContextOptions<B2B_APP_Context> opt) : base(opt)
    {     
      DB_MNG_FS = new SQL("192.168.0.9", "FSDBMR", "AmalAdmin", "Amalgamma16");
    }
    public DbSet<B2B_Users> B2B_Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(ConnString);
      }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
      
    }

  }
}
