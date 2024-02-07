//import logo from "./logo.svg";
import "./App.css";
import React, { useState, useEffect } from "react";
import LoginForm from "./components/Login";
import Layout from "./components/Layout";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import ActiveFunction from "./components/ActiveFunction";
import POsContainer from "./components/POsContainer";
import DashBoardContainer from "./components/DashBoardContainer";
//import Example from "./reports/TestRep";
function App() {
	// var _openPOs = [];
	// _openPOs = [...apiResponse()];
	const [session, setSession] = useState({
		isLogged: false,
		skey: "",
		userID: 0,
		userName: "",
	});

	//console.log("Loguin page LS: ", localStorage.getItem("sData"));

	useEffect(() => {
		const lsv = JSON.parse(localStorage.getItem("sData"));
		//console.log(lsv);
		if (lsv)
			if (lsv.isLogged) {
				setSession(lsv);
			}
	}, []);
	const SessionMgr = (userId, userName, sessionKey) => {
		if (sessionKey !== "") {
			setSession({
				isLogged: true,
				userID: userId,
				skey: sessionKey,
				userName: userName,
			});
		} else {
			setSession({
				isLogged: false,
				userId: "",
				sessionKey: "",
				userName: "",
			});
		}
		localStorage.setItem(
			"sData",
			JSON.stringify({
				isLogged: userId === "" ? false : true,
				userID: userId,
				skey: sessionKey,
				userName: userName,
			}),
		);
	};

	return (
		<div className="App">
			<Navbar
				setSession={SessionMgr}
				userName={session.userName}
			></Navbar>
			<Layout>
				<ActiveFunction>
					{session.isLogged ? (
						session.userName.toLowerCase() === "capadmin" ? (
							<DashBoardContainer></DashBoardContainer>
						) : (
							<POsContainer SessionInfo={session}></POsContainer>
						)
					) : (
						<LoginForm setLogin={SessionMgr}></LoginForm>
					)}
					{/* <Example /> */}
				</ActiveFunction>
			</Layout>
			<Footer></Footer>
		</div>
	);
}

export default App;
