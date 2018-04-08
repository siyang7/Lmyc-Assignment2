using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Data
{
    public static class DummyData
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            IdentityResult result;

            if (userManager.FindByEmailAsync("a@a.a").Result == null)
            {
                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "a",
                    Email = "a@a.a",
                    FirstName = "Bob",
                    LastName = "Admin",
                    Street = "Main St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V5V 1J6",
                    Country = "Canada",
                    MobilePhone = "604-222-1111",
                    SailingExperience = "medium",
                };

                result = userManager.CreateAsync(admin, "P@$$w0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("m@m.m").Result == null)
            {
                ApplicationUser member = new ApplicationUser()
                {
                    UserName = "m",
                    Email = "m@m.m",
                    FirstName = "Jane",
                    LastName = "Member",
                    Street = "Howe St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V1T 7U9",
                    Country = "Canada",
                    MobilePhone = "604-999-2222",
                    SailingExperience = "low",
                };

                result = userManager.CreateAsync(member, "P@$$w0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(member, "Member").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        // Boats sample data
        public static void GetBoats(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Boats.
            if (context.Boats.Any())
            {
                return;   // DB has been seeded
            }

            List<Boat> boats = new List<Boat>
            {
                new Boat()
                {
                    BoatName = "First Boat",
                    Picture = "http://images.boats.com/resize/1/6/27/6500627_20171020071454151_1_LARGE.jpg?w=300&h=300",
                    LengthInFeet = 7.5,
                    Make = "Canada",
                    Year = 2017,
                    CreationDate = new DateTime(2018,01,01,8,00,00),
                    ApplicationUserId = context.Users.FirstOrDefault(u => u.Email == "m@m.m").Id,
                },
                new Boat()
                {
                    BoatName = "Second Boat",
                    Picture = "https://prodwebassets.s3.amazonaws.com/boats/4681976/4681976_20140410082304491_1_XLARGE.jpg",
                    LengthInFeet = 10.5,
                    Make = "China",
                    Year = 2018,
                    CreationDate = new DateTime(2018,01,17,19,00,00),
                    User = context.Users.FirstOrDefault(u => u.Email == "m@m.m"),
                },
                new Boat()
                {
                    BoatName = "Third Boat",
                    Picture = "http://features.boats.com/boat-content/files/2018/01/cruisers-cantius-42.jpg?w=1200&h=1200",
                    LengthInFeet = 11.0,
                    Make = "Britain",
                    Year = 2016,
                    CreationDate = new DateTime(2018,02,17,19,00,00),
                    User = context.Users.FirstOrDefault(u => u.Email == "a@a.a"),
                }

            };

            foreach (Boat b in boats)
            {
                context.Boats.Add(b);
            }
            context.SaveChanges();
        }
    }
}
