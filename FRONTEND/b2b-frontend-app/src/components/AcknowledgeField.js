import "../stylesheets/AcknowledgeField.css";

function AcknowledgeField({ tittle, value, Acknowledge }) {
  var CSSClass = "Acknowledge-field " + Acknowledge + "-fld";
  return (
    <div className={CSSClass}>
      <p>{tittle}</p>
      <span>{value}</span>
    </div>
  );
}
export default AcknowledgeField;
