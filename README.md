
# 🚀 ISS Tracker Application

This project allows users to track the **International Space Station (ISS)** relative to **Seattle, WA**. 
It consists of a **React (frontend)** and **.NET 9 (backend)** that work together to visualize the current location of the ISS on a map and calculate the distance from Seattle.

---

## 📁 **Project Structure**

```
/Projects/dotnet/
├── backend/       # .NET 9 backend (API server)
├── frontend/      # React 18 frontend (user interface)
└── README.md      # Project documentation
```

---

## 🎉 **Features**
- 🌍 **Live Tracking**: View the current position of the ISS on an interactive map.
- 📍 **Distance Calculation**: Calculates the distance between Seattle and the ISS.
- 📡 **Live Updates**: The position of the ISS updates every 10 seconds.
- 🔥 **Real-Time View**: Click the "Get ISS Location" button to manually update the position.

---

## 🚀 **Getting Started**

To run this project, you need **Node.js**, **.NET SDK 9.0**, and **npm** installed on your machine.

### **1️⃣ Clone the Repository**
```bash
git clone <repository-url>
cd /Projects/dotnet
```

---

## 🖥️ **Backend Setup (.NET 9)**
The **backend** is a **.NET 9 Web API** that exposes an endpoint to track the ISS and calculate its distance from Seattle.

### **1️⃣ Navigate to backend folder**
```bash
cd /Projects/dotnet/backend
```

### **2️⃣ Install dependencies**
```bash
dotnet restore
```

### **3️⃣ Run the server**
```bash
dotnet run
```

> **API will be available at:** http://localhost:5000

---

## 🌐 **API Endpoints**

| **Method** | **Endpoint**                  | **Description**              |
|------------|------------------------------|------------------------------|
| `GET`      | `/api/iss/iss-location`       | Get the ISS location relative to Seattle |

### 📡 **Sample Response**

```json
{
  "issLocation": {
    "latitude": "50.114962",
    "longitude": "-118.489242"
  },
  "seattleLocation": {
    "lat": 47.6062,
    "lon": -122.3321
  },
  "distanceToSeattle": 412.35
}
```

---

## 💻 **Frontend Setup (React 18)**
The **frontend** is a **React 18** application that visualizes the position of the ISS on a map. Version 19 is not recommended. Let me know if you have difficulties installing 18.

### **1️⃣ Navigate to frontend folder**
```bash
cd /Projects/dotnet/frontend
```

### **2️⃣ Install dependencies**
```bash
npm install
```

### **3️⃣ Start the React app**
```bash
npm start
```

> **Frontend will be available at:** http://localhost:3000

---

## 🚀 **How It Works**

1. The **frontend** sends a request to **http://localhost:5000/api/iss/iss-location**.  
2. The **backend** calls the ISS API (`http://api.open-notify.org/iss-now.json`), retrieves the ISS position, and calculates the distance from Seattle.  
3. The **response is sent back** to the React app, and the position is displayed on the map.

---

## ⚙️ **Configuration**

If you'd like to modify the backend URL, you can create a **.env** file in the frontend folder:

```
REACT_APP_BACKEND_URL=http://localhost:5000
```

This allows you to change the API URL for production or testing.

---

## 🛠️ **Project Commands**

| **Command**         | **Location**        | **Description**              |
|--------------------|-------------------|------------------------------|
| `dotnet run`        | `/backend`         | Start the backend server     |
| `dotnet clean`      | `/backend`         | Clean up old builds         |
| `dotnet build`      | `/backend`         | Build the .NET project       |
| `npm start`         | `/frontend`        | Start the React development server |
| `npm install`       | `/frontend`        | Install dependencies         |

---

## 🎉 **Technologies Used**

| **Technology**    | **Description**           |
|------------------|-------------------------|
| **React 18**      | Frontend user interface  |
| **.NET 9**        | Backend API             |
| **Leaflet.js**    | Interactive map         |
| **Open Notify**   | API to get the ISS position |

---

## 📦 **Folder Structure**

```
/Projects/dotnet/
├── backend/                     # .NET Web API
│   ├── Controllers/             # Contains the IssController
│   ├── Properties/              # Contains launchSettings.json
│   ├── appsettings.json         # Configuration file
│   ├── backend.csproj           # Project file
│   └── Program.cs               # Entry point for the API
│
├── frontend/                    # React 18 Frontend
│   ├── public/                  # Public files
│   ├── src/                     # Source files
│   │   ├── App.js               # Main React component
│   │   └── index.js             # Entry point for React app
│   └── package.json             # Project dependencies
│
└── README.md                    # Project documentation
```

---

## 🧪 **Testing**

1. **Test API**: Visit **http://localhost:5000/swagger** to see all API routes.  
2. **Test Frontend**: Visit **http://localhost:3000** to interact with the map and view live ISS tracking.

---

## 🐛 **Common Issues & Fixes**

| **Issue**                | **Cause**                 | **Solution** |
|------------------------|--------------------------|--------------|
| CORS Error (fetch failed) | Backend needs CORS enabled | Check backend **Program.cs** for `builder.Services.AddCors()` |
| React cannot connect    | Wrong API URL in React  | Check **App.js** or **.env** for the correct backend URL |
| API not working         | Server is not running  | Run `dotnet run` in the `/backend` directory |

---

## 💡 **Possible Improvements**
- **Add Authentication**: Secure the API with JWT tokens.
- **Add Docker Support**: Create a Dockerfile to run the entire project in containers.
- **Add Tests**: Write unit tests for API and frontend. 
- **Add CI/CD**: Set up GitHub Actions for CI/CD.

---

## 📜 **License**
This project is licensed under the **MIT License**. You are free to modify, distribute, and use it as you see fit.

---

## 🤝 **Contact**

If you have any questions, feel free to reach out!  
Enjoy tracking the ISS! 🚀🌍✨

---
