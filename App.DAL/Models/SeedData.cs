using App.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CmcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CmcContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        RoleId = 1,
                        Username = "Jun",
                        Email = "jun@gmail.com",
                        Password = "123456",
                        Fullname = "Jun Lee",
                        PhoneNumber = "01234566",
                        Address = "UK",
                        IdentityNumber = "012345677",
                        Status = 1
                    },

                      new User
                      {
                          RoleId = 2,
                          Username = "Bunbeo",
                          Email = "bun@gmail.com",
                          Password = "123456",
                          Fullname = "Lee Thi Bun Beo",
                          PhoneNumber = "01234566",
                          Address = "UK-VN",
                          Status = 1,
                          IdentityNumber = "012345677"
                      },
                        new User
                        {
                            RoleId = 3,
                            Username = "Chuoibeo",
                            Email = "chuoi@gmail.com",
                            Password = "123456",
                            Fullname = "Chuoi beo",
                            PhoneNumber = "01234566",
                            Address = "UK-VN",
                            Status = 1,
                            IdentityNumber = "012345677"
                        },
                          new User
                          {
                              RoleId = 4,
                              Username = "Tea",
                              Email = "tea@gmail.com",
                              Password = "123456",
                              Fullname = "Tea Nguyen",
                              PhoneNumber = "01234566",
                              Address = "VN",
                              Status = 1,
                              IdentityNumber = "012345677"
                          }
                );
                context.SaveChanges();

                // Look for any movies.
                if (context.Roles.Any())
                {
                    return;   // DB has been seeded
                }

                context.Roles.AddRange(
                    new Role
                    {
                       RoleId= 1,
                       RoleName = "User",
                       Status= 1
                    },
                    new Role
                    {
                        RoleId = 2,
                        RoleName = "Admin",
                        Status = 1
                    },
                    new Role
                    {
                        RoleId = 3,
                        RoleName = "Staff",
                        Status = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
