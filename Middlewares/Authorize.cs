namespace ApiPengurus.Middlewares
{
    public class Authorize
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "ApiKey";
        public Authorize(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key not found");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService <IConfiguration> ();
            var apiKey = appSettings.GetValue<string> (API_KEY);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized / API Key not match");
                return;
            }

            await _next(context);
        }
    }
}