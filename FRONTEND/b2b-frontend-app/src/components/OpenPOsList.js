import OpenPOs from "../components/OpenPOs";
import AknowledgeModal from "./AknowledgeModal";
import ReportModal from "../reports/ReportModal";

import "../stylesheets/OpenPOsList.css";
import { useState, useEffect } from "react";

function OpenPOsList({ OpenPOsArray, SessionInfo }) {
  //console.log("OpenPOsArray", OpenPOsArray);
  const _sessionInfo = SessionInfo;
  const [PORelease, setPORelease] = useState({
    acknowledge: null,
    balance: 0,
    orderedQuantity: 0,
    poLineKey: 0,
    poLineType: "",
    promisedDate: "",
    receiptQuantity: 0,
  });
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
        />
      ))}
      <dialog open>
        <ReportModal repData={{}}></ReportModal>
      </dialog>
      <AknowledgeModal ReleaseInfo={PORelease} SessionInfo={_sessionInfo} />
    </div>
  );
}

export default OpenPOsList;
