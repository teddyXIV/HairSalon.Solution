# Eau Claire's Salon

####  An MVC web application to help a fictional salon owner manage her stylists and their clients.

#### By Teddy Peterschmidt

## Technologies Used

* C#
* .NET 6 SDK
* Entity Framework Core
* MSTest

## Description

This application allows the user to manage the salon's stylists and client through the following functionality: 
* Adding to a list of stylists 
* Editing stylist information
* Deleting sylists
* Adding clients to stylists
* Editing client details
* Deleting clients

## Setup/Installation Requirements

* Clone this repository.
* Use the `teddy_peterschmidt.sql` file located at to the top level of the repo to create a new database in MySQL Workbench with the name `teddy_peterschmidt`.
* Navigate to the production directory HairSalon.
* Within the production directory "HairSalon", create a new file called `appsettings.json`.
* Within `appsettings.json`, put in the following code,  replace the `uid` and `pwd` values with your owen username and password for MySQL.
```json 
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=teddy_peterschmidt;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* In the command line, run "dotnet restore" to download and install packages.
* In the command line, run the command "dotnet run" to compile and execute the application.
* Optionally, you can run "dotnet build" to compile this application without running it.

## Known Bugs

* Unknown at this time.

## License

[MIT License](./LICENSE)