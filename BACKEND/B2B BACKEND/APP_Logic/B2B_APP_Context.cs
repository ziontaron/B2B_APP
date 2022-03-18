using B2B_BACKEND.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace B2B_BACKEND.EF
{
  public partial class B2B_APP_Context : DbContext, IB2B_APP_Context
  {
    public string RandomSalt(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(chars, 8)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public string GenerateSHA(string toEncrypt)
    {
      string Encrypted = "";
      using (SHA256 mySHA256 = SHA256.Create())
      {
        Encoding enc = Encoding.UTF8;
        byte[] hashValue = mySHA256.ComputeHash(enc.GetBytes(toEncrypt));
        Encrypted = Convert.ToBase64String(hashValue);
      }
      return Encrypted;
    }
    public DataTable GetOpenOrders(string VendorID)
    {
      DataTable _t = new DataTable();

      string OPEN_POs = @"
              SELECT VendorID
              , PONumber
              , POLineNumber
              , POLineNumberString
              , POLineSubType
              , LineItemOrderedQuantity
              , ReceiptQuantity
              , Balance
              , OriginalPromisedDate
              , ItemNumber
              , ItemDescription
              , ItemUM
              , ItemRevision
              , POLineKey
              FROM _CAP_B2B_OPEN_POs

              WHERE (VendorID = '{0}') 
              ORDER BY  PONumber
              , NeededDate
              , POLineNumber
              , POLineSubType
              ";

      OPEN_POs = String.Format(OPEN_POs, VendorID);
      _t = DB_MNG_FS.Execute_Query(OPEN_POs);

      return _t;
    }
  }
}
