import "../stylesheets/AknowledgeButton.css";
import { AiFillFileText } from "react-icons/ai";

function AknowledgeButton({ SessionInfo, PORelease, ReleaseInfo }) {
  const url = "https://localhost:44309/api/B2BRelAcknowledge/Acknowledge";

  let _ResObj = {};
  var AckApiModel = {
    fspoLineKey: PORelease.poLineKey,
    userID: SessionInfo.userID,
    skey: SessionInfo.skey,
    acknowledge: "ok",
    notes: "Bootstrap only supports one modal window at a time",
  };

  const setAknowledge = async (e) => {
    e.preventDefault();
    //console.log("sent to api", AckApiModel);
    //console.log("ReleaseInfo", ReleaseInfo);

    const response = await fetch(url, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json; charset=UTF-8",
      },
      body: JSON.stringify(AckApiModel),
    });
    //_ResObj = await response.json();

    //console.log("received from api", response);
    //console.log("received from api", _ResObj);

    //.log(response);
  };

  const AcknowledgeClick = () => {
    //console.log("AcknowledgeClick PORelease", PORelease);
    ReleaseInfo({
      acknowledge: PORelease.acknowledge,
      balance: PORelease.balance,
      orderedQuantity: PORelease.orderedQuantity,
      poLineKey: PORelease.poLineKey,
      poLineType: PORelease.poLineType,
      promisedDate: PORelease.promisedDate,
      receiptQuantity: PORelease.receiptQuantity,
    });
    // var modal = document.getElementById("RelModal");
    // modal.style.display = "block";
  };

  return (
    <div className='tooltip' onClick={AcknowledgeClick}>
      <span className='AknowledgeButton'>
        <AiFillFileText />
      </span>
      <span className='tooltiptext'>Aknowledge Release?</span>
    </div>
  );
}

export default AknowledgeButton;
