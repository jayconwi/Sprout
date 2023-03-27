
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Sprout.Exam.WebApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {

        private readonly IHostEnvironment _hostEnvironment;

        public CustomExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
                return;
            

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
