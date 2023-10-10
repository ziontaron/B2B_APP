import "../stylesheets/AknowledgeModal.css";
import API_endpoint from "../lib/endpoints";

function AknowledgeModal({ ReleaseInfo, SessionInfo }) {
  const closeButton = (e) => {
    var modal = document.getElementById("RelModal");
    modal.style.display = "none";
  };
  var AckCheked = "Accepted";
  var AckApiModel = {
    fspoLineKey: ReleaseInfo.poLineKey,
    userID: SessionInfo.userID,
    skey: SessionInfo.skey,
    acknowledge: "ok",
    notes: "",
  };
  let AknowledgeRes = {};
  function getUSDate(date2format) {
    var _date = "";
    let sDate = date2format.substring(0, 10);
    let year = sDate.substring(0, 4);
    let month = sDate.substring(5, 7);
    let day = sDate.substring(8, 10);

    return _date.concat(month, "/", day, "/", year);
  }
  //console.log(ReleaseInfo);
  const AknowledgeClick = (e) => {
    var chkbox = document.getElementById("acknowledgeCheck");
    if (chkbox.checked === true) {
      AckCheked = "Accepted";
    } else {
      AckCheked = "Rejected";
    }
    //console.log("Click", AckCheked);
  };

  const setAknowledge = async (e) => {
    e.preventDefault();

    const data = Array.from(new FormData(e.target));
    const formObj = Object.fromEntries(data);

    AckApiModel = {
      fspoLineKey: ReleaseInfo.poLineKey,
      userID: SessionInfo.userID,
      skey: SessionInfo.skey,
      acknowledge: AckCheked,
      notes: formObj.notes,
    };

    //console.log("submit", formObj);
    //console.log("submit to api", AckApiModel);

    const url = API_endpoint.target + API_endpoint.endpoint.Acknowledge;
    //"https://localhost:44309/api/B2BRelAcknowledge/Acknowledge";

    const response = await fetch(url, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json; charset=UTF-8",
      },
      body: JSON.stringify(AckApiModel),
    });

    AknowledgeRes = await response.json();

    console.log("AknowledgeRes: ", AknowledgeRes);
    closeButton();
  };

  return (
    <div id='RelModal' className='modal'>
      <div className='modal-content'>
        <div className='modal-header'>
          <h2>Release Acknowledgement</h2>
          <span className='close' onClick={closeButton}>
            &times;
          </span>
        </div>
        <div className='modal-body'>
          <form className='Acknowledge-form' onSubmit={setAknowledge}>
            <div className='Aknowledge-slider' onClick={AknowledgeClick}>
              <p>
                <strong>Accept or Reject: &nbsp;</strong>
              </p>
              <label className='switch'>
                <input
                  id='acknowledgeCheck'
                  type='checkbox'
                  name='acceptReject'
                />
                <span className='slider'></span>
              </label>
            </div>
            <div className='Aknowledge-field-group'>
              <div className='Aknowledge-field'>
                <p>
                  <strong>Release Qty: &nbsp;</strong>
                </p>
                {ReleaseInfo.orderedQuantity}
              </div>
              <div className='Aknowledge-field'>
                <p>
                  <strong>Received Qty: &nbsp;</strong>
                </p>
                {ReleaseInfo.receiptQuantity}
              </div>
              <div className='Aknowledge-field'>
                <p>
                  <strong>Balance Qty: &nbsp;</strong>
                </p>
                {ReleaseInfo.balance}
              </div>
              <div className='Aknowledge-field'>
                <p>
                  <strong>Promised Date: &nbsp;</strong>
                </p>
                {getUSDate(ReleaseInfo.promisedDate)}
              </div>
            </div>
            <div className='text-area'>
              <p>
                <strong>Notes:</strong>
              </p>
              <textarea id='AcknowNotes' name='notes'></textarea>
            </div>
            <div className='submit-field'>
              <div className='submit-button'>
                <button type='submit' onSubmit={() => {}}>
                  <strong>Send Aknowledge</strong>
                </button>
              </div>
            </div>
          </form>
        </div>
        <div className='modal-footer'>{/* <h3>Modal Footer</h3> */}</div>
      </div>
    </div>
  );
}
export default AknowledgeModal;
