//import logo from "./logo.svg";
import "./App.css";
import LoginForm from "./components/login";
import ListaDeTareas from "./components/ListaDeTareas";
import CapInput from "./components/CapInput";

function App() {
  return (
    <div className="App">
      <div className="app-header">
        <h1>CAPSONIC B2B APP HEADER</h1>
      </div>
      <div className="app-body">
        <LoginForm />
      </div>
      <div className="app-footer">
        <h1>CAPSONIC B2B APP FOOTER</h1>
      </div>
    </div>
  );
}

export default App;
