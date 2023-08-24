using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Authentication
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public AuthenticationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key missing");
                return;
            }

            var apiKey = _configuration.GetValue<string>(AuthenticationConstants.ApiKeySectionName);

            if (!(apiKey == extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
                return;
            }
        }
    }
}
