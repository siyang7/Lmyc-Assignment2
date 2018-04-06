using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Data
{
    public class DummyData
    {
        // Boats sample data
        public Boat[] GetBoats(ApplicationDbContext context)
        {
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var adminUser = userManager.FindByEmail("a@a.a");
            //var memberUser = userManager.FindByEmail("m@m.m");

            
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
                    //CreatedBy = adminUser.Id,
                },
                new Boat()
                {
                    BoatName = "Second Boat",
                    Picture = "https://prodwebassets.s3.amazonaws.com/boats/4681976/4681976_20140410082304491_1_XLARGE.jpg",
                    LengthInFeet = 10.5,
                    Make = "China",
                    Year = 2018,
                    CreationDate = new DateTime(2018,01,17,19,00,00),
                    //CreatedBy = memberUser.Id,
                },
                new Boat()
                {
                    BoatName = "Third Boat",
                    Picture = "http://features.boats.com/boat-content/files/2018/01/cruisers-cantius-42.jpg?w=1200&h=1200",
                    LengthInFeet = 11.0,
                    Make = "Brazil",
                    Year = 2016,
                    CreationDate = new DateTime(2018,02,17,19,00,00),
                    //CreatedBy = memberUser.Id,
                }

            };
            

            return boats.ToArray();

            /*
            public static void Initialize(ApplicationDbContext db)
            {
                if (!db.Boats.Any())
                {
                    db.Boats.Add(new Student
                    {
                        FirstName = "Bob",
                        LastName = "Doe",
                        School = "Engineering",
                        StartDate = Convert.ToDateTime("2015/09/09")
                    });
                    db.Students.Add(new Student
                    {
                        FirstName = "Ann",
                        LastName = "Lee",
                        School = "Medicine",
                        StartDate = Convert.ToDateTime("2014/09/09")
                    });
                    db.Students.Add(new Student
                    {
                        FirstName = "Sue",
                        LastName = "Douglas",
                        School = "Pharmacy",
                        StartDate = Convert.ToDateTime("2016/01/01")
                    });
                    db.Students.Add(new Student
                    {
                        FirstName = "Tom",
                        LastName = "Brown",
                        School = "Business",
                        StartDate = Convert.ToDateTime("2015/09/09")
                    });
                    db.Students.Add(new Student
                    {
                        FirstName = "Joe",
                        LastName = "Mason",
                        School = "Health",
                        StartDate = Convert.ToDateTime("2015/01/01")
                    });
                    db.SaveChanges();
                }
            }
            */
        }
    }
}
