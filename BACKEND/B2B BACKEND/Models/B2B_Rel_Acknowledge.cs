using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Models
{
  public partial class B2B_Rel_Acknowledge
  {
    [Key]
    public int Rel_AcknowledgeID { get; set; }
    public int UserID { get; set; }

    [Required]
    public int FSPOLineKey { get; set; }
    [Required]
    [StringLength(15)]
    public string VendorID { get; set; }
    [Required]
    public string Acknowledge { get; set; }

    public DateTime AcknowledgeDate { get; set; }
    public string Notes { get; set; }

  }
}
