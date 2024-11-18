# 3DWKTViewer

**3DWKTViewer** is a web-based application designed to visualize and manage geometries in **WKT (Well-Known Text)** format on a 3D globe using **CesiumJS**. The application supports the conversion of WKT data into GeoJSON format, real-time rendering on the Cesium globe, and persistent storage of geometries in a relational database.

## Project Goals

The main objectives of this project are:
- To provide a user-friendly platform for viewing and managing 3D geometries.
- To enable seamless conversion of WKT data into GeoJSON for visualization on CesiumJS.
- To support real-time data entry, rendering, and database storage for efficient geometry management.

## Features

- **WKT to GeoJSON Conversion**: Automatically converts WKT input into GeoJSON format.
- **CesiumJS Integration**: Renders GeoJSON data dynamically on a 3D globe using Cesium.
- **Database Storage**: Stores WKT and GeoJSON geometries in a PostgreSQL database for persistence.
- **Real-Time Interaction**: Users can input WKT geometries, visualize them instantly, and save them with a single action.
- **Modern Design**: Built using ASP.NET Core MVC and follows best practices in N-Tier architecture.

## Application Workflow

1. **User Input**: Users provide WKT data via a web form.
2. **Data Processing**:
   - The server converts WKT data to GeoJSON using a custom service.
   - The GeoJSON data is stored in the database for future retrieval.
3. **Visualization**:
   - The processed GeoJSON is rendered dynamically on the CesiumJS globe.
4. **Database Management**:
   - Geometries are saved in a PostgreSQL database with support for retrieval and updates.

## Technologies Used

- **Frontend**: HTML5, CSS3, JavaScript, CesiumJS
- **Backend**: ASP.NET Core MVC
- **Database**: PostgreSQL
- **Libraries**:
  - [CesiumJS](https://cesium.com/cesiumjs/)
  - [Newtonsoft.Json](https://www.newtonsoft.com/json)
  - [NetTopologySuite](https://nettopologysuite.github.io/)
  - EFCore
  - NetTopology Suite

## Installation and Setup

1. Clone this repository:
   ```bash
   git clone https://github.com/candemiroguz/3DWKTViewer.git
   cd 3DWKTViewer
