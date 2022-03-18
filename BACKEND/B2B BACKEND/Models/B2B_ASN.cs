using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Models
{
  public partial class B2B_ASN
  {
    [Key]
    public int ASNID { get; set; }
    [Required]
    public int Rel_AcknowledgeID { get; set; }
    public int UserID { get; set; }
    [Required]
    [StringLength(15)]
    public string VendorID { get; set; }

    [Required]
    public string Carrier { get; set; }
    [Required]
    public int Qty { get; set; }
    [Required]
    public string PackingSlip { get; set; }
    [Required]
    public string Lot { get; set; }
    [Required]
    public string TrakingNo { get; set; }
  }
}
