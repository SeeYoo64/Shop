Clone the repository

```bash
git clone https://github.com/SeeYoo64/Shop.git
cd Shop
```
Update the connection string (in appsettings.json or appsettings.Development.json):

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=shopdb;Username=postgres;Password=1337"
}
```
Run database migrations

```bash
dotnet ef database update
```
Run the project

```bash
dotnet run
```
Open Swagger UI
Navigate to: http://localhost:5XXX/swagger

