import React from "react";
import "../stylesheets/InputTest.css";

function InputTest() {
  return (
    <>
      <h1>Nice input box</h1>
      <form>
        <input type="text" name="name" class="question" id="nme" required autocomplete="off" />
        <label for="nme">
          <span>What's your name?</span>
        </label>
        <textarea name="message" rows="2" class="question" id="msg" required autocomplete="off"></textarea>
        <label for="msg">
          <span>What's your message?</span>
        </label>
        <input type="submit" value="Submit!" />
      </form>
    </>
  );
}

export default InputTest;
