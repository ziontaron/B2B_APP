using B2B_BACKEND.Models;
using B2B_BACKEND.Repository;
using B2B_BACKEND.Requests;
using B2B_BACKEND.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reusable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class B2BOpen_POsController : Controller
  {
    private readonly IB2B_Open_POs_Repo _IB2B_Open_POs_Repo;
    public B2BOpen_POsController(IB2B_Open_POs_Repo IB2B_Open_POs_Repo)
    {
      _IB2B_Open_POs_Repo = IB2B_Open_POs_Repo;
    }

    [HttpPost]
    [Route("GetOpenPOs")]
    public CommonResponse GetOpenPOs([FromBody] B2B_User_ViewModel req)
    {
      CommonResponse res = new CommonResponse();
      res.Success(_IB2B_Open_POs_Repo.GetVendorOpenPOs(req),null);
      return res;

    }
    [HttpPost]
    [Route("GetPOsRep")]
    public CommonResponse GetPOsRep([FromBody] B2B_User_ViewModel req, string PO)
    {
      //return _IB2B_Open_POs_Repo.GetVendorPOLinesReport(req, "PO-072022-02");
      return _IB2B_Open_POs_Repo.GetVendorPOLinesReport(req, PO);

    }
  }
}
