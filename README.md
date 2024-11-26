
# TVMazeScraper
- A .NET-based application that scrapes TV show and cast information from the TVMaze API and stores the data in an SQLite database. The project includes a REST API to query the stored data.

# Features
- Scrapes data from the TVMaze API, including show information and the cast of each show.
- Saves the data in an SQLite database.
- Exposes a REST API to get the list of TV shows with their cast, sorted by birthdate in descending order.
- Supports pagination.

# Prerequisites
To run this project, ensure that you have the following installed:

.NET 9.0 SDK
SQLite
Visual Studio Code (or any other editor)

# Setup
- Clone the repository:

git clone https://github.com/sedefgokesmer/tv-maze.git

- Install the required packages: Navigate to the project folder and run the following command to restore dependencies:

dotnet restore

- Configure the SQLite database connection: In appsettings.json, update the connection string to point to your SQLite database.

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tvmaze.db"
  }
}

- Run the migrations: If you haven’t already created the database, run the migrations to set up the schema:

dotnet ef migrations add InitialCreate
dotnet ef database update

- Run the application: You can run the application using:

dotnet run

The application will start the web server.

# API Endpoints
- GET /api/shows

Description: Retrieves a list of all TV shows with their cast, ordered by show ID.

Query Parameters:
pageNumber (optional): The page number to retrieve (default is 1).
pageSize (optional): The number of items per page (default is 10).

Response: A paginated list of shows with their cast.

[
  {
    "id": 1,
    "name": "Game of Thrones",
    "cast": [
      {
        "id": 7,
        "name": "Mike Vogel",
        "birthday": "1979-07-17"
      },
      {
        "id": 9,
        "name": "Dean Norris",
        "birthday": "1963-04-08"
      }
    ]
  }
]

# Development

To scrape data from the TVMaze API manually:
The scraper runs on startup to fetch data from the TVMaze API. However, you can manually trigger the scraper by calling the GetShowData method in the TVMazeService class.

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var tvMazeService = services.GetRequiredService<TVMazeService>();
    await tvMazeService.GetShowData();
}

To add a new migration:
- If you need to modify the database schema, you can create a new migration:

dotnet ef migrations add MigrationName
dotnet ef database update
