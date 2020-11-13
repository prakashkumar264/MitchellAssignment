# MitchellAssignment

The assignment is built using C# and .NET using MVC design pattern.
Tools used are Visual Studio 2019, MS SQL Server and SSMS 18.7.1 .

This git contains the solution and script which contains the script to create the table for the solution.

## Running the project:<br />
1] Open SSMS <br />
2] Create a database named - mitchellvehicle.<br />
3] run the script. it will create the appropiate table<br />
4] Open the project in visual studio.<br />
5] Open the web.config and add the connection string in this format and put your correct DataSource:<br />
			`<connectionStrings> <add name="DBModel" connectionString="data source={YourDataSource};initial catalog=mitchellvehicle;integrated ecurity=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
				</connectionStrings>`
 6] Rebuild the Solution<br />
 7] Start the project using IIS Server(make sure project url in properties match with your local host)<br />

 
 
## Testing the solution: <br />
> Note: 	The test cases assumes the database is empty and id which is primary key is set to 0.  If not run this query: `DBCC CHECKIDENT (vehicles, RESEED, 0)` in sql 
The test cases test for create, read, edit and delete scenarios.
> Note: The test cases must run in the following sequence: 
1. VerifyThatMyDatabaseConnectionStringExists
2. TestCreateMake
3.Test_Detail_Null
4.Test_DetailView
5.Test_Detail_Data
6.Test_Edit_view
7.Test_Edit_Data
8. TestDeleteRedirect

