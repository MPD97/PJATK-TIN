﻿// <auto-generated />
using System;
using BikeShop_Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeShop_Infrastructure.Migrations
{
    [DbContext(typeof(BikeShopContext))]
    [Migration("20201025120911_ProductPhoto")]
    partial class ProductPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeShop_Core.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Warszawa",
                            Street = "Złota",
                            StreetNumber = "155",
                            ZipCode = "00-324"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Warszawa",
                            Street = "Jana Pawła II",
                            StreetNumber = "21",
                            ZipCode = "37-001"
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "76df4ead-555b-467c-b15c-86c6288d8a53",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "9a3464e5-bf16-4324-a17d-ae64cdef8e23",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "60266453-47f7-44f1-878c-b8f7357331fa",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Language", b =>
                {
                    b.Property<byte>("LanguageId")
                        .HasColumnType("tinyint");

                    b.Property<string>("LanguageLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LanguageShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = (byte)1,
                            LanguageLong = "Polski",
                            LanguageShort = "PL"
                        },
                        new
                        {
                            LanguageId = (byte)2,
                            LanguageLong = "English",
                            LanguageShort = "EN"
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(260)")
                        .HasMaxLength(260);

                    b.Property<decimal>("PriceEUR")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PricePLN")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PriceUSD")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            PhotoPath = "product1.jpg",
                            PriceEUR = 339.99m,
                            PricePLN = 1239.49m,
                            PriceUSD = 399.00m
                        },
                        new
                        {
                            ProductId = 2,
                            PhotoPath = "product2.jpg",
                            PriceEUR = 167.99m,
                            PricePLN = 679.99m,
                            PriceUSD = 199.00m
                        },
                        new
                        {
                            ProductId = 3,
                            PhotoPath = "product3.jpg",
                            PriceEUR = 14.99m,
                            PricePLN = 69.00m,
                            PriceUSD = 19.99m
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ProductDescriptionTranslation", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("LanguageId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("ProductId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ProductDescriptions");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            LanguageId = (byte)1,
                            Text = "Od parków po dzikie ścieżki - ten wszechstronny rower może dodać pikanterii Twoim dojazdom do pracy lub treningom. Dzięki płaskiej kierownicy, wyprostowanej pozycji i amortyzowanemu widelcowi możesz swobodnie jeździć w różnych typach terenu z pewnością i kontrolą."
                        },
                        new
                        {
                            ProductId = 1,
                            LanguageId = (byte)2,
                            Text = "From forest trails to canal paths and everything in between, this versatile bike can add some spice to your commute or fitness routine. With its flat handlebar, upright positioning and suspension fork, it’s cool and capable on-road or off-road."
                        },
                        new
                        {
                            ProductId = 2,
                            LanguageId = (byte)1,
                            Text = "Cariboo Friends doskonale sprawdzi się jako pierwszy rowerek. Jeśli Twoje dziecko postawiło już pierwsze kroki, oznacza to, że jest gotowe, aby rozpocząć naukę na jeździku Cariboo Friends. Rowerek posiada regulowaną kierownice i siodełko, dzięki czemu będzie odpowiedni zarówno dla maluszków, jak i nieco starszych dzieci. Jeździk Friends spełnia wszystkie wymogi rygorystycznej normy bezpieczeństwa EN71 dla produktów przeznaczonych dla najmłodszych."
                        },
                        new
                        {
                            ProductId = 2,
                            LanguageId = (byte)2,
                            Text = "DESIGN FOR KIDS - 1. This 12\" bike comes with stable training wheel early rider. 2.Quick release seat simplify the height adjustment. 3.Saddle with holder to learn riding when the training wheel is off. 4.Foot brake suitable for young rider don't have enough power to manipulate the hand brake."
                        },
                        new
                        {
                            ProductId = 3,
                            LanguageId = (byte)1,
                            Text = "Różnorodne elastyczne tryby oświetlenia, które zaspokoją wszelkie potrzeby podczas podróży: 4 tryby pracy reflektorów: reflektor obraca się o 360 stopni i wykorzystuje 4 technologie ściemniania.Wysoki, średni, wysoki, średni 6 trybów światła tylnego: światło tylne obraca się o 180 stopni i jest 6 trybów oświetlenia. Wysokie, średnie, wysokie i 50 % miganie oraz 100 % miganie i miganie stroboskopowe"
                        },
                        new
                        {
                            ProductId = 3,
                            LanguageId = (byte)2,
                            Text = "ADVANCED DESIGN: USB rechargeable light, built in 650mAh rechargeable lithium battery for each light. FOUR LIGHT MODE OPTIONS: The Headlight and Taillight feature an one - touch switch with four different lighting modes depending on your preference. Include full brightness, half brightness, fast flashing and slow flashing. EASY INSTALLATION: The silicone mount straps are designed with two openings that tightly fit around many size seat posts, handlebars, seat risers, backpacks, helmets and stretch to keep lights secure and firm. They can be easily loosen and fasten, and no tools are required."
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ProductNameTranslation", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("LanguageId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("ProductId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ProductNames");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            LanguageId = (byte)1,
                            Text = "Rower GIANT 26' SPORT"
                        },
                        new
                        {
                            ProductId = 1,
                            LanguageId = (byte)2,
                            Text = "GIANT bike 26 inch SPORT"
                        },
                        new
                        {
                            ProductId = 2,
                            LanguageId = (byte)1,
                            Text = "Rowerek dziecięcy"
                        },
                        new
                        {
                            ProductId = 2,
                            LanguageId = (byte)2,
                            Text = "children's bicycle"
                        },
                        new
                        {
                            ProductId = 3,
                            LanguageId = (byte)1,
                            Text = "Oświetlenie rowerowe LED"
                        },
                        new
                        {
                            ProductId = 3,
                            LanguageId = (byte)2,
                            Text = "LED bicycle lighting"
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Shop", b =>
                {
                    b.Property<byte>("ShopId")
                        .HasColumnType("tinyint");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(260)")
                        .HasMaxLength(260);

                    b.HasKey("ShopId");

                    b.HasIndex("AddressId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopId = (byte)1,
                            AddressId = 1,
                            Name = "Sklep i Serwis rowerowy - Złote Tarasy",
                            PhotoPath = "shopZloteTarasy.jpg"
                        },
                        new
                        {
                            ShopId = (byte)2,
                            AddressId = 2,
                            Name = "Giant Bicycles Polska",
                            PhotoPath = "shopGiant.jpg"
                        });
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Storage", b =>
                {
                    b.Property<byte>("ShopId")
                        .HasColumnType("tinyint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ShopId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Storages");

                    b.HasData(
                        new
                        {
                            ShopId = (byte)1,
                            ProductId = 1,
                            Amount = 3
                        },
                        new
                        {
                            ShopId = (byte)1,
                            ProductId = 2,
                            Amount = 1
                        },
                        new
                        {
                            ShopId = (byte)1,
                            ProductId = 3,
                            Amount = 18
                        },
                        new
                        {
                            ShopId = (byte)2,
                            ProductId = 1,
                            Amount = 9
                        },
                        new
                        {
                            ShopId = (byte)2,
                            ProductId = 2,
                            Amount = 12
                        },
                        new
                        {
                            ShopId = (byte)2,
                            ProductId = 3,
                            Amount = 44
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ProductDescriptionTranslation", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.Language", "Language")
                        .WithMany("ProductDescriptions")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BikeShop_Core.Entities.Product", "Product")
                        .WithMany("ProductDescriptions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeShop_Core.Entities.ProductNameTranslation", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.Language", "Language")
                        .WithMany("ProductNames")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BikeShop_Core.Entities.Product", "Product")
                        .WithMany("ProductNames")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Shop", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.Address", "Address")
                        .WithMany("Shops")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeShop_Core.Entities.Storage", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.Product", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BikeShop_Core.Entities.Shop", "Shop")
                        .WithMany("Storages")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeShop_Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BikeShop_Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
