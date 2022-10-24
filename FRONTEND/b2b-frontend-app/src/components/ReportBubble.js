import "../stylesheets/ReportBubble.css";

function ReportBubble({ clickbubble }) {
  return (
    <span className='ReportBubble' onClick={clickbubble}>
      Print
    </span>
  );
}

export default ReportBubble;
