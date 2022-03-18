using B2B_BACKEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Repository
{
  public interface IB2B_User_Repo
  {
    Task AddUser(B2B_Users model);
    Task<B2B_Users> GetUser(int id);
    B2B_Users GetUserWhere(int id);
  }
}
