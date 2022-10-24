import "../stylesheets/BlanketRelease.css";
import POField from "./POField";
import AcknowledgeField from "./AcknowledgeField";
import AknowledgeBubble from "./AknowledgeBubble";
import AknowledgeButton from "./AknowledgeButton";

// poLineKey: 349741698,
// poLineType: "S",
// orderedQuantity: 18000,
// receiptQuantity: 4000,
// balance: 14000,
// promisedDate: "2022-03-21T00:00:00",
// acknowledge: null,

function getUSDate(date2format) {
  var _date = "";
  let sDate = date2format.substring(0, 10);
  let year = sDate.substring(0, 4);
  let month = sDate.substring(5, 7);
  let day = sDate.substring(8, 10);

  return _date.concat(month, "/", day, "/", year);
}

function BlanketRelease({ PORelease, isVisible, SessionInfo, ReleaseInfo }) {
  var Acknowledge = PORelease.acknowledge;
  //console.log(Acknowledge);
  return isVisible ? (
    <>
      {Acknowledge != null ? (
        <span className='Aknowledge-Bubble'>
          <AknowledgeBubble Acknowledge={Acknowledge} />
        </span>
      ) : (
        <span className='Aknowledge-Bubble'>
          <AknowledgeButton
            SessionInfo={SessionInfo}
            PORelease={PORelease}
            ReleaseInfo={ReleaseInfo}
          />
        </span>
      )}
      <div className='release-container'>
        <div className='release-field'>
          <POField tittle={"Release Qty"} value={PORelease.orderedQuantity} />
          <POField tittle={"Receipt Qty"} value={PORelease.receiptQuantity} />
          <POField tittle={"Balance"} value={PORelease.balance} />
          <POField
            tittle={"Promised Date"}
            value={getUSDate(PORelease.promisedDate)}
          />
          {Acknowledge != null ? (
            <AcknowledgeField
              Acknowledge={Acknowledge.acknowledge}
              tittle={"Acknowledge:"}
              value={getUSDate(Acknowledge.acknowledgeDate)}
            />
          ) : null}
        </div>
      </div>
    </>
  ) : null;
}

export default BlanketRelease;
