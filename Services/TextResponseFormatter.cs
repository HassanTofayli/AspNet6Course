namespace AspNet6Course.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int _ResponseCounter = 0;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Response: {++_ResponseCounter}\n");
        }
    }
}
