import React from "react";

const styles = {
	layout: {
		backgroundColor: "#eceff1",
		color: "#0A283E",
		alignItems: "center",
		display: "flex",
		// flexDirection: "column",
		flexDirection: "row",
	},
	container: {
		width: "100vw",
	},
};
function Layout(props) {
	return (
		<div style={styles.layout}>
			<div style={styles.container}>{props.children}</div>
		</div>
	);
}

export default Layout;
