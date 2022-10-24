import React from "react";
import "../stylesheets/ActiveFunction.css";

// const styles = {
//   activeFunction: {
//     width: "99vw",

//     display: "flex",
//     padding: "50px 0 50px 0",
//     flexDirection: "column",
//     justifyContent: "center",
//     alignItems: "center",
//   },
// };

function ActiveFunction(props) {
  return <div className='active-function'>{props.children}</div>;
}

export default ActiveFunction;
