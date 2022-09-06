using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;

            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;
                {
                    //Bu hata ise validation hatası olursa return edilecek.
                    return httpContext.Response.WriteAsync(new ValidationErrorDetails
                    {
                        StatusCode = 400,
                        Message = message,
                        ValidationErrors = errors
                    }.ToString());
                }
            }

            //api hata verirse bunu return et.
            //toString metodu ErrorDetails sınıfında extend edildi.
            //string olarak değil Json olarak return edecek.
            //Bu hata sistemsel hatalar olduğu zaman return edilecek
            //Veri tabanı hatası, server hatası vb. vb.
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}