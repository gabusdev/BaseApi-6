using BaseApi.Core.Entities.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaseApi.Api.AppServices.Authorization
{
    public static class AuthorizationExtension
    {
        public static void ConfigureAuthorization(this IServiceCollection services, bool locked = false)
        {

            services.AddAuthorization(opt =>
            {
                if (locked)
                {
                    opt.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
                }
                opt.AddPolicy("AdminRights",
                    policy => policy.RequireRole(Enum.GetName(RoleEnum.Administrator)!));
            });

        }
    }
}
