import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

// Import Leaflet's CSS file
import 'leaflet/dist/leaflet.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);