using B2B_BACKEND.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND.ViewModels
{
  public class B2B_PO_Head_ViewModel
  {

    //SELECT VendorID
    //          , PONumber
    //          , POLineNumber
    //          , POLineNumberString
    //          , POLineSubType
    //          , LineItemOrderedQuantity
    //          , ReceiptQuantity
    //          , Balance
    //          , OriginalPromisedDate
    //          , ItemNumber
    //          , ItemDescription
    //          , ItemUM
    //          , ItemRevision
    //          , POLineKey
    //          FROM _CAP_B2B_OPEN_POs

    //          WHERE(VendorID = '11505')
    //          ORDER BY  PONumber
    //          , NeededDate
    //          , POLineNumber
    //          , POLineSubType

    public bool IsBlanket { get; set; }
    public string VendorID { get; set; }
    public int POLineKey { get; set; }
    public string PONumber { get; set; }
    public string POLineNumber { get; set; }
    public string POLineType { get; set; }
    public int OrderedQuantity { get; set; }
    public int ReceiptQuantity { get; set; }
    public int Balance { get; set; }
    public DateTime PromisedDate { get; set; }

    public string ItemNumber { get; set; }
    public string ItemNumberDesc { get; set; }
    public string ItemUM { get; set; }
    public string ItemRevision { get; set; }
    public List<B2B_PO_Release_ViewModel> Releases { get; set; }
    public B2B_Rel_Acknowledge_ViewModel Acknowledge { get; set; }
  }
  public class B2B_PO_Release_ViewModel
  {
    public int POLineKey { get; set; }
    public string POLineType { get; set; }
    public int OrderedQuantity { get; set; }
    public int ReceiptQuantity { get; set; }
    public int Balance { get; set; }
    public DateTime PromisedDate { get; set; }
    public B2B_Rel_Acknowledge_ViewModel Acknowledge { get; set; }
  }
}
