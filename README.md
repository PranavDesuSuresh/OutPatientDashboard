# OutPatientDashboard

Setup

API Setup
1. Using sql server, create a databse on the server.
2. Update the connection string to the db in ~\OutPatientDashboard.Service\OutPatientDashboard.Service\appsettings.json against the key DefaultConnString.
3. Open ~\OutPatientDashboard.Service\OutPatientDashboard.Service.sln on visual studio and build project.
4. After successfull build, on package manager console run the below commands
	* run "Add-Migration InitialCreate"
	* run "Update-Database"
5. Run the datascripts in the specified numbered order. Available at - ~\DataScripts on your db.
6. Run the Service project via VS. This should bring up the swagger page.

Frontend Setup - 
1. Open project in vscode
2. run "npm run dev" on terminal

Please note - Everytime time you want to reset the data please feel free to run ~\DataScripts\2-Patients.sql. It removes previous data and adds new data for today.

Swagger URL - https://localhost:7166/swagger/index.html
Web URL - http://localhost:5173/
