
# 🌌 ISS Tracker

Track the real-time location of the **International Space Station (ISS)** relative to **Seattle**. This project includes a **React frontend** and a **.NET backend**, both of which are fully containerized using **Docker**.

---

## 📁 **Project Structure**
```
/dotnet
  ├── /backend       # Backend .NET 9 Web API (Dockerized)
  └── /frontend      # Frontend React 18 Web App (Dockerized)
```

---

## 🚀 **Technologies Used**
- **Frontend**: React 18
- **Backend**: .NET 9 (C#)
- **API**: [Open Notify ISS API](http://open-notify.org/)
- **Docker**: Backend and frontend are fully containerized
- **CORS**: Configured to allow cross-origin requests from the frontend

---

## 📦 **Setup Instructions**

### **1️⃣ Prerequisites**
Make sure you have the following tools installed on your system:
- **Docker**: [Install Docker](https://docs.docker.com/get-docker/)
- **Node.js**: [Install Node.js](https://nodejs.org/) (if you plan to run the frontend locally)
- **.NET 9**: [Install .NET](https://dotnet.microsoft.com/download)

---

## ⚙️ **How to Run the Project (Docker)**
You can run **both the backend and frontend using Docker**. This is the recommended approach.

### **Run Backend and Frontend Using Docker**
1. **Navigate to the project root directory**:
   ```bash
   cd /path/to/your/project/dotnet
   ```

2. **Run the Docker containers**:
   ```bash
   docker-compose up --build
   ```

3. **Access the application**:
   - **Frontend**: http://localhost:3000
   - **Backend (API)**: http://localhost:5000

4. **View Swagger documentation** (API docs):
   - **Swagger UI**: http://localhost:5000/swagger

5. **To stop the containers**:
   ```bash
   docker-compose down
   ```

> 📝 **Note**: The frontend and backend are both **containerized** and can be run together with `docker-compose`.

---

## 📦 **File Structure**
```
.
├── backend
│   ├── Dockerfile
│   └── ... (other backend files)
├── frontend
│   ├── Dockerfile
│   ├── .dockerignore
│   ├── package.json
│   └── ... (other frontend files)
├── docker-compose.yml
└── README.md
```

---

## 📦 **Docker Commands for Development**
Here are some helpful commands to manage your Docker containers.

| **Command**                      | **Description**                                    |
|----------------------------------|---------------------------------------------------|
| `docker-compose up --build`      | Build and run the containers (frontend & backend)  |
| `docker-compose down`            | Stop and remove all containers                    |
| `docker-compose logs -f`         | View real-time logs from both containers          |
| `docker system prune -a`         | Remove all containers, images, and cache          |

---

## 🌐 **API Endpoints**
The backend exposes the following API endpoints:

| **Method** | **Endpoint**               | **Description**            |
|------------|---------------------------|----------------------------|
| **GET**    | `/api/iss/iss-location`    | Get ISS location and its distance from Seattle |

---

## 🔥 **How It Works**
1. **Backend**: The backend calls the **Open Notify ISS API** to fetch the real-time location of the ISS.
2. **Calculation**: The distance from **Seattle** to the ISS is calculated using the **Haversine formula**.
3. **Frontend**: The frontend displays the current location of the ISS relative to **Seattle** on a map.

---

## 📜 **Environment Variables**
You can configure **environment variables** for the project using a `.env` file.

**Example `.env` file**:
```
REACT_APP_BACKEND_URL=http://localhost:5000
```

> **Note**: The backend URL is required so that the frontend can communicate with the backend.

---

## 📦 **Project Commands**
Here are the most useful commands for development.

| **Command**                 | **Description**                      |
|----------------------------|--------------------------------------|
| `docker-compose up --build` | Run the backend and frontend together with Docker |
| `docker-compose down`       | Stop and remove Docker containers     |
| `dotnet run`                | Run the backend locally without Docker |
| `npm start`                 | Run the frontend locally without Docker |
| `npm install`               | Install dependencies for the frontend |

---

## 🌐 **API Example**
You can use **curl** or **Postman** to test the API.

```bash
curl -X 'GET'   'http://localhost:5000/api/iss/iss-location'   -H 'accept: */*'
```

**Example Response**:
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

## 🛠️ **Troubleshooting**
If you run into issues, here are a few tips:

- **Port is already in use**:  
  ```bash
  lsof -i :3000
  kill -9 <PID>
  ```

- **Container is stuck in restarting**:  
  ```bash
  docker-compose down
  docker-compose up --build
  ```

- **Node modules are corrupted**:  
  ```bash
  rm -rf node_modules package-lock.json
  npm install
  ```

- **Clear Docker cache**:  
  ```bash
  docker system prune -a
  ```

---

## 📚 **Resources**
- [Docker Documentation](https://docs.docker.com/)
- [React Documentation](https://reactjs.org/)
- [.NET 9 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)

---

## 📄 **License**
This project is licensed under the **MIT License**. Feel free to use it for personal or commercial purposes.

