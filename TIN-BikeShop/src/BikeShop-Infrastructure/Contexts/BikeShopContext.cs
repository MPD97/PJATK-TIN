using BikeShop_Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Contexts
{
    public class BikeShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescriptionTranslation> ProductDescriptions { get; set; }
        public DbSet<ProductNameTranslation> ProductNames { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Storage> Storages { get; set; }

        public BikeShopContext(DbContextOptions<BikeShopContext> options) : base(options)
        {
        }

        protected BikeShopContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            Language pl = new Language
            {
                LanguageId = 1,
                LanguageLong = "Polski",
                LanguageShort = "PL",
            };
            Language en = new Language
            {
                LanguageId = 2,
                LanguageLong = "English",
                LanguageShort = "EN",
            };




            Product product1 = new Product
            {
                ProductId = 1,
                PricePLN = 1239.49M,
                PriceEUR = 339.99M,
                PriceUSD = 399.00M,
                PhotoPath = "product1.jpg"
            };
            Product product2 = new Product
            {
                ProductId = 2,
                PricePLN = 679.99M,
                PriceEUR = 167.99M,
                PriceUSD = 199.00M,
                PhotoPath = "product2.jpg"

            };
            Product product3 = new Product
            {
                ProductId = 3,
                PricePLN = 69.00M,
                PriceEUR = 14.99M,
                PriceUSD = 19.99M,
                PhotoPath = "product3.jpg"

            };


            ProductNameTranslation nameTranslation1 = new ProductNameTranslation
            {
                LanguageId = 1,
                Text = "Rower GIANT 26' SPORT",
                ProductId = 1,
            };
            ProductNameTranslation nameTranslation2 = new ProductNameTranslation
            {
                LanguageId = 2,
                Text = "GIANT bike 26 inch SPORT",
                ProductId = 1,
            };
            ProductDescriptionTranslation productDescription1 = new ProductDescriptionTranslation
            {
                LanguageId = 1,
                Text = "Od parków po dzikie ścieżki - ten wszechstronny rower może dodać pikanterii Twoim dojazdom do pracy lub treningom. Dzięki płaskiej kierownicy, wyprostowanej pozycji i amortyzowanemu widelcowi możesz swobodnie jeździć w różnych typach terenu z pewnością i kontrolą.",
                ProductId = 1,
            };
            ProductDescriptionTranslation productDescription2 = new ProductDescriptionTranslation
            {
                LanguageId = 2,
                Text = "From forest trails to canal paths and everything in between, this versatile bike can add some spice to your commute or fitness routine. With its flat handlebar, upright positioning and suspension fork, it’s cool and capable on-road or off-road.",
                ProductId = 1,
            };


            ProductNameTranslation nameTranslation3 = new ProductNameTranslation
            {
                LanguageId = 1,
                Text = "Rowerek dziecięcy",
                ProductId = 2,
            };
            ProductNameTranslation nameTranslation4 = new ProductNameTranslation
            {
                LanguageId = 2,
                Text = "children's bicycle",
                ProductId = 2,
            };
            ProductDescriptionTranslation productDescription3 = new ProductDescriptionTranslation
            {
                LanguageId = 1,
                Text = "Cariboo Friends doskonale sprawdzi się jako pierwszy rowerek. Jeśli Twoje dziecko postawiło już pierwsze kroki, oznacza to, że jest gotowe, aby rozpocząć naukę na jeździku Cariboo Friends. Rowerek posiada regulowaną kierownice i siodełko, dzięki czemu będzie odpowiedni zarówno dla maluszków, jak i nieco starszych dzieci. Jeździk Friends spełnia wszystkie wymogi rygorystycznej normy bezpieczeństwa EN71 dla produktów przeznaczonych dla najmłodszych.",
                ProductId = 2,
            };
            ProductDescriptionTranslation productDescription4 = new ProductDescriptionTranslation
            {
                LanguageId = 2,
                Text = "DESIGN FOR KIDS - 1. This 12\" bike comes with stable training wheel early rider. 2.Quick release seat simplify the height adjustment. 3.Saddle with holder to learn riding when the training wheel is off. 4.Foot brake suitable for young rider don't have enough power to manipulate the hand brake.",
                ProductId = 2,
            };


            ProductNameTranslation nameTranslation5 = new ProductNameTranslation
            {
                LanguageId = 1,
                Text = "Oświetlenie rowerowe LED",
                ProductId = 3,
            };
            ProductNameTranslation nameTranslation6 = new ProductNameTranslation
            {
                LanguageId = 2,
                Text = "LED bicycle lighting",
                ProductId = 3,
            };
            ProductDescriptionTranslation productDescription5 = new ProductDescriptionTranslation
            {
                LanguageId = 1,
                Text = "Różnorodne elastyczne tryby oświetlenia, które zaspokoją wszelkie potrzeby podczas podróży: 4 tryby pracy reflektorów: reflektor obraca się o 360 stopni i wykorzystuje 4 technologie ściemniania.Wysoki, średni, wysoki, średni 6 trybów światła tylnego: światło tylne obraca się o 180 stopni i jest 6 trybów oświetlenia. Wysokie, średnie, wysokie i 50 % miganie oraz 100 % miganie i miganie stroboskopowe",
                ProductId = 3,
            };
            ProductDescriptionTranslation productDescription6 = new ProductDescriptionTranslation
            {
                LanguageId = 2,
                Text = "ADVANCED DESIGN: USB rechargeable light, built in 650mAh rechargeable lithium battery for each light. FOUR LIGHT MODE OPTIONS: The Headlight and Taillight feature an one - touch switch with four different lighting modes depending on your preference. Include full brightness, half brightness, fast flashing and slow flashing. EASY INSTALLATION: The silicone mount straps are designed with two openings that tightly fit around many size seat posts, handlebars, seat risers, backpacks, helmets and stretch to keep lights secure and firm. They can be easily loosen and fasten, and no tools are required.",
                ProductId = 3,
            };

            Address address1 = new Address
            {
                AddressId = 1,
                City = "Warszawa",
                Street = "Złota",
                StreetNumber = "155",
                ZipCode = "00-324"
            };
            Address address2 = new Address
            {
                AddressId = 2,
                City = "Warszawa",
                Street = "Jana Pawła II",
                StreetNumber = "21",
                ZipCode = "37-001"
            };


            Shop shop1 = new Shop
            {
                ShopId = 1,
                Name = "Sklep i Serwis rowerowy - Złote Tarasy",
                PhotoPath = "shopZloteTarasy.jpg",
                AddressId = 1,
            };
            Shop shop2 = new Shop
            {
                ShopId = 2,
                Name = "Giant Bicycles Polska",
                PhotoPath = "shopGiant.jpg",
                AddressId = 2,
            };

            Storage storage1 = new Storage
            {
                ShopId = 1,
                ProductId = 1,
                Amount = 3
            };
            Storage storage2 = new Storage
            {
                ShopId = 1,
                ProductId = 2,
                Amount = 1
            };
            Storage storage3 = new Storage
            {
                ShopId = 1,
                ProductId = 3,
                Amount = 18
            };

            Storage storage4 = new Storage
            {
                ShopId = 2,
                ProductId = 1,
                Amount = 9
            };
            Storage storage5 = new Storage
            {
                ShopId = 2,
                ProductId = 2,
                Amount = 12
            };
            Storage storage6 = new Storage
            {
                ShopId = 2,
                ProductId = 3,
                Amount = 44
            };

            builder.Entity<Language>().HasData(new Language[] { pl, en });
            builder.Entity<Product>().HasData(new Product[] { product1, product2, product3 });
            builder.Entity<ProductDescriptionTranslation>().HasData(new ProductDescriptionTranslation[] { productDescription1, productDescription2, productDescription3, productDescription4, productDescription5, productDescription6 });
            builder.Entity<ProductNameTranslation>().HasData(new ProductNameTranslation[] { nameTranslation1, nameTranslation2, nameTranslation3, nameTranslation4, nameTranslation5, nameTranslation6 });
            builder.Entity<Address>().HasData(new Address[] { address1, address2 });
            builder.Entity<Shop>().HasData(new Shop[] { shop1, shop2 });
            builder.Entity<Storage>().HasData(new Storage[] { storage1, storage2, storage3, storage4, storage5, storage6 });
        }
    }

}
