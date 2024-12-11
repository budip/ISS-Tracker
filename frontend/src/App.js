import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import L from 'leaflet';

// Custom marker icon for the ISS
const issIcon = new L.Icon({
  iconUrl: '/iss-icon.svg',
  iconSize: [30, 30],
  iconAnchor: [25, 25],
  popupAnchor: [0, -20]
});

// Custom marker icon for Seattle (same as default Leaflet icon)
const defaultIcon = new L.Icon({
  iconUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon.png',
  iconSize: [25, 41],
  iconAnchor: [12, 41]
});

function App() {
  const [issLocation, setIssLocation] = useState(null);
  const [loading, setLoading] = useState(false);

  // Function to fetch ISS location from the backend
  const fetchISSLocation = async () => {
    setLoading(true);
    try {
      // ✅ Updated the API URL to point to localhost:5000
      const response = await fetch('http://localhost:5000/api/iss/iss-location');
      const data = await response.json();
      setIssLocation(data);
    } catch (error) {
      console.error('Error fetching ISS location:', error);
    } finally {
      setLoading(false);
    }
  };

  // Auto-refresh ISS location every 10 seconds
  useEffect(() => {
    fetchISSLocation();
    const intervalId = setInterval(() => {
      fetchISSLocation();
    }, 20000); // Update every 10 seconds

    return () => clearInterval(intervalId); // Cleanup on unmount
  }, []);

  return (
    <div className="App">
      <h1>Track the ISS Relative to Seattle</h1>

      <button onClick={fetchISSLocation} disabled={loading}>
        {loading ? 'Loading...' : 'Get ISS Location'}
      </button>

      {/* Leaflet Map */}
      <MapContainer 
        center={[47.6062, -122.3321]} 
        zoom={3} 
        style={{ height: '500px', width: '100%' }}
      >
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        />

        {/* Seattle Marker */}
        <Marker position={[47.6062, -122.3321]} icon={defaultIcon}>
          <Popup>Seattle, WA</Popup>
        </Marker>

        {/* ISS Location Marker */}
        {issLocation && (
          <Marker position={[issLocation.issLocation.latitude, issLocation.issLocation.longitude]} icon={issIcon}>
            <Popup>
              <strong>ISS Location</strong><br />
              Latitude: {issLocation.issLocation.latitude}<br />
              Longitude: {issLocation.issLocation.longitude}
            </Popup>
          </Marker>
        )}
      </MapContainer>

      {issLocation && (
        <div className="results">
          <h2>ISS Location</h2>
          <p>Latitude: {issLocation.issLocation.latitude}</p>
          <p>Longitude: {issLocation.issLocation.longitude}</p>

          <h2>Seattle Location</h2>
          <p>Latitude: {issLocation.seattleLocation.lat}</p>
          <p>Longitude: {issLocation.seattleLocation.lon}</p>

          <h2>Distance from Seattle</h2>
          <p>{issLocation.distanceToSeattle.toFixed(2)} km</p>
        </div>
      )}
    </div>
  );
}

export default App;