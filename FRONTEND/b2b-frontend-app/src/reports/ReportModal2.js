import React, { useRef } from "react";
import ReactToPrint from "react-to-print";
import ReactModal from "react-modal";

import "./ReportModal.css";
import { ComponentToPrint } from "./ComponentToPrint";

const ReportModalv2 = (repData) => {
  const handleOpenModal = () => {
    this.setState({ showModal: true });
  };

  const handleCloseModal = () => {
    this.setState({ showModal: false });
  };
  return (
    <div>
      <button onClick={handleOpenModal}>Trigger Modal</button>
      <ReactModal
        isOpen={this.state.showModal}
        contentLabel='Minimal Modal Example'
      >
        <button onClick={handleCloseModal}>Close Modal</button>
      </ReactModal>
    </div>
  );
};

export default ReportModalv2;
