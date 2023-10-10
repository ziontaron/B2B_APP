using B2B_BACKEND.Models;
using B2B_BACKEND.Repository;
using B2B_BACKEND.Requests;
using Microsoft.AspNetCore.Cors;
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
  public class B2BUserController : Controller 
  {
    private readonly IB2B_User_Repo _IB2B_User_Repo;
    public B2BUserController(IB2B_User_Repo IB2B_User_Repo)
    {
      _IB2B_User_Repo = IB2B_User_Repo;
    }

    [HttpPost]
    [Route("Login")]
    public CommonResponse VendorLogin([FromBody] UserLogInRequest req)
    {
      return _IB2B_User_Repo.Login(req);
    }

    [HttpGet]
    [Route("getid/{Id}")]
    public async Task<ActionResult> VendorGetbyId(int Id)
    {
      var entity = await _IB2B_User_Repo.GetUser(Id);

      return Ok();
    }

    [HttpGet]
    [Route("getwhere/{Id}")]
    public ActionResult VendorGetwhere(int Id)
    {
      var entity = _IB2B_User_Repo.GetUserWhere(Id);

      return Ok();
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> VendorRegister([FromBody] UserRegisterRequest req)
    {
      var e = new B2B_Users
      {
        UserID = 0,
        VendorID = req.VendorID,
        UserName = req.UserName,
        UserHash = req.Pass,
        Salt = ""
      };
      await _IB2B_User_Repo.AddUser(e);
      return Ok();
    }

    [HttpPut]
    [Route("ResetAccess")]
    public IActionResult VendorResetAccess([FromBody] UserRegisterRequest req) 
    {
      var e = new B2B_Users
      {
        UserID = req.UserID,
        VendorID = req.VendorID,
        UserName = req.UserName,
        UserHash = req.Pass,
        Salt = ""
      };
       _IB2B_User_Repo.Update(e);

      return Ok();

    }
}
}
