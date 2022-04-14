using B2B_BACKEND.Repository;
using B2B_BACKEND.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class B2BASNController : ControllerBase
  {
    private readonly IB2B_ASN_Repo _IB2B_ASN_Repo;

    public B2BASNController(IB2B_ASN_Repo IB2B_ASN_Repo)
    {
      _IB2B_ASN_Repo = IB2B_ASN_Repo;
    }

  }
}
