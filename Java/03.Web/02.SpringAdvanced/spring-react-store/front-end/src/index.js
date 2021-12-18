import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import StoreNavigation from "./store-navigation";
import ErrorBoundary from "./ErrorBoundary";

ReactDOM.render(
  <React.StrictMode>
    <ErrorBoundary>
      <App {...window.__STATE__}>
        <StoreNavigation />
      </App>
    </ErrorBoundary>
  </React.StrictMode>,
  document.getElementById("root")
);
