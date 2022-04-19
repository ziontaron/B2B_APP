import React from "react";
import "../stylesheets/login.css";

function LoginForm() {
  return (
    <div className="login-form-box">
      <form className="login-form">
        <div className="login-form-content">
          <div className="login-form-header">
            <h1 className="login-form-tittle">Capsonic B2B APP</h1>
          </div>
          <div className="login-form-body">
            <div className="login-input user-name-input">
              <span>User Name:</span>
              <input className="input-text" type="text" placeholder="User Name" name="text" />
            </div>
            <div className="login-input password-input">
              <span>User Password: </span>
              <input className="input-text" type="password" placeholder="Password" name="text" />
            </div>
          </div>
          <div className="login-form-footer">Login</div>
        </div>
      </form>
    </div>
  );
}

export default LoginForm;
