import "../stylesheets/OpenPOs.css";
import { useState } from "react";
import BubbleAlert from "./BubbleAlert";
import POField from "./POField";
import BlanketRelease from "./BlanketRelease";
import ReportBubble from "./ReportBubble";
//import AcknowledgeField from "./AcknowledgeField";

function OpenPOs({ OpenPO, SessionInfo, ReleaseInfo, LoadRepData }) {
  const [openrel, setOpenrel] = useState(false);
  let RelArray = [];
  //var Acknowledge = OpenPO.acknowledge;
  //console.log("OpenPO", OpenPO);
  //console.log("OpenPO.Acknowledge", OpenPO.acknowledge);
  let relQty = OpenPO.releases.length;

  //_sessionObj = await response.json();

  RelArray = [...OpenPO.releases];
  function getUSDate(date2format) {
    var _date = "";
    let sDate = date2format.substring(0, 10);
    let year = sDate.substring(0, 4);
    let month = sDate.substring(5, 7);
    let day = sDate.substring(8, 10);
    return _date.concat(month, "/", day, "/", year);
  }

  const toggleRelease = () => {
    setOpenrel(!openrel);
  };

  return (
    <div className='open-po-container-notification'>
      <div className='open-pos-container'>
        <div className='pos-fields-container'>
          <POField tittle={"Item Number:"} value={OpenPO.itemNumber} />
          <POField tittle={"Item Description:"} value={OpenPO.itemNumberDesc} />
          <POField tittle={"Item UM:"} value={OpenPO.itemUM} />
          <POField tittle={"Item Rev:"} value={OpenPO.itemRevision} />
          <POField tittle={"PO Number:"} value={OpenPO.poNumber} />
          <POField tittle={"PO Line SubType:"} value={OpenPO.poLineType} />
          <POField tittle={"Ordered Qty:"} value={OpenPO.orderedQuantity} />
          <POField tittle={"Receipt Qty:"} value={OpenPO.receiptQuantity} />
          <POField tittle={"Balance:"} value={OpenPO.balance} />
          <POField
            tittle={"Promised Date:"}
            value={getUSDate(OpenPO.promisedDate)}
          />
          {/* {Acknowledge != null ? (
            <AcknowledgeField
              tittle={"Acknowledge:"}
              value={Acknowledge.acknowledge}
            />
          ) : null} */}
        </div>
        <div className='blanket-releases'>
          {relQty > 0
            ? RelArray.map((Rel) => (
                <BlanketRelease
                  key={Rel.poLineKey}
                  PORelease={Rel}
                  isVisible={openrel}
                  SessionInfo={SessionInfo}
                  ReleaseInfo={ReleaseInfo}
                />
              ))
            : null}
        </div>
      </div>
      <span className='bubble-rep-button'>
        <ReportBubble
          clickbubble={() => {
            console.log("ReportBubble for: " + OpenPO.poNumber);
            LoadRepData(OpenPO.poNumber);
            //const lsv = JSON.parse(localStorage.getItem("sData"));
            // var modal = document.getElementById("report-modal");
            // modal.style.display = "visible";
            document.getElementById("reportModal").show();
          }}
        ></ReportBubble>
      </span>
      <span className='bubble-notification'>
        {relQty !== 0 ? (
          <BubbleAlert value={relQty} clickbubble={toggleRelease}></BubbleAlert>
        ) : null}
      </span>
    </div>
  );
}

export default OpenPOs;
