import "../stylesheets/AknowledgeButton.css";
import { AiFillFileText } from "react-icons/ai";

function AknowledgeButton({ SessionInfo, PORelease, ReleaseInfo }) {
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
