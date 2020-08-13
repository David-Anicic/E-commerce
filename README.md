Follow the next steps to start the application:
 1) Open Git Bash and type: git clone https://github.com/David-Anicic/E-commerce
 2) open the cmd terminal and type sqllocaldb create instance_name - creating sql server instance
 3) Update appsettings.json file seting for Server name the instance_name (or type default instance name) and type some databae name.
 4) In Visual Studio open Package Manager Console and type: add-migration migration_name (set migration name as you like)
 5) Now type update-database
 6) execute Insert scripts
 7) start the project
