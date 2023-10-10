import OpenPOs from "../components/OpenPOs";
import AknowledgeModal from "./AknowledgeModal";
import ReportModal from "../reports/ReportModal";
import API_endpoint from "../lib/endpoints";

import "../stylesheets/OpenPOsList.css";
import { useState, useEffect } from "react";

function OpenPOsList({ OpenPOsArray, SessionInfo }) {
  //console.log("OpenPOsArray", OpenPOsArray);
  const _sessionInfo = SessionInfo;
  const [repData, setRepData] = useState({
    poRevDate: "",
    po: "",
    poOriginalDate: "",
    contractNo: "",
    contact: "",
    vendorInfo: {
      id: "",
      contact: "",
      contactPhone: "",
      vendorName: "",
      address1: "",
      address2: "",
      city: "",
      state: "",
      zipcode: "",
      country: "",
    },
    shipToAddress: {
      name: "",
      address1: "",
      address2: "",
      city: "",
      state: "",
      zipcode: "",
      country: "",
    },
    transportVia: "",
    fobPoint: "",
    paymentTerm: "",
    taxExemptNum: "",
    buyerInitials: "",
    buyerName: "",
    ExtendedAmount: 0.0,
    polines: [
      {
        poLnKey: 1,
        POLn: "",
        PN: "",
        poLineSubType: "",
        um: "",
        rev: "",
        POLineSubType: "",
        orderedQty: 0,
        receiptQty: 0,
        PromiDock: "",
        UnitPrice: 0.0,
        ExtendedPrice: 0.0,
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
  const _loadRepPO = (PO) => {
    //console.log({ PO });
    setPORep(PO);
    //console.log({ poRep });
  };
  const _loadReportsData = (Data) => {
    console.log({ Data });

    setRepData(Data);
  };
  useEffect(() => {
    if (poRep) {
      //console.log("from UseEffect PO: " + poRep);

      const url = API_endpoint.target + API_endpoint.endpoint.GetPOsRep + poRep;
      const getReport = async () => {
        const resp = await fetch(url, {
          method: "POST",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
          },
          body: JSON.stringify(_sessionInfo),
        });
        const json = await resp.json();
        //console.log(JSON.stringify(json.result));
        _loadReportsData(json.result);
        //console.log("Fetching PO Successfully");
      };
      getReport()
        // make sure to catch any error
        .catch(console.error);

      // console.log("fetch response:");
      // console.log(repData);
    } else {
      console.error("Error fetching PO");
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
          LoadRepPO={_loadRepPO}
        />
      ))}
      <dialog id='reportModal'>
        {/* {poRep ? console.log("Modal " + repData) : null} */}
        {repData ? <ReportModal repData={repData}></ReportModal> : null}
      </dialog>
      <AknowledgeModal ReleaseInfo={PORelease} SessionInfo={_sessionInfo} />
    </div>
  );
}

export default OpenPOsList;
