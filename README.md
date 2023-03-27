If we are going to deploy this on production, what do you think is the next
improvement that you will prioritize next? This can be a feature, a tech debt, or
an architectural design.

- Implement more unit test scenarios
- Implement SwaggerUI for API documentation
- Separate the solution for the client ReactJS app
- Add configurability in the appsettings or much better if database for hardcoded calculation figures
- IdentityServer4 can be on a separate solution so that we can remove the auth responsibility in the API
- I could've set up logs and AutoMapper 
- Make the app cloud enabled for better scalability and monitoring

If I were to make this cloud enabled, here are some steps that I'd do
- IdentityServer4 can be replaced to Microsoft Identity Platform and take advantage of MSAL
- DB can be replaced to Azure SQL DB
- API can be migrated to Azure Functions
- ReactJS app can be deployed to Azure App Services


Apologies if I didn't included unit tests, I really have a tight schedule with my current project and can barely do coding exams but I hope you could consider me

But if I were to implement unit tests, I'll use xUnit and use Moq to mock and test the EmployeeService, DataAccess and the Controller



Note: node_modules is excluded, please run npm install