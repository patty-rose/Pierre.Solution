# _Practice Treat Makers Website_

#### By _**Patty Otero**_

#### _A practice website for a C# treat website that uses Entity Framework for Roles and Users as well as MySQL database management._

## Technologies Used

* _C#_
* _.NET 5.0_
* _ASP.NET Core_ 
* _CSS_
* _HTML_
* _Entity_
* _MySQL Workbench_
* _LINQ_

## Description
This project was created for Epicodus bootcamp to show proficiency in Authentication with Identity.

_A practice c# website for a treat company. Seeded with an Admin User, Pierre, that can modify and acces CRUD routes for Treats, Flavors, and Roles. Users can login as well. Anonymous users can view the menu._

## Setup/Installation Requirements

* Clone this repository to your desktop
* Open your terminal and navigate to the top of this directory
* create a file called appsettings.json within the main project folder
* add the following text to the file inserting your own DATABASE NAME, USER ID, and PASSWORD: {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE NAME HERE];uid=[USER ID HERE];pwd=[PASSWORD HERE];"
  }
}
* Navigate to ~/Pierre in your terminal.
* Run the following commands:
>dotnet ef database update
>dotnet build
>dotnet run
* Use the localhost url with your web-browser to view the site
* Login with seeded Admin User to gain access to the /Role route (not available as a link anywhere, admin must type it into the url bar) and CRUD functionality for models
>user name: Pierre
>pw: Pierre'sTr34ts

## Known Bugs

* _none_

## License

_MIT_

Copyright (c) _2022_ _Patty Otero_