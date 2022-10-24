import "../stylesheets/BubbleAlert.css";
const styles = {
  bubbleAlert: {
    backgroundColor: "#E9725A",
    borderRadius: "15px",
    color: "#fff",
    padding: "2px 10px",
    fontSize: "0.9rem",
    width: "20px",
  },
};
function BubbleAlert({ value, clickbubble }) {
  function getNumber(value) {
    if (!value) {
      return " ";
    }
    return value > 9 ? "9+" : value;
  }

  return (
    <span
      className='bubbleAlert'
      onClick={clickbubble}
      // style={styles.bubbleAlert}
    >
      {getNumber(value)}
    </span>
  );
}

export default BubbleAlert;
