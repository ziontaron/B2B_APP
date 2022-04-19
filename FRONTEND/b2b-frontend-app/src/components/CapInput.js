import React from "react";
import "../stylesheets/CapInput.css";

function CapInput() {
  return (
    <div class="form-group">
      <span>https://</span>
      <input class="form-field" type="text" placeholder="domain.tld"></input>
    </div>
  );
}

export default CapInput;
