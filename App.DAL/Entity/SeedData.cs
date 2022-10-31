﻿using App.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entity
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CMCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CMCContext>>()))
            {
                // Look for any movies.
                if (!context.Users.Any())
                {

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
                }

                // Look for any movies.
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role
                        {
                            RoleName = "Admin",
                            Status = 1
                        },
                        new Role
                        {
                            RoleName = "Staff",
                            Status = 1
                        },
                        new Role
                        {
                            RoleName = "User",
                            Status = 1
                        }
                    );
                }

                if (!context.CardTypes.Any())
                {
                    context.CardTypes.AddRange(
                        new CardType
                        {
                            TypeName = "Health",
                            Status = 1,
                            Detail = "An insurence for health"
                        },
                         new CardType
                         {
                             TypeName = "Motor",
                             Status = 1,
                             Detail = "An insurence for motor"
                         },
                          new CardType
                          {
                              TypeName = "Home",
                              Status = 1,
                              Detail = "An insurence for home"
                          });
                }
                if (!context.TemplateCards.Any())
                {
                    context.TemplateCards.AddRange(
                        new TemplateCard
                        {
                            TypeId = 10,
                            Title = "Liability coverage",
                            Price = 300,
                            Status = 1,
                        },
                         new TemplateCard
                         {
                             TypeId = 10,
                             Title = "(UM) coverage",
                             Price = 30,
                             Status = 1,
                         },
                          new TemplateCard
                          {
                              TypeId = 10,
                              Title = "Personal injury protection (PIP)",
                              Price = 30,
                              Status = 1,
                          },
                           new TemplateCard
                           {
                               TypeId = 10,
                               Title = "Medical payment coverage",
                               Price = 30,
                               Status = 1,
                           },
                            new TemplateCard
                            {
                                TypeId = 10,
                                Title = "Comprehensive and collision coverage",
                                Price = 30,
                                Status = 1,
                            },
                             new TemplateCard
                             {
                                 TypeId = 11,
                                 Title = "Personal property coverage",
                                 Price = 30,
                                 Status = 1,
                             },
                              new TemplateCard
                              {
                                  TypeId = 11,
                                  Title = "Liability coverage. ",
                                  Price = 30,
                                  Status = 1,
                              },
                               new TemplateCard
                               {
                                   TypeId = 11,
                                   Title = "Dwelling coverage",
                                   Price = 30,
                                   Status = 1,
                               },
                                new TemplateCard
                                {
                                    TypeId = 9,
                                    Title = "Personal property coverage",
                                    Price = 30,
                                    Status = 1,
                                },
                                 new TemplateCard
                                 {
                                     TypeId = 9,
                                     Title = "Other structures on the property",
                                     Price = 30,
                                     Status = 1,
                                 },
                                  new TemplateCard
                                  {
                                      TypeId = 9,
                                      Title = "Liability coverage",
                                      Price = 30,
                                      Status = 1,
                                  }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
