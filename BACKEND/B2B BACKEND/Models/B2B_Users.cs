using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.Models
{
  public partial class B2B_Users
  {
    [Key]
    public int UserID { get; set; }
    [Required]
    [StringLength(15)]
    public string UserName { get; set; }
    [Required]
    [StringLength(15)]
    public string VendorID { get; set; }
    [Required]
    public string UserHash { get; set; }
    [Required]
    public string Salt { get; set; }

    public DateTime LastLogin { get; set; }
    public DateTime CreatedDate { get; set; }

  }
}
