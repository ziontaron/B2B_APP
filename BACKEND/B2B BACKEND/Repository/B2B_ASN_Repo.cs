using B2B_BACKEND.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Repository
{
  public class B2B_ASN_Repo: IB2B_ASN_Repo
  {
    private readonly IB2B_APP_Context _context;

    public B2B_ASN_Repo(IB2B_APP_Context context)
    {
      _context = context;
    }


  }
}
