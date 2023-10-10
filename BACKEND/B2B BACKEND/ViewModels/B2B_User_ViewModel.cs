using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.ViewModels
{
  public class B2B_User_ViewModel
  {
    public int UserID { get; set; }
    public bool IsLogged { get; set; }
    public string Skey { get; set; }
  }
  public class B2B_PO_Report {
    public string poRevDate { get; set; }
    public string po { get; set; }
    public string poOriginalDate { get; set; }
    public string contractNo { get; set; }
    public string contact { get; set; }
    public B2B_vendorInfo_Rep vendorInfo { get; set; }
    public B2B_shipToAddress_Rep shipToAddress { get; set; }
    public string transportVia { get; set; }
    public string fobPoint { get; set; }
    public string paymentTerm { get; set; }
    public string taxExemptNum { get; set; }
    public string buyerInitials { get; set; }
    public string buyerName { get; set; }
    public decimal ExtendedAmount { get; set; }
    public IList<B2B_POLines_Rep> polines { get; set; } 
  }

  public class B2B_vendorInfo_Rep {

    public string id { get; set; }
    public string contact { get; set; }
    public string contactPhone { get; set; }
    public string vendorName { get; set; }
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipcode { get; set; }
    public string country { get; set; }

  }
  public class B2B_shipToAddress_Rep {
    public string name { get; set; }
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipcode { get; set; }
    public string country { get; set; }
  }
  public class B2B_POLines_Rep
  {
    public int POLnKey { get; set; }
    public string POLn { get; set; }
    public string PN { get; set; }
    public string PNDescription { get; set; }
    public string UM { get; set; }
    public string Rev { get; set; }
    public int OrderedQty { get; set; }
    public int ReceiptQty { get; set; }
    public string PromiDock { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal ExtendedPrice { get; set; }
    public string POLineSubType { get; set; }
  }

}

