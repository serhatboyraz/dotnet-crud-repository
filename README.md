# dotnet-crud-repository
a dotnetcore layered crud repository and unitofworks demo project

# Dependency diagram:
![dependencies](architecture/dependency-diagram.png)

# Startup
Set this environment parameters on your database server setting.

`MYSQL_IP`
`MYSQL_PORT`
`MYSQL_USER`
`MYSQL_PASWORD`
`MYSQL_DB`

And use default all migrations to your database server.

PM> `Update-Database -StartupProject CrudRepositoryExample`

Than database migrations applied, you can use demo api endpoints.

for example send to : 

`PUT http://localhost:8012/User`

And content-type application/json body
`{
	"UserName" : "serhat.boyraz",
	"Password" : "123456"
}`

![user-example-1](architecture/user-example-1.png)
![user-example-1](architecture/user-example-2.png)

# enjoy!
