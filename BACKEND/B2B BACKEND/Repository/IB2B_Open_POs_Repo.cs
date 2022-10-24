using B2B_BACKEND.ViewModels;
using Reusable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Repository
{
  public interface IB2B_Open_POs_Repo
  {
    CommonResponse GetVendorOpenPOs(B2B_User_ViewModel User_Req);

    CommonResponse GetVendorPOLinesReport(B2B_User_ViewModel User_Req,string POno);
  }
}
