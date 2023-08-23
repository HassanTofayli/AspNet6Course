namespace AspNet6Course.Middleware
{
    public class MiddleWareClass
    {
        private RequestDelegate _next;
        public MiddleWareClass()
        {

        }
        public MiddleWareClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("class middleware\n");
            }
            if (_next != null)
                await _next(context);
        }
    }
}
