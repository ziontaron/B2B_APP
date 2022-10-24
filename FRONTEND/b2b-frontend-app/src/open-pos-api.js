const url = "https://localhost:44309/api/B2BOpen_POs/GetOpenPOs";

function apiGetOpenPOs(SessionInfo) {
  var _OpenPos = [];
  var _session = {
    userID: SessionInfo.userID,
    isLogged: SessionInfo.isLogged,
    skey: SessionInfo.skey,
  };

  fetch(url, {
    method: "POST",
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
    body: JSON.stringify(_session),
  })
    .then((res) => {
      return res.json();
    })
    .then((res) => {
      // console.log("Api Sobj", _session);
      _OpenPos = [...res.result.result];
      // _OpenPos = res.result.result;
      //console.log("OpenPos api lib", _OpenPos);
      return _OpenPos;
    })
    .catch(() => {
      _OpenPos = [];
    });

  return _OpenPos;
}
export default apiGetOpenPOs;
