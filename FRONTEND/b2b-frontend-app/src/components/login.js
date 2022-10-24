import React from "react";
import "../stylesheets/Login.css";

function LoginForm({ setLogin }) {
  const url = "https://localhost:44309/api/B2BUser/Login";
  let _user = "";
  let _pass = "";
  let _sessionObj = {};
  const _login = async (e) => {
    e.preventDefault();
    const data = Array.from(new FormData(e.target));
    const formObj = Object.fromEntries(data);

    _user = formObj.username;
    _pass = formObj.password;

    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
      body: JSON.stringify({
        userName: _user,
        userPass: _pass,
      }),
    });
    _sessionObj = await response.json();
    if (!_sessionObj.errorThrown) {
      if (_sessionObj.result.isLogged) {
        setLogin(_sessionObj.result.userID, _user, _sessionObj.result.skey);
      } else {
        setLogin(0, "", "");
      }
    } else {
      setLogin(0, "", "");
    }
  };

  return (
    <div className='login-form-box'>
      <form className='login-form' onSubmit={_login}>
        <div className='login-form-content'>
          <div className='login-form-header'>
            <h1 className='login-form-tittle'>Capsonic B2B APP</h1>
          </div>
          <div className='login-form-body'>
            <div className='login-input user-name-input'>
              <span>User Name:</span>
              <input
                className='input-text user-input'
                type='text'
                placeholder='User Name'
                name='username'
              />
            </div>
            <div className='login-input password-input'>
              <span>User Password: </span>
              <input
                className='input-text'
                type='password'
                placeholder='Password'
                name='password'
              />
            </div>
          </div>
          <div className='login-form-footer'>
            <button className='login-button' type='submit' onSubmit={_login}>
              Login
            </button>
          </div>
        </div>
      </form>
    </div>
  );
}

export default LoginForm;
