
using TeacherDiary.WebApi.Exceptions;

namespace TeacherDiary.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
            catch (Exception message)
            {
                context.Response.StatusCode = 404;

                await Console.Out.WriteLineAsync(message.ToString());

                await context.Response.WriteAsync("Nie odnaleziono.");
            }

            catch (Exception message)
			{
                context.Response.StatusCode = 500;

                await Console.Out.WriteLineAsync(message.ToString());

                await context.Response.WriteAsync("Coś poszło nie tak spróbuj ponowanie");
			}

        }
    }
}
