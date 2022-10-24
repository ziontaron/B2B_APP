using B2B_BACKEND.EF;
using B2B_BACKEND.Models;
using B2B_BACKEND.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.EF;
using B2B_BACKEND.Models;
using B2B_BACKEND.Requests;
using B2B_BACKEND.ViewModels;
using Reusable;

namespace B2B_BACKEND.Repository
{
  public class B2B_Rel_Acknowledge_Repo: IB2B_Rel_Acknowledge_Repo
  {
    private readonly IB2B_APP_Context _context;

    public B2B_Rel_Acknowledge_Repo(IB2B_APP_Context context)
    {
      _context = context;
    }
    public CommonResponse AddAcknowledge(AcknowledgeModelRequest model)
    {
      CommonResponse res = new CommonResponse();
      B2B_Rel_Acknowledge e = _context.B2B_Rel_Acknowledge.FirstOrDefault(u => u.FSPOLineKey == model.FSPOLineKey);
      
      B2B_Users e2 = _context.B2B_Users.FirstOrDefault(u => u.UserID == model.UserID);

      string _Skey = "";

      if (e2 == null)
      {
        return res.Error("User Not Found", null);
      }
      _Skey = _context.GenerateSHA(e2.UserHash + e2.Salt);
      if (_Skey != model.Skey)
      {
        return res.Error("User Not Found", null);
      }

      if (e == null)
      {
        B2B_Users x = _context.B2B_Users.FirstOrDefault(u => u.UserID == model.UserID);
        e = new B2B_Rel_Acknowledge();
        e.FSPOLineKey = model.FSPOLineKey;
        e.Acknowledge = model.Acknowledge;
        e.Notes = model.Notes;
        e.UserID = model.UserID;
        e.AcknowledgeDate = DateTime.Now;
        e.VendorID = x.VendorID;
        e.UserID = x.UserID;
        //await _context.B2B_Rel_Acknowledge.AddAsync(e);
        //await _context.SaveChangesAsync();
        _context.B2B_Rel_Acknowledge.Add(e);
        _context.SaveChanges();
        return res.Success("Order Acknowledged", model);
      }
      else
      {
        return res.Success("Acknowledged Failed", null);
      }
    }
  }
}
