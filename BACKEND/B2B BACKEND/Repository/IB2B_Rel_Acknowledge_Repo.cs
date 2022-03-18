using B2B_BACKEND.EF;
using B2B_BACKEND.Models;
using B2B_BACKEND.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Repository
{
  public interface IB2B_Rel_Acknowledge_Repo
  {
    Task AddAcknowledge(AcknowledgeModelRequest model);
  }
}
