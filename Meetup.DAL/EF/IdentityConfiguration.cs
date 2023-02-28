using Meetup.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.DAL.EF {
    public static class IdentityConfiguration {
        public static void ConfigureIdentity(this IServiceCollection services) {

            var builder = services.AddIdentityCore<User>(o => {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
                o.User.RequireUniqueEmail = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<repContext>().AddDefaultTokenProviders();
        }
    }
}
