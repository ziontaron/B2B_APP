import React from "react";

const styles = {
	footer: {
		display: "flex",
		flexDirection: "row",
		alignItems: "center",
		justifyContent: "space-between",
		position: "relative",
		padding: "0 50px",
		boxShadow: "0 2px 3px rgb(0,0,0,0.1)",
		backgroundColor: "#e90000",
		backgroundImage: "linear-gradient(145deg, #e90000 30%, #050000 100%)",

		height: "80px",
	},
};

function Footer() {
	return (
		<div style={styles.footer}>
			<h1>Capsonic Automotive and Aerospace</h1>
		</div>
	);
}

export default Footer;
