namespace StoreOnline.API.MiddleWares
{
    public class ErrorMiddleWare //: IMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }
            catch (Exception)
            {

            }
        }
    }
}
