
using TeacherDiary.Web.Middlewares.Exceptions;

namespace TeacherDiary.Web.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException message)
            {
                context.Response.StatusCode = 404;

                await context.Response.WriteAsync("Nie odnaleziono. Spróbuj jeszcze raz.");
            }
            catch (Exception message)
            {
                context.Response.StatusCode = 500;

                await Console.Out.WriteLineAsync(message.ToString());

                await context.Response.WriteAsync("Coś poszło nie tak spróbuj ponowanie.");
            }
        }
    }
}
