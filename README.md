

Here's my answer to the question:
>"If we are going to deploy this on production, what do you think is the next
improvement that you will prioritize next? This can be a feature, a tech debt, or
an architectural design."

- Implement unit test scenarios to ensure future changes still met the requirements
- Implement SwaggerUI for API documentation
- Configure Scaffold-DbContext to include data annotations and take advantage of that to have data validations
- Separate the solution for the client ReactJS app
- Add configurability for the hardcoded calculation figures in the appsettings or much better if it's in the database 
- IdentityServer4 can be on a separate solution so that we can remove the auth responsibility in the API
- Set up logs and AutoMapper 
- Make the app cloud enabled for better scalability and monitoring
- Add interface for the EmployeeService and UnitOfWork

If I were to make this cloud enabled, here are some steps that I'd do
- IdentityServer4 can be replaced to Microsoft Identity Platform and take advantage of MSAL
- DB can be replaced to Azure SQL DB
- API can be migrated to Azure Functions
- ReactJS app can be deployed to Azure App Services

___

I apologize if I didn't include unit tests, I really have a tight schedule with my current project and can barely do coding exams but I hope you could consider me

But if I were to implement unit tests, I'll use xUnit, NUnit or MSTest and use Moq to mock and test the .Business, .DataAccess and the API endpoints

___

Note: node_modules is excluded in this commit, please run `npm install`
