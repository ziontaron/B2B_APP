using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.EF;
using B2B_BACKEND.Models;
using B2B_BACKEND.Requests;
using B2B_BACKEND.ViewModels;
using Reusable;

namespace B2B_BACKEND.Repository
{
  public class B2B_User_Repo: IB2B_User_Repo
  {
    private readonly IB2B_APP_Context _context;

    public B2B_User_Repo(IB2B_APP_Context context)
    {
      _context = context;
    }

    public CommonResponse Login(UserLogInRequest User_Req )
    {
      B2B_User_ViewModel user;
      CommonResponse res = new CommonResponse();


      B2B_Users e = _context.B2B_Users.FirstOrDefault(u => u.UserName == User_Req.UserName);
      if (e != null)
      {
        string saltedPass = User_Req.UserPass + e.Salt;
        string SHAPass = _context.GenerateSHA(saltedPass);
        if (e.UserHash == SHAPass)
        {
          user = new B2B_User_ViewModel
          {
            UserID = e.UserID,
            IsLogged = true,
            Skey = _context.GenerateSHA(SHAPass + e.Salt)
          };
          res.Success(user);
        }
      }
      else {
        res.Error("Invalid User Name or Password", null);
      }

      return res;
    }
    public async Task AddUser(B2B_Users model)
    {
      try
      {
        B2B_Users e = _context.B2B_Users.FirstOrDefault(u => u.UserName == model.UserName);
        if (e == null)
        {
          model.Salt = _context.RandomSalt(8);
          string SaltedPass = (model.UserHash + model.Salt);
          model.UserHash = _context.GenerateSHA(SaltedPass);
          model.CreatedDate = DateTime.Now;
          await _context.B2B_Users.AddAsync(model);
          await _context.SaveChangesAsync();
        }
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

    public void Update(B2B_Users model)
    {
      B2B_Users e = _context.B2B_Users.FirstOrDefault(u => u.UserID == model.UserID);
      if (e != null)
      {
        string salt = _context.RandomSalt(8);
        string SaltedPass = model.UserHash + salt;

        e.UserName = model.UserName;
        e.VendorID = model.VendorID;
        e.UserHash = _context.GenerateSHA(SaltedPass);
        e.Salt = salt;

        _context.B2B_Users.Update(e);

        int i = _context.SaveChanges();
      }
      ///return model;
    }
  }
}
