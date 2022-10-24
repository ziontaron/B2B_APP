import React from "react";
import Logo from "./Logo";
import User from "./User";

const styles = {
  navbar: {
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    position: "relative",
    padding: "0 50px",
    boxShadow: "0 2px 3px rgb(0,0,0,0.1)",
    backgroundColor: "#e90000",
    backgroundImage: "linear-gradient(145deg, #e90000 30%, #050000 100%)",

    height: "100px",
  },
};
function Navbar({ setSession, userName }) {
  return (
    <nav style={styles.navbar}>
      <Logo />
      <User closeSession={setSession} userName={userName}></User>
    </nav>
  );
}

export default Navbar;
