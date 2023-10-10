import { useState, useEffect } from "react";
import OpenPOsList from "./OpenPOsList";
import endpoints from "../lib/endpoints";

function POsContainer({ SessionInfo }) {
  const url = endpoints.target + endpoints.endpoint.GetOpenPOs;
  const [OpenPOs, setOpenPOs] = useState([]);
  var _session = {
    userID: SessionInfo.userID,
    isLogged: SessionInfo.isLogged,
    skey: SessionInfo.skey,
  };

  useEffect(() => {
    const getData = async () => {
      const resp = await fetch(url, {
        method: "POST",
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
        body: JSON.stringify(_session),
      });
      const json = await resp.json();
      //console.log("POsContainer json", json.result.result);
      setOpenPOs(json.result.result);
    };
    getData();
  }, []);

  return (
    <>
      <OpenPOsList
        OpenPOsArray={OpenPOs}
        SessionInfo={SessionInfo}
      ></OpenPOsList>
    </>
  );
}

export default POsContainer;
