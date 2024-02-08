# Eau Claire's Salon

####  An MVC web application to help a fictional salon owner manage her stylists and their clients.

#### By Teddy Peterschmidt

## Technologies Used

* C#
* .NET 6 SDK
* Entity Framework Core

## Description

This application allows the user to manage the salon's stylists and clients through the following functionality: 
* Adding to a list of stylists 
* Editing stylist information
* Deleting sylists
* Adding clients to stylists
* Editing client details
* Deleting clients
* Search for a specific client or stylist
* Schedule appointments for clients

## Setup/Installation Requirements

* Clone this repository.
* If needed, download and configure MySQL Workbench for your operating system by following the instructions in [this lesson.](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* Launch MySQL Workbench and open your local instance so that the Navigator window is visible and complete the following steps:
  * Select the *Administration* tab from the bottom of the *Navigator* window.
  * Select *Data Import/Restore*.
  * In *Import Options*, select *Import from Self-Contained File*.
  * Navigate to the `teddy_peterschmidt.sql` file located at the top level of the repo.
  * Under *Default Schema to be Imported To*, select the *New* button.
  * Name the database `teddy_peterschmidt`.
  * Click *Ok*.
  * Navigate to the *Import Progress* tab and click *Start*.
  * Select the *Schema* tab from the bottom of the Navigator window and select *Refresh All* to view the new database. 
* Navigate to the production directory HairSalon.
* Within the production directory "HairSalon", create a new file called `appsettings.json`.
* Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.
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