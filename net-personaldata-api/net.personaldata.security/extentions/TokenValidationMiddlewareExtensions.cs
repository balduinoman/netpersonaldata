using Microsoft.AspNetCore.Builder;
using net.personaldata.security.middlewares;

namespace net.personaldata.security.extentions
{
    public static class TokenValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenValidationMiddleware>();
        }
    }
}
