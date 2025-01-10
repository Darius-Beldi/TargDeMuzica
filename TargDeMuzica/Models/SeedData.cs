using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TargDeMuzica.Data.Migrations;
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
                    return; // baza de date contine deja roluri
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
                        NormalizedName = "Colaborat".ToUpper()
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




                // Add this to your SeedData.cs Initialize method after the user roles seeding

                // MUSIC SUPPORT TYPES
                context.MusicSuports.AddRange(
                    new MusicSuport { MusicSuportID = 1, MusicSuportName = "Vinyl" },
                    new MusicSuport { MusicSuportID = 2, MusicSuportName = "CD" },
                    new MusicSuport { MusicSuportID = 3, MusicSuportName = "Digital Download" },
                    new MusicSuport { MusicSuportID = 4, MusicSuportName = "Cassette" }
                );

                // ARTISTS
                context.Artists.AddRange(
                    new Artist
                    {
                        ArtistID = 1,
                        ArtistName = "Pink Floyd",
                        ArtistAge = 0  // Band
                    },
                    new Artist
                    {
                        ArtistID = 2,
                        ArtistName = "David Bowie",
                        ArtistAge = 0  // Deceased
                    },
                    new Artist
                    {
                        ArtistID = 3,
                        ArtistName = "Taylor Swift",
                        ArtistAge = 34
                    },
                    new Artist
                    {
                        ArtistID = 4,
                        ArtistName = "The Beatles",
                        ArtistAge = 0  // Band
                    },
                    new Artist
                    {
                        ArtistID = 5,
                        ArtistName = "Queen",
                        ArtistAge = 0  // Band
                    },
                    new Artist
                    {
                        ArtistID = 6,
                        ArtistName = "Led Zeppelin",
                        ArtistAge = 0  // Band
                    },
                    new Artist
                    {
                        ArtistID = 7,
                        ArtistName = "Bob Dylan",
                        ArtistAge = 82
                    },
                    new Artist
                    {
                        ArtistID = 8,
                        ArtistName = "Radiohead",
                        ArtistAge = 0  // Band
                    }
                );

                // PRODUCTS
                context.Products.AddRange(
                    // Original 5 products
                    new Product
                    {
                        ProductID = 1,
                        ProductName = "The Dark Side of the Moon",
                        ProductDescription = "Iconic 1973 album featuring 'Money' and 'Time'. Remastered 180g vinyl.",
                        ProductPrice = 29.99f,
                        ProductStock = 50,
                        ProductImageLocation = "/images/dark-side-moon.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Progressive Rock", "Psychedelic" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 1  // Pink Floyd
                    },
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "Heroes",
                        ProductDescription = "David Bowie's 1977 masterpiece, featuring the iconic title track. High-quality digital remaster.",
                        ProductPrice = 12.99f,
                        ProductStock = 100,
                        ProductImageLocation = "/images/heroes.jpg",
                        ProductScore = 4.8f,
                        ProductGenres = new List<string> { "Art Rock", "Experimental" },
                        MusicSuportID = 3,  // Digital Download
                        ArtistID = 2  // David Bowie
                    },
                    new Product
                    {
                        ProductID = 3,
                        ProductName = "1989 (Taylor's Version)",
                        ProductDescription = "Re-recorded version of the iconic 2014 album, including all vault tracks.",
                        ProductPrice = 14.99f,
                        ProductStock = 200,
                        ProductImageLocation = "/images/1989.jpg",
                        ProductScore = 4.7f,
                        ProductGenres = new List<string> { "Pop", "Synth-pop" },
                        MusicSuportID = 2,  // CD
                        ArtistID = 3  // Taylor Swift
                    },
                    new Product
                    {
                        ProductID = 4,
                        ProductName = "Abbey Road",
                        ProductDescription = "The Beatles' final recorded album, featuring 'Come Together' and 'Here Comes the Sun'. Anniversary Edition.",
                        ProductPrice = 34.99f,
                        ProductStock = 30,
                        ProductImageLocation = "/images/abbey-road.jpg",
                        ProductScore = 5.0f,
                        ProductGenres = new List<string> { "Rock", "Pop Rock" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 4  // The Beatles
                    },
                    new Product
                    {
                        ProductID = 5,
                        ProductName = "A Night at the Opera",
                        ProductDescription = "Queen's fourth studio album featuring 'Bohemian Rhapsody'. Limited edition cassette.",
                        ProductPrice = 19.99f,
                        ProductStock = 15,
                        ProductImageLocation = "/images/night-at-opera.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Rock", "Progressive Rock" },
                        MusicSuportID = 4,  // Cassette
                        ArtistID = 5  // Queen
                    },

                    // Additional products
                    new Product
                    {
                        ProductID = 6,
                        ProductName = "The Wall",
                        ProductDescription = "Pink Floyd's epic rock opera concept album. Double vinyl set with gatefold sleeve.",
                        ProductPrice = 39.99f,
                        ProductStock = 40,
                        ProductImageLocation = "/images/the-wall.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Progressive Rock", "Rock Opera" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 1  // Pink Floyd
                    },
                    new Product
                    {
                        ProductID = 7,
                        ProductName = "Ziggy Stardust",
                        ProductDescription = "The Rise and Fall of Ziggy Stardust and the Spiders from Mars. Definitive remaster.",
                        ProductPrice = 24.99f,
                        ProductStock = 75,
                        ProductImageLocation = "/images/ziggy.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Glam Rock", "Rock" },
                        MusicSuportID = 2,  // CD
                        ArtistID = 2  // David Bowie
                    },
                    new Product
                    {
                        ProductID = 8,
                        ProductName = "Midnights",
                        ProductDescription = "Taylor Swift's tenth studio album including '3am Edition' bonus tracks.",
                        ProductPrice = 16.99f,
                        ProductStock = 150,
                        ProductImageLocation = "/images/midnights.jpg",
                        ProductScore = 4.6f,
                        ProductGenres = new List<string> { "Pop", "Alternative" },
                        MusicSuportID = 2,  // CD
                        ArtistID = 3  // Taylor Swift
                    },
                    new Product
                    {
                        ProductID = 9,
                        ProductName = "Revolver",
                        ProductDescription = "The Beatles' groundbreaking 1966 album. 2022 special edition mix by Giles Martin.",
                        ProductPrice = 32.99f,
                        ProductStock = 25,
                        ProductImageLocation = "/images/revolver.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Rock", "Psychedelic Rock" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 4  // The Beatles
                    },
                    new Product
                    {
                        ProductID = 10,
                        ProductName = "News of the World",
                        ProductDescription = "Features the anthems 'We Will Rock You' and 'We Are the Champions'.",
                        ProductPrice = 22.99f,
                        ProductStock = 60,
                        ProductImageLocation = "/images/news-world.jpg",
                        ProductScore = 4.7f,
                        ProductGenres = new List<string> { "Rock", "Arena Rock" },
                        MusicSuportID = 2,  // CD
                        ArtistID = 5  // Queen
                    },

                    // More additional products
                    new Product
                    {
                        ProductID = 11,
                        ProductName = "Led Zeppelin IV",
                        ProductDescription = "Featuring 'Stairway to Heaven'. Audiophile-grade 180g vinyl pressing.",
                        ProductPrice = 34.99f,
                        ProductStock = 45,
                        ProductImageLocation = "/images/ledzep-4.jpg",
                        ProductScore = 5.0f,
                        ProductGenres = new List<string> { "Hard Rock", "Folk Rock" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 6  // Led Zeppelin
                    },
                    new Product
                    {
                        ProductID = 12,
                        ProductName = "Highway 61 Revisited",
                        ProductDescription = "Bob Dylan's influential 1965 album with 'Like a Rolling Stone'.",
                        ProductPrice = 27.99f,
                        ProductStock = 35,
                        ProductImageLocation = "/images/highway61.jpg",
                        ProductScore = 4.8f,
                        ProductGenres = new List<string> { "Folk Rock", "Rock" },
                        MusicSuportID = 1,  // Vinyl
                        ArtistID = 7  // Bob Dylan
                    },
                    new Product
                    {
                        ProductID = 13,
                        ProductName = "OK Computer",
                        ProductDescription = "Radiohead's critically acclaimed masterpiece. Digital HD download.",
                        ProductPrice = 11.99f,
                        ProductStock = 200,
                        ProductImageLocation = "/images/okcomputer.jpg",
                        ProductScore = 4.9f,
                        ProductGenres = new List<string> { "Alternative Rock", "Art Rock" },
                        MusicSuportID = 3,  // Digital Download
                        ArtistID = 8  // Radiohead
                    },
                    new Product
                    {
                        ProductID = 14,
                        ProductName = "Physical Graffiti",
                        ProductDescription = "Led Zeppelin's epic double album. Deluxe CD edition with bonus tracks.",
                        ProductPrice = 19.99f,
                        ProductStock = 80,
                        ProductImageLocation = "/images/physical-graffiti.jpg",
                        ProductScore = 4.8f,
                        ProductGenres = new List<string> { "Hard Rock", "Blues Rock" },
                        MusicSuportID = 2,  // CD
                        ArtistID = 6  // Led Zeppelin
                    },
                    new Product
                    {
                        ProductID = 15,
                        ProductName = "Blonde on Blonde",
                        ProductDescription = "Dylan's double album masterpiece. High-quality digital download.",
                        ProductPrice = 13.99f,
                        ProductStock = 200,
                        ProductImageLocation = "/images/blonde.jpg",
                        ProductScore = 4.7f,
                        ProductGenres = new List<string> { "Folk Rock", "Blues" },
                        MusicSuportID = 3,  // Digital Download
                        ArtistID = 7  // Bob Dylan
                    }
                );

                // REVIEWS
                context.Reviews.AddRange(
                    new Review
                    {
                        ReviewID = 1,
                        ReviewContent = "An absolute masterpiece that sounds even better on vinyl. The sound quality is exceptional.",
                        ReviewerName = "VinylEnthusiast",
                        ProductId = 1,
                        ReviewDate = DateTime.Now.AddDays(-30),
                        StarRating = 5
                    },
                    new Review
                    {
                        ReviewID = 2,
                        ReviewContent = "Taylor's Version brings new life to an already amazing album. The vault tracks are incredible!",
                        ReviewerName = "SwiftieForever",
                        ProductId = 3,
                        ReviewDate = DateTime.Now.AddDays(-7),
                        StarRating = 5
                    },
                    new Review
                    {
                        ReviewID = 3,
                        ReviewContent = "The cassette gives it such a warm, nostalgic feel. Bohemian Rhapsody never sounded better.",
                        ReviewerName = "RetroMusic",
                        ProductId = 5,
                        ReviewDate = DateTime.Now.AddDays(-14),
                        StarRating = 4
                    },
                    new Review
                    {
                        ReviewID = 4,
                        ReviewContent = "This remaster of OK Computer is absolutely stunning. The clarity is mind-blowing.",
                        ReviewerName = "RadioheadFan",
                        ProductId = 13,
                        ReviewDate = DateTime.Now.AddDays(-3),
                        StarRating = 5
                    },
                    new Review
                    {
                        ReviewID = 5,
                        ReviewContent = "Led Zeppelin IV on vinyl is a completely different experience. Worth every penny.",
                        ReviewerName = "VinylCollector",
                        ProductId = 11,
                        ReviewDate = DateTime.Now.AddDays(-21),
                        StarRating = 5
                    }
                );

                context.SaveChanges();















                context.SaveChanges();
            }
        }
    }
}
