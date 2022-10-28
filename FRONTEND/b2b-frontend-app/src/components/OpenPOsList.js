import OpenPOs from "../components/OpenPOs";
import AknowledgeModal from "./AknowledgeModal";
import ReportModal from "../reports/ReportModal";

import "../stylesheets/OpenPOsList.css";
import { useState, useEffect } from "react";

function OpenPOsList({ OpenPOsArray, SessionInfo }) {
  //console.log("OpenPOsArray", OpenPOsArray);
  const _sessionInfo = SessionInfo;
  const [repData, setRepData] = useState({
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
  });
  const [poRep, setPORep] = useState("");
  const [PORelease, setPORelease] = useState({
    acknowledge: null,
    balance: 0,
    orderedQuantity: 0,
    poLineKey: 0,
    poLineType: "",
    promisedDate: "",
    receiptQuantity: 0,
  });
  const _loadRepData = (PO) => {
    //console.log("PO: " + PO);
    setPORep(PO);
  };

  useEffect(() => {
    if (poRep) {
      //console.log("from UseEffect PO: " + poRep);

      const url =
        "https://localhost:44309/api/B2BOpen_POs/GetPOsRep?PO=" + poRep;
      const getReport = async () => {
        const resp = await fetch(url, {
          method: "POST",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
          },
          body: JSON.stringify(_sessionInfo),
        });
        const json = await resp.json();
        // console.log("Fetching PO: ");
        // console.log(JSON.stringify(json.result));
        setRepData(json.result);
      };
      getReport()
        // make sure to catch any error
        .catch(console.error);

      // console.log("fetch response:");
      // console.log(repData);
    }
  }, [poRep]);

  const Release2Acknoledge = (rel) => {
    setPORelease({
      acknowledge: rel.acknowledge,
      balance: rel.balance,
      orderedQuantity: rel.orderedQuantity,
      poLineKey: rel.poLineKey,
      poLineType: rel.poLineType,
      promisedDate: rel.promisedDate,
      receiptQuantity: rel.receiptQuantity,
    });
    //console.log("Hook Release2Acknoledge", rel);

    var modal = document.getElementById("RelModal");
    modal.style.display = "block";

    var chkbox = document.getElementById("acknowledgeCheck");
    chkbox.checked = true;

    var textarea = document.getElementById("AcknowNotes");
    textarea.value = "";

    //AcknowNotes
    //chkbox.value = true;
  };
  return (
    <div className='open-pos-page'>
      <div className='open-pos-page-header'>
        <h1>Open PO's</h1>
      </div>
      {OpenPOsArray.map((PO) => (
        <OpenPOs
          key={PO.poLineKey}
          OpenPO={PO}
          ReleaseInfo={Release2Acknoledge}
          SessionInfo={_sessionInfo}
          LoadRepData={_loadRepData}
        />
      ))}
      <dialog id='reportModal'>
        {/* {poRep ? console.log("Modal " + repData) : null} */}
        {poRep ? <ReportModal repData={repData}></ReportModal> : null}
      </dialog>
      <AknowledgeModal ReleaseInfo={PORelease} SessionInfo={_sessionInfo} />
    </div>
  );
}

export default OpenPOsList;
