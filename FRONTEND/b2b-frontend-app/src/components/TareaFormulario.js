import React, { useState } from "react";
import { v4 as uuidv4 } from "uuid";
import "../stylesheets/TareaFormulario.css";

function TareaFormulario(props) {
  const [input, setInput] = useState("");

  const manejarCambio = (e) => {
    setInput(e.target.value);
  };

  const manejarEnvio = (e) => {
    e.preventDefault();
    const tareaNueva = {
      id: uuidv4(),
      texto: input,
      completada: false,
    };
    props.onSubmit(tareaNueva);
  };

  return (
    <div>
      <h1 className="tarea-formulario-titulo">Mis Tareas</h1>
      <form className="tarea-formulario" onSubmit={manejarEnvio}>
        <input className="tarea-input" type="text" placeholder="Escribe una Tarea" name="text" onChange={manejarCambio} />
        <button className="tarea-button">Agregar Tarea</button>
      </form>
    </div>
  );
}

export default TareaFormulario;
