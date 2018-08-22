namespace LanguageLearningPlatform.Web
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    public static class DatabaseSeedExtension
    {
        public static IApplicationBuilder SeedAndMigrateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = scope.ServiceProvider.GetService<LearningContext>();
                db.Database.Migrate();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                List<string> roles = typeof(GlobalConstants).GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.Name.EndsWith("Role")).Select(f => f.GetValue(typeof(GlobalConstants))).Cast<string>().ToList();
                Task.Run(async () =>
                {
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                        bool existsSeededUser = !(await userManager.GetUsersInRoleAsync(role)).Any();
                        if (existsSeededUser)
                        {
                            User user = new User()
                            {
                                Email = $"{role}@users.com",
                                UserName = $"{role}"
                            };

                            await userManager.CreateAsync(user, role.ToLower());
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }).GetAwaiter().GetResult();
                int countOfLanguages = db.Languages.Count();
                if (countOfLanguages == 0)
                {
                    string allLanguages = File.ReadAllText("languages.json");
                    JArray o1 = JArray.Parse(allLanguages);
                    List<Language> link = o1.Select(j => new Language
                    {
                        Name = (string) j["name"],
                        Code = (string) j["code"]
                    }).ToList();
                    db.Languages.AddRange(link);
                    db.SaveChanges();
                }
            }

            return app;
        }
    }
}