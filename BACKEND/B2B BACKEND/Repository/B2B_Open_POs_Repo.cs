using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.EF;
using B2B_BACKEND.Models;
using B2B_BACKEND.Requests;
using B2B_BACKEND.ViewModels;
using Reusable;

namespace B2B_BACKEND.Repository
{
  public class B2B_Open_POs_Repo: IB2B_Open_POs_Repo
  {
    private readonly IB2B_APP_Context _context;
    public B2B_Open_POs_Repo(IB2B_APP_Context context)
    {
      _context = context;
    }

    public CommonResponse GetVendorOpenPOs(B2B_User_ViewModel User_Req) 
    {
      CommonResponse res = new CommonResponse();

      DataTable _t = new DataTable();   

      B2B_Users e = _context.B2B_Users.FirstOrDefault(u => u.UserID == User_Req.UserID );

      string _Skey = "";

      _Skey = _context.B2B_User_Verifivation(User_Req);

      if (_Skey == "")
      {
        return res.Error("User Not Found", null);
      }

      //if (e == null)
      //{
      //  return res.Error("User Not Found", null);
      //}
      //_Skey = _context.GenerateSHA(e.UserHash + e.Salt);
      //if(_Skey!= User_Req.Skey)
      //{
      //  return res.Error("User Not Found",null);
      //}

      _t = _context.GetOpenOrders(e.VendorID);

      List<B2B_PO_Head_ViewModel> PO_List = new List<B2B_PO_Head_ViewModel>();
      B2B_PO_Head_ViewModel _h = null;
      B2B_Rel_Acknowledge _Ack = null;

      foreach (DataRow r in _t.Rows)
      {
        _Ack = _context.B2B_Rel_Acknowledge.FirstOrDefault(u => u.FSPOLineKey == Convert.ToInt32(r["POLineKey"].ToString()));
        if (_h == null)
        {
          _h = new B2B_PO_Head_ViewModel
          {
            IsBlanket = (r["POLineSubType"].ToString() == "B") ? true : false,
            VendorID = r["VendorID"].ToString(),
            POLineKey = Convert.ToInt32(r["POLineKey"].ToString()),
            PONumber = r["PONumber"].ToString(),
            POLineNumber = r["POLineNumber"].ToString(),
            POLineType = r["POLineSubType"].ToString(),
            OrderedQuantity = Convert.ToInt32(r["LineItemOrderedQuantity"].ToString()),
            ReceiptQuantity = Convert.ToInt32(r["ReceiptQuantity"].ToString()),
            Balance = Convert.ToInt32(r["Balance"].ToString()),
            PromisedDate = (DateTime)r["OriginalPromisedDate"],

            ItemNumber = r["ItemNumber"].ToString(),
            ItemNumberDesc = r["ItemDescription"].ToString(),
            ItemUM = r["ItemUM"].ToString(),
            ItemRevision = r["ItemRevision"].ToString(),
            Releases = new List<B2B_PO_Release_ViewModel>()
          };
          if (_Ack != null)
          {
            _h.Acknowledge = new B2B_Rel_Acknowledge_ViewModel
            {
              Rel_AcknowledgeID = _Ack.Rel_AcknowledgeID,
              UserID = _Ack.UserID,
              FSPOLineKey = _Ack.FSPOLineKey,
              VendorID = _Ack.VendorID,
              Acknowledge = _Ack.Acknowledge,
              AcknowledgeDate = _Ack.AcknowledgeDate,
              Notes = _Ack.Notes

            };
          }
        }
        else
        {
          _Ack = _context.B2B_Rel_Acknowledge.FirstOrDefault(u => u.FSPOLineKey == Convert.ToInt32(r["POLineKey"].ToString()));
        switch (r["POLineSubType"].ToString())
          {
            case "B":
              {
                #region New Blancket
                PO_List.Add(_h);

                _h = new B2B_PO_Head_ViewModel
                {
                  IsBlanket = (r["POLineSubType"].ToString() == "B") ? true : false,
                  VendorID = r["VendorID"].ToString(),
                  POLineKey = Convert.ToInt32(r["POLineKey"].ToString()),
                  PONumber = r["PONumber"].ToString(),
                  POLineNumber = r["POLineNumber"].ToString(),
                  POLineType = r["POLineSubType"].ToString(),
                  OrderedQuantity = Convert.ToInt32(r["LineItemOrderedQuantity"].ToString()),
                  ReceiptQuantity = Convert.ToInt32(r["ReceiptQuantity"].ToString()),
                  Balance = Convert.ToInt32(r["Balance"].ToString()),
                  PromisedDate = (DateTime)r["OriginalPromisedDate"],

                  ItemNumber = r["ItemNumber"].ToString(),
                  ItemNumberDesc = r["ItemDescription"].ToString(),
                  ItemUM = r["ItemUM"].ToString(),
                  ItemRevision = r["ItemRevision"].ToString(),
                  Releases = new List<B2B_PO_Release_ViewModel>()
                };
                if (_Ack != null)
                {
                  _h.Acknowledge = new B2B_Rel_Acknowledge_ViewModel
                  {
                    Rel_AcknowledgeID = _Ack.Rel_AcknowledgeID,
                    UserID = _Ack.UserID,
                    FSPOLineKey = _Ack.FSPOLineKey,
                    VendorID = _Ack.VendorID,
                    Acknowledge = _Ack.Acknowledge,
                    AcknowledgeDate = _Ack.AcknowledgeDate,
                    Notes = _Ack.Notes
                  };
                }
                  #endregion
                  break;
              }
            case "S":
              {
              #region PO Blanket Release
              B2B_PO_Release_ViewModel rel = new B2B_PO_Release_ViewModel
              {
                POLineKey = Convert.ToInt32(r["POLineKey"].ToString()),
                POLineType = r["POLineSubType"].ToString(),
                OrderedQuantity = Convert.ToInt32(r["LineItemOrderedQuantity"].ToString()),
                ReceiptQuantity = Convert.ToInt32(r["ReceiptQuantity"].ToString()),
                Balance = Convert.ToInt32(r["Balance"].ToString()),
                PromisedDate = (DateTime)r["OriginalPromisedDate"]
              };

                if (_Ack != null)
                {
                  rel.Acknowledge = new B2B_Rel_Acknowledge_ViewModel
                  {
                    Rel_AcknowledgeID = _Ack.Rel_AcknowledgeID,
                    UserID = _Ack.UserID,
                    FSPOLineKey = _Ack.FSPOLineKey,
                    VendorID = _Ack.VendorID,
                    Acknowledge = _Ack.Acknowledge,
                    AcknowledgeDate = _Ack.AcknowledgeDate,
                    Notes = _Ack.Notes
                  };
                }
              _h.Releases.Add(rel);
                #endregion
              break;
              }
            default:
              {
                if (_Ack != null)
                {
                  _h.Acknowledge = new B2B_Rel_Acknowledge_ViewModel
                  {
                    Rel_AcknowledgeID = _Ack.Rel_AcknowledgeID,
                    UserID = _Ack.UserID,
                    FSPOLineKey = _Ack.FSPOLineKey,
                    VendorID = _Ack.VendorID,
                    Acknowledge = _Ack.Acknowledge,
                    AcknowledgeDate = _Ack.AcknowledgeDate,
                    Notes = _Ack.Notes
                  };
                }
                PO_List.Add(_h);
                break;
              }

          }
        }

      }
      if (PO_List[PO_List.Count-1] != _h)
      {
        if (_Ack != null)
        {
          _h.Acknowledge = new B2B_Rel_Acknowledge_ViewModel
          {
            Rel_AcknowledgeID = _Ack.Rel_AcknowledgeID,
            UserID = _Ack.UserID,
            FSPOLineKey = _Ack.FSPOLineKey,
            VendorID = _Ack.VendorID,
            Acknowledge = _Ack.Acknowledge,
            AcknowledgeDate = _Ack.AcknowledgeDate,
            Notes = _Ack.Notes
          };
        }
        PO_List.Add(_h);
      }

      return res.Success(PO_List);
    }

    public CommonResponse GetVendorPOLinesReport(B2B_User_ViewModel User_Req, string POno)
    {
      CommonResponse res = new CommonResponse();
      B2B_PO_Report repData = new B2B_PO_Report();
      repData= _context.Load_POln_RepData(POno);
      return res.Success(repData);
    }
  }
}
