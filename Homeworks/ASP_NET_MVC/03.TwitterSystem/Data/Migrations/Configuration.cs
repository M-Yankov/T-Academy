namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using LoremNET;
    using System.Collections.Generic;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private const string AdminRole = "Admin";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedUsers(context);
            this.SeedTags(context);
            this.SeedTweets(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            int usersCount = 3;

            if (context.Users.Count() >= usersCount)
            {
                return;
            }

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            for (int i = 0; i < usersCount; i++)
            {
                User user = new User()
                {
                    Email = "user" + i + "@site.com",
                    UserName = "user" + i + "@site.com"
                };

                if (!userManager.Create(user, user.UserName).Succeeded)
                {
                    throw new InvalidOperationException("Cannot save users");
                }
            }
        }

        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Count() >= 3)
            {
                return;
            }

            Tag exam = new Tag() { Name = "exam" };
            Tag academy = new Tag() { Name = "academy" };
            Tag student = new Tag() { Name = "student" };

            context.Tags.AddOrUpdate(t => t.Name, exam, academy, student);
            context.SaveChanges();
        }

        private void SeedTweets(ApplicationDbContext context)
        {
            int tweetsCount = 12;

            if (context.Tweets.Count() >= tweetsCount)
            {
                return;
            }

            IList<Tag> tags = context.Tags.ToList();
            IList<string> userIds = context.Users.Select(u => u.Id).ToList();
            
            for (int i = 0; i < tweetsCount; i++)
            {
                Tweet tweet = new Tweet()
                {
                    Content = Lorem.Paragraph(100, 5),
                    DatePosted = DateTime.Now,
                    UserId = userIds[i % userIds.Count],
                    Tags = new List<Tag>() { tags[i % tags.Count] }
                };

                context.Tweets.AddOrUpdate(c => c.Content, tweet);
            }

            context.SaveChanges();
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
            if (context.Roles.Any(c => c.Users.Any()))
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            IdentityRole adminRole = new IdentityRole(AdminRole);
            if (!roleManager.Create(adminRole).Succeeded)
            {
                throw new InvalidOperationException(AdminRole + " role cannot be saved!");
            }

            context.SaveChanges();

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = false,
                RequiredLength = 5,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            User admin = new User()
            {
                Email = "admin@site.com",
                UserName = "admin"
            };

            if (!userManager.Create(admin, admin.UserName).Succeeded)
            {
                throw new InvalidOperationException(AdminRole + " user cannot be saved!");
            }

            if (!userManager.AddToRole(admin.Id, AdminRole).Succeeded)
            {
                throw new InvalidOperationException(AdminRole + " user cannot be added to it's role!");
            }
        }
    }
}
