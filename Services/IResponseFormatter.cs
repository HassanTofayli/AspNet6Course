namespace AspNet6Course.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}
