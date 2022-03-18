using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Requests
{
  public class UserLogInRequest
  {
    public string UserName { get; set; }
    public string UserPass { get; set; }
  }
  public class UserRegisterRequest
  {
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string VendorID { get; set; }
    public string Pass { get; set; }
  }
}
