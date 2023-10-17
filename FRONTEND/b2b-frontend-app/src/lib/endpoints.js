const API_endpoint = {
	options: {
		dev: "https://localhost:44309",
		prod: "https://192.168.0.6/b2b_backend",
		host: "https://192.168.0.100:5001",
		host2: "https://ferlap-01:5001",
	},

	target: "https://apps.capsonic.com/B2B_API",
	endpoint: {
		GetOpenPOs: "/api/B2BOpen_POs/GetOpenPOs", //get vendor PO List
		GetPOsRep: "/api/B2BOpen_POs/GetPOsRep?PO=", //printable report
		Acknowledge: "/api/B2BRelAcknowledge/Acknowledge", //Acknowledge PO Release
		Login: "/api/B2BUser/Login", //User Session Login
		Register: "​/api​/B2BUser​/Register", //User Registration
	},
};

export default API_endpoint;
