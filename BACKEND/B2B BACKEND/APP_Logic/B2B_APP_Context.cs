using Microsoft.EntityFrameworkCore;
using DB_MNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2B_BACKEND.Models;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using B2B_BACKEND.ViewModels;


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
    public B2B_PO_Report Load_POln_RepData(string PO)
    {
      B2B_PO_Report repData = new B2B_PO_Report();
      B2B_shipToAddress_Rep shipTo = new B2B_shipToAddress_Rep();
      B2B_vendorInfo_Rep vendorInfo = new B2B_vendorInfo_Rep();
      IList<B2B_POLines_Rep> POLns = new List<B2B_POLines_Rep>();
      decimal POTotal = 0;

      string _q = @"SELECT * FROM [_CAP_B2B_POLn_Rep]
                  WHERE PONumber = '" + PO +
                  "' ORDER BY POLineNumberString";

      DataTable _t = DB_MNG_FS.Execute_Query(_q);

      #region query
      /*
       SELECT PONumber
        , VendorID
        , POShipToName
        , POShipToAddress1
        , POShipToAddress2
        , POShipToCity
        , POShipToState
        , POShipToZip
        , POShipToCountry
        , POCreatedDate
        , POLastMaintainedDate
        , PORevision
        , POLineNumberString
        , ItemNumber
        , ItemDescription
        , ItemUM
        , ItemRevision
        , LineItemOrderedQuantity
        , ReceiptQuantity
        , OriginalPromisedDate
        , NeededDate
        , POLineSubType
        , StartDate
        , ItemUnitCost
        , TextID
        , TextLine1
        , AccountOrWorkOrderNumber
        , NonInventoryItemControllingUnitCost
        , Buyer
        , POContact
        , CarrierName
        , FOBPoint
        , ContractNumber
        , IsBlanketOrNonBlanket
        , POLineType
        , POLineStatus
        FROM _CAP_B2B_POLn_Rep
        WHERE PONumber = 'PO-072022-02'
        ORDER BY POLineNumberString
       */
      #endregion

      if (_t.Rows.Count > 0)
      {

        repData.poRevDate = ((DateTime)_t.Rows[0]["POLastMaintainedDate"]).ToString("MM/dd/yyyy");
        repData.po = _t.Rows[0]["PONumber"].ToString();
        repData.poOriginalDate = ((DateTime)_t.Rows[0]["POCreatedDate"]).ToString("MM/dd/yyyy");
        repData.contractNo = _t.Rows[0]["ContractNumber"].ToString();
        repData.contact = _t.Rows[0]["POContact"].ToString();

        #region vendor info

        vendorInfo.id = _t.Rows[0]["VendorID"].ToString();
        vendorInfo.contact = _t.Rows[0]["POContact"].ToString();
        vendorInfo.contactPhone = _t.Rows[0]["VendorContactPhone"].ToString();
        vendorInfo.vendorName = _t.Rows[0]["VendorName"].ToString();
        vendorInfo.address1 = _t.Rows[0]["VendorAddress1"].ToString();
        vendorInfo.address2 = _t.Rows[0]["VendorAddress2"].ToString();
        vendorInfo.city = _t.Rows[0]["VendorCity"].ToString();
        vendorInfo.state = _t.Rows[0]["VendorState"].ToString();
        vendorInfo.zipcode = _t.Rows[0]["VendorZip"].ToString();
        vendorInfo.country = _t.Rows[0]["VendorCountry"].ToString();

        repData.vendorInfo = vendorInfo;
        #endregion

        #region Ship to info
        shipTo.name = _t.Rows[0]["POShipToName"].ToString();
        shipTo.address1 = _t.Rows[0]["POShipToAddress1"].ToString();
        shipTo.address2 = _t.Rows[0]["POShipToAddress2"].ToString();
        shipTo.city = _t.Rows[0]["POShipToCity"].ToString();
        shipTo.state = _t.Rows[0]["POShipToState"].ToString();
        shipTo.zipcode = _t.Rows[0]["POShipToZip"].ToString();
        shipTo.country = _t.Rows[0]["POShipToCountry"].ToString();
        #endregion

        repData.shipToAddress = shipTo;
        repData.transportVia = _t.Rows[0]["CarrierName"].ToString();
        repData.fobPoint = _t.Rows[0]["FOBPoint"].ToString();
        repData.paymentTerm = "NET 45 DAYS (no DB)";
        repData.taxExemptNum = "3-82567-5708-9 (no DB)";
        repData.buyerInitials = _t.Rows[0]["Buyer"].ToString();
        repData.buyerName = "Edna Camargo (no DB)";

        #region PN Lines
        foreach (DataRow dr in _t.Rows)
        {
          B2B_POLines_Rep POln = new B2B_POLines_Rep();
          decimal unitcost = 0;

          POln.POLnKey = Convert.ToInt32(dr["POLineKey"].ToString());
          POln.POLn = dr["POLineNumberString"].ToString();
          POln.PN = (dr["ItemNumber"] == null ? "" : dr["ItemNumber"].ToString());
          POln.PNDescription = (dr["ItemDescription"].ToString() == "" ? dr["TextLine1"].ToString() : dr["ItemDescription"].ToString());
          POln.UM = dr["ItemUM"].ToString();
          POln.Rev = dr["ItemRevision"].ToString();
          POln.OrderedQty = Convert.ToInt32(dr["LineItemOrderedQuantity"].ToString());
          POln.ReceiptQty = Convert.ToInt32(dr["ReceiptQuantity"].ToString());
          POln.PromiDock = ((DateTime)dr["OriginalPromisedDate"]).ToString("MM/dd/yyyy");
          unitcost = Convert.ToDecimal(
            (dr["ItemUnitCost"].ToString() == "" ?
            dr["NonInventoryItemControllingUnitCost"].ToString() :
            dr["ItemUnitCost"].ToString())
            );
          POln.UnitPrice = unitcost;
          POTotal += unitcost * (POln.OrderedQty - POln.ReceiptQty);
          POln.ExtendedPrice = unitcost * (POln.OrderedQty - POln.ReceiptQty);
          POLns.Add(POln);
        }
        #endregion
        repData.polines = POLns;
        repData.ExtendedAmount = POTotal;
      }


      return repData;
    }
    public string B2B_User_Verifivation(B2B_User_ViewModel User_Req)
    {
      B2B_Users e = B2B_Users.FirstOrDefault(u => u.UserID == User_Req.UserID);

      string _Skey = "";
      if (e == null)
      {
        return "";
      }
      _Skey = GenerateSHA(e.UserHash + e.Salt);
      if (_Skey != User_Req.Skey)
      {
        return "";
      }

      return _Skey;
    }
  }
}
