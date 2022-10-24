import "../stylesheets/POField.css";
function POField({ tittle, value }) {
  return (
    <div className='po-field'>
      <p>{tittle}</p>
      <span>{value}</span>
    </div>
  );
}
export default POField;
