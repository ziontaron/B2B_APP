import "../stylesheets/AknowledgeBubble.css";
import { FcCheckmark, FcCancel } from "react-icons/fc";

function AknowledgeBubble({ Acknowledge }) {
  var AkcObj = Acknowledge;
  var CSSClass = "AknowledgeBubble " + AkcObj.acknowledge + "-bub";
  //console.log(CSSClass);
  return (
    <div className='tooltip'>
      <span className={CSSClass}>
        {AkcObj.acknowledge === "Accepted" ? <FcCheckmark /> : <FcCancel />}
      </span>
      <span className='tooltiptext'>{AkcObj.notes}</span>
    </div>
  );
}

export default AknowledgeBubble;
