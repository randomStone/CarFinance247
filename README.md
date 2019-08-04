
# Run the Program

This program uses .NET Core 2.2.401, please ensure you have this version

## Running the WEB API

To build the Web Api container

```powershell
  docker-compose build
```

then run

```powershell
  docker-compose up
```

that will launch the server

The Http server will be running on <http://localhost:8000/>

### GET all Customers

Http GET  <http://localhost:8000/api/Customer> will return a json array with all customers

### GET Customer by ID

Http GET <http://localhost:8000/api/Customer/af5d23bf-490d-418a-a7ed-16cb4e8f907c> will return a json object repersenting the customer with id af5d23bf-490d-418a-a7ed-16cb4e8f907c

### POST Customer

Http POST <http://localhost:8000/api/Customer>
with example json body

```JSON
  {
    "id": "960f2a37-f889-467e-96f0-bd32fb7c71ee",
    "FirstName":"New",
    "Surname":"name",
    "EMail":"example@example.com",
    "CustomerPassword":"password"
  }
```

### PUT Customer

Http PUT <http://localhost:8000/api/Customer/af5d23bf-490d-418a-a7ed-16cb4e8f907c>
with example json body

```JSON
  {
    "FirstName":"New",
    "Surname":"name2",
    "EMail":"example@example.com",
    "CustomerPassword":"password"
  }
```

### Delete Customer

Http Delete <http://localhost:8000/api/Customer/af5d23bf-490d-418a-a7ed-16cb4e8f907c>
will delete customer with given id

## Running the Unit Tests

Simply run

```powershell
dotnet test
```
