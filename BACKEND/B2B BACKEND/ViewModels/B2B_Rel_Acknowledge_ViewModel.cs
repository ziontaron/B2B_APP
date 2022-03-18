using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.ViewModels
{
  public class B2B_Rel_Acknowledge_ViewModel
  {
    public int Rel_AcknowledgeID { get; set; }
    public int UserID { get; set; }
    public int FSPOLineKey { get; set; }
    public string VendorID { get; set; }
    public string Acknowledge { get; set; }
    public DateTime AcknowledgeDate { get; set; }
    public string Notes { get; set; }
  }
}
