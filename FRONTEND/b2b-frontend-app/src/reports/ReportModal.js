import React, { useRef } from "react";
import ReactToPrint from "react-to-print";
import "./ReportModal.css";

import { ComponentToPrint } from "./ComponentToPrint";

const ReportModal = (repData) => {
  console.log("repData from prop: ");
  console.log(repData);
  const componentRef = useRef();
  const repDataTest = {
    poRevDate: "07/22/2022",
    po: "PO-072022-02",
    poOriginalDate: "07/20/2022",
    contractNo: "123456789",
    contact: "contact",
    vendorInfo: {
      id: "890020",
      contact: "SUPPLIER INFORMATION",
      contactPhone: "310-784-3100",
      vendorName: "MAGNETIC COMPONENT ENGINEERING, INC.",
      address1: "2830 LOMITA BLVD",
      address2: "",
      city: "TORRANCE",
      state: "CA",
      zipcode: "90505",
      country: "USA",
    },
    shipToAddress: {
      name: "CAPSONIC AUTOMOTIVE, INC.",
      address1: "7B ZANE GREY STREET",
      address2: "",
      city: "EL PASO",
      state: "TX",
      zipcode: "79906",
      country: "USA",
    },
    transportVia: "",
    fobPoint: "",
    paymentTerm: "NET 45 DAYS",
    taxExemptNum: "3-82567-5708-9",
    buyerInitials: "EC",
    buyerName: "Edna Camargo",
    ExtendedAmount: 1417.56,
    POLines: [
      {
        POLnKey: 123456,
        POLn: "001",
        PN: "67622467-1",
        PNDescription: "ROTOR ASSEMBLY",
        UM: "EA",
        Rev: "-",
        OrderedQty: 3,
        ReceiptQty: 0,
        PromiDock: "08/17/2022",
        UnitPrice: 472.52,
        ExtendedPrice: 1417.56,
      },
      {
        POLnKey: 12346,
        POLn: "002",
        PN: "67622467-1",
        PNDescription: "ROTOR ASSEMBLY",
        UM: "EA",
        Rev: "-",
        OrderedQty: 3,
        ReceiptQty: 0,
        PromiDock: "08/17/2022",
        UnitPrice: 472.52,
        ExtendedPrice: 1417.56,
      },
      {
        POLnKey: 1236,
        POLn: "002",
        PN: "67622467-1",
        PNDescription: "ROTOR ASSEMBLY",
        UM: "EA",
        Rev: "-",
        OrderedQty: 3,
        ReceiptQty: 0,
        PromiDock: "08/17/2022",
        UnitPrice: 472.52,
        ExtendedPrice: 1417.56,
      },
    ],
  };
  //repData = repDataTest;
  const closeButton = (e) => {
    document.getElementById("reportModal").close();
    //modal.style.display = "none";
  };
  return (
    <div id='report-modal' className='report-modal'>
      <div>
        <ReactToPrint
          trigger={() => <button>Print this out!</button>}
          content={() => componentRef.current}
        />
        <span className='report-modal-close' onClick={closeButton}>
          &times;
        </span>
      </div>
      <div className='report-modal-content'>
        <ComponentToPrint ReportData={repData} ref={componentRef} />
      </div>
    </div>
  );
};

export default ReportModal;
