import * as React from "react";
import "./ComponentToPrint.css";

export const ComponentToPrint = React.forwardRef((props, ref) => {
  const repData = props.repData;

  const logo = require("./rep-img/CapsonicLogo.jpg");
  return (
    <div className='sheet-margin' ref={ref}>
      <div className='report-header'>
        <div className='report-header-item'>
          <p>CAPSONIC AUTOMOTIVE, INC.</p>
          <p>7B ZANE GREY STREET</p>
          <p>EL PASO TX</p>
          <p>79906 USA</p>
        </div>
        <div className='report-header-item'>
          <img src={logo} alt=''></img>
        </div>
        <div className='report-header-item'>
          <div className='report-header-item-content'>
            <p>
              PO REV DATE: <b>{repData.poRevDate}</b>
            </p>
            <p>
              PO: <b>{repData.po}</b>
            </p>
          </div>
        </div>
      </div>
      <div className='report-content'>
        <div className='report-content-item'>
          <p>PO REV ORIGINAL PO DATE: {repData.poOriginalDate}</p>
          <p>
            CONTACT: <b>{repData.vendorInfo.contact}</b>
          </p>
          <p>
            CONTACT NUMBER: <b>{repData.vendorInfo.contactPhone}</b>
          </p>
        </div>
        <div className='report-content-addresses'>
          <div className='ship-from'>
            <p>
              Vendor ID: <b>{repData.vendorInfo.id}</b>
            </p>
            <p>{repData.vendorInfo.vendorName}</p>
            <p>{repData.vendorInfo.address1}</p>
            <p>{repData.vendorInfo.address2}</p>
            <p>
              {repData.vendorInfo.city} {repData.vendorInfo.state}
            </p>
            <p>
              {repData.vendorInfo.zipcode} {repData.vendorInfo.country}
            </p>
          </div>
          <div className='ship-to'>
            <p>
              SHIP TO: <b>{repData.shipToAddress.name}</b>
            </p>
            <p>{repData.shipToAddress.address1}</p>
            <p>{repData.shipToAddress.address2}</p>
            <p>
              {repData.shipToAddress.city} {repData.shipToAddress.state}
            </p>
            <p>
              {repData.shipToAddress.zipcode} {repData.shipToAddress.country}
            </p>
          </div>
        </div>
        <div className='report-content-item'>
          <div>
            <p>TRANSPORT VIA: {repData.transportVia}</p>
            <p>FOB POINT: {repData.fobPoint}</p>
          </div>
          <div>
            <p>PAYMENT TERMS: {repData.paymentTerm}</p>
            <p>TAX EXEMPT NUMBER: {repData.taxExemptNum}</p>
          </div>
        </div>
        <div className='report-content-item'>
          <table className='table'>
            <thead>
              <tr>
                <th>LN#</th>
                <th>Item</th>
                <th>Description</th>
                <th>UM</th>
                <th>REV</th>
                <th>Order Qty</th>
                <th>Balance</th>
                <th>Promised Dock</th>
                <th>Unit Price</th>
                <th>Extended Price</th>
              </tr>
            </thead>
            <tbody>
              {repData.POLines.map((POln) => (
                <tr key={POln.key}>
                  <td className='field-center'>{POln.POLn}</td>
                  <td>{POln.PN}</td>
                  <td>{POln.PNDescription}</td>
                  <td className='field-center'>{POln.UM}</td>
                  <td className='field-center'>{POln.Rev}</td>
                  <td className='field-right'>{POln.OrderedQty}</td>
                  <td className='field-right'>
                    {POln.OrderedQty - POln.ReceiptQty}
                  </td>
                  <td className='field-center'>{POln.PromiDock}</td>
                  <td className='field-right'>{POln.UnitPrice}</td>
                  <td className='field-right'>{POln.ExtendedPrice}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <div className='report-separator'></div>
      <div className='report-footer'>
        <div>
          <p>
            ALL COMPONENTS MANUFACTURED FOR THIS PO MUST SATISFY CURRENT
            GOVERNMENT & SAFETY CONSTRAINTS ON RESTRICTED TOXIC & HAZARDOUS
            MATERIALS AS WELL AS ENVIRONMENTAL, ELECTRICAL AND ELECTROMAGNETIC
            CONDITIONS FOR COUNTRY OF MANUFACTURE & SALE
          </p>
          <br />
          <p>
            Any acceptance of purchase orders contained herein is acceptance to
            Capsonics Terms and agreements and Quality Supplier Manual. Both can
            be found at (
            <a href='www.capsonic.com/auto/suppliers'>
              www.capsonic.com/auto/suppliers
            </a>
            . Also note all Honeywell parts must conform to Spoc Manual latest
            revision level ( request copy if needed).
          </p>
          <br />
          <p>
            Any acceptance of purchase orders contained herein is acceptance to
            Capsonics Terms and agreements and Quality Supplier Manual. Both can
            be found at (<a href='http://www.capsonic.com'>www.capsonic.com</a>
            ).
          </p>
          <br />
          <p>
            <b>
              Must comply to QAP-8.1.4-001 Counterfeit Control Procedure Rev.2
              per supplier manual Supplier commits to maintain proper controls
              when procuring material to satisfy this order based on recommended
              controls and procedures as established in AS5553 and AS6174
              standards for counterfeit materials and electronic components
              controls
            </b>
          </p>
          <br />
          <p>
            For shelf life items we require 75% shelf life at minimum at time of
            arrival. Less than percentage required is subject to rejection and
            return at suppliers expense.
          </p>
          <br />
          <p>
            This purchase order is governed by the Capsonic Terms and Conditions
            and Supplier Manual, by accepting this agreement it is acknowledged
            that this product will be provided to Capsonic under these
            provisions free of exception.
          </p>
          <br />
          <p>
            Capsonic’s Terms and Conditions and Supplier Manual can be found in
            the Capsonic website{" "}
            <a href='http://www.capsonic.com/CA2/value-stream/supplier-development/'>
              http://www.capsonic.com/CA2/value-stream/supplier-development/
            </a>
          </p>
        </div>
        <div className='sign-and-total'>
          <div>
            <p>AUTHORIZED BY:_____________</p>
            <br />
            <p>
              BUYER: {repData.buyerInitials}={repData.buyerName}
            </p>
          </div>
          <div>
            <p>TOTAL EXTENDED AMOUNT</p>
            <br />
            <p>
              THIS PURCHASE ORDER: <b>{repData.ExtendedAmount}</b>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
});
