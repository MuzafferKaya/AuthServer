using DomainModel.UnitOfWork;
using Dto.Response.Error;
using System.Net;
using System.Text.Json;

namespace Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlobalExceptionHandlingMiddleware(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                ErrorDetailsResponse errorDetailsResponse = new()
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    title = "Internal Server Error",
                    message = ex.Message
                };

                string json = JsonSerializer.Serialize(new { error = errorDetailsResponse });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
