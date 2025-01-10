using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TargDeMuzica.Data;

namespace TargDeMuzica.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                
                // Verificam daca in baza de date exista cel putin rol
                // insemnand ca a fost rulat codul
                // De aceea facem return pentru a nu insera inca o data
                // Acesta metoda trebuie sa se execute o singura data
                if (context.Roles.Any())
                {
                    return; // database already contains seed data
                }

                // CREAREA ROLURILOR IN BD
                // daca nu contine roluri, acestea se vor crea
                context.Roles.AddRange(
                    new IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        Name = "Administrator",
                        NormalizedName = "Administrator".ToUpper()
                    },

                    new IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                        Name = "Colaborator",
                        NormalizedName = "Colaborator".ToUpper()
                    },

                    new IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                        Name = "UserN",
                        NormalizedName = "UserN".ToUpper()
                    },

                    new IdentityRole
                    {
                        Id = "68de4b1f-fcdc-42cc-acbc-60f58da2d070",
                        Name = "UserI",
                        NormalizedName = "UserI".ToUpper()
                    }
                );

                // o noua instanta pe care o vom utiliza pentru  crearea parolelor utilizatorilor
                // parolele sunt de tip hash
                var hasher = new PasswordHasher<ApplicationUser>();

                // CREAREA USERILOR IN BD
                // Se creeaza cate un user pentru fiecare rol
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0",
                        UserName = "admin@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@TEST.COM",
                        Email = "admin@test.com",
                        NormalizedUserName = "ADMIN@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },

                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb1",
                        UserName = "editor@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "EDITOR@TEST.COM",
                        Email = "editor@test.com",
                        NormalizedUserName = "EDITOR@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Editor1!")
                    },

                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb2",
                        UserName = "user@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@TEST.COM",
                        Email = "user@test.com",
                        NormalizedUserName = "USER@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "User1!")
                    }
                );

                // ASOCIEREA USER-ROLE
                context.UserRoles.AddRange(
                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                    },

                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb1"
                    },

                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
                    }
                );



                context.SaveChanges();
            }
        }
    }
}
