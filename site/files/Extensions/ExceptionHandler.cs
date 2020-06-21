using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Site.Extentions
{
  public class ExceptionHandler
  {
    private readonly RequestDelegate next;

    public ExceptionHandler(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      string result = null;
      HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

      if (exception is ValidationException)
      {
        statusCode = HttpStatusCode.BadRequest;
        result = JsonConvert.SerializeObject(new { error = exception.Message });
      }
      else
      {
        Console.WriteLine(exception.StackTrace + " - " + exception.Message);
        result = JsonConvert.SerializeObject(new { error = "Erro interno." });
      }

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)statusCode;
      return context.Response.WriteAsync(result);
    }
  }
}