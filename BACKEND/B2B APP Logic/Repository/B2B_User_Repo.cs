using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.EF;
using B2B_BACKEND.Models;

namespace B2B_BACKEND.Repository
{
  public class B2B_User_Repo: IB2B_User_Repo
  {
    private readonly IB2B_APP_Context _context;

    public B2B_User_Repo(IB2B_APP_Context context)
    {
      _context = context;
    }

    public async Task AddUser(B2B_Users model)
    {
      try
      {
        await _context.B2B_Users.AddAsync(model);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        string x = ex.Message.ToString();
      }
    }

    public async Task<B2B_Users> GetUser(int id)
    {
      return await _context.B2B_Users.FindAsync(id);
    }
    public B2B_Users GetUserWhere(int id)
    {
      return _context.B2B_Users.Where(x => x.UserID == id).FirstOrDefault();
    }
  }
}
