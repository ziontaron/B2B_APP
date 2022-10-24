using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Requests
{
  public class AcknowledgeModelRequest
  {
    public int FSPOLineKey { get; set; }
    public int UserID { get; set; }
    public string Skey { get; set; }
    public string Acknowledge { get; set; }
    public string Notes { get; set; }

  }
}
