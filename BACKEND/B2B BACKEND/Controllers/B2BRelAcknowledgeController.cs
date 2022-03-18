﻿using B2B_BACKEND.Repository;
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
  public class B2BRelAcknowledgeController : ControllerBase
  {
    private readonly IB2B_Rel_Acknowledge_Repo _IB2B_Rel_Acknowledge_Repo;
    public B2BRelAcknowledgeController(IB2B_Rel_Acknowledge_Repo IB2B_Rel_Acknowledge_Repo)
    {
      _IB2B_Rel_Acknowledge_Repo = IB2B_Rel_Acknowledge_Repo;
    }

    [HttpPost]
    [Route("Acknowledge")]
    public async Task<IActionResult> AcknowledgeRelese(AcknowledgeModelRequest req) 
    {
      await _IB2B_Rel_Acknowledge_Repo.AddAcknowledge(req);
      return Ok();
    }
  }
}
