using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeShop_Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Street", "StreetNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Warszawa", "Złota", "155", "00-324" },
                    { 2, "Warszawa", "Jana Pawła II", "21", "37-001" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bb92c056-90ea-4895-9fce-c67bc8fc5696");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d01c426-cd1a-4fe7-b7a3-c8b99fc8046c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7e7daf93-a462-4a84-b39f-51fdcb348098");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageLong", "LanguageShort" },
                values: new object[,]
                {
                    { (byte)1, "Polski", "PL" },
                    { (byte)2, "English", "EN" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "PriceEUR", "PricePLN", "PriceUSD" },
                values: new object[,]
                {
                    { 1, 339.99m, 1239.49m, 399.00m },
                    { 2, 167.99m, 679.99m, 199.00m },
                    { 3, 14.99m, 69.00m, 19.99m }
                });

            migrationBuilder.InsertData(
                table: "ProductDescriptions",
                columns: new[] { "ProductId", "LanguageId", "Text" },
                values: new object[,]
                {
                    { 1, (byte)1, "Od parków po dzikie ścieżki - ten wszechstronny rower może dodać pikanterii Twoim dojazdom do pracy lub treningom. Dzięki płaskiej kierownicy, wyprostowanej pozycji i amortyzowanemu widelcowi możesz swobodnie jeździć w różnych typach terenu z pewnością i kontrolą." },
                    { 1, (byte)2, "From forest trails to canal paths and everything in between, this versatile bike can add some spice to your commute or fitness routine. With its flat handlebar, upright positioning and suspension fork, it’s cool and capable on-road or off-road." },
                    { 2, (byte)1, "Cariboo Friends doskonale sprawdzi się jako pierwszy rowerek. Jeśli Twoje dziecko postawiło już pierwsze kroki, oznacza to, że jest gotowe, aby rozpocząć naukę na jeździku Cariboo Friends. Rowerek posiada regulowaną kierownice i siodełko, dzięki czemu będzie odpowiedni zarówno dla maluszków, jak i nieco starszych dzieci. Jeździk Friends spełnia wszystkie wymogi rygorystycznej normy bezpieczeństwa EN71 dla produktów przeznaczonych dla najmłodszych." },
                    { 2, (byte)2, "DESIGN FOR KIDS - 1. This 12\" bike comes with stable training wheel early rider. 2.Quick release seat simplify the height adjustment. 3.Saddle with holder to learn riding when the training wheel is off. 4.Foot brake suitable for young rider don't have enough power to manipulate the hand brake." },
                    { 3, (byte)1, "Różnorodne elastyczne tryby oświetlenia, które zaspokoją wszelkie potrzeby podczas podróży: 4 tryby pracy reflektorów: reflektor obraca się o 360 stopni i wykorzystuje 4 technologie ściemniania.Wysoki, średni, wysoki, średni 6 trybów światła tylnego: światło tylne obraca się o 180 stopni i jest 6 trybów oświetlenia. Wysokie, średnie, wysokie i 50 % miganie oraz 100 % miganie i miganie stroboskopowe" },
                    { 3, (byte)2, "ADVANCED DESIGN: USB rechargeable light, built in 650mAh rechargeable lithium battery for each light. FOUR LIGHT MODE OPTIONS: The Headlight and Taillight feature an one - touch switch with four different lighting modes depending on your preference. Include full brightness, half brightness, fast flashing and slow flashing. EASY INSTALLATION: The silicone mount straps are designed with two openings that tightly fit around many size seat posts, handlebars, seat risers, backpacks, helmets and stretch to keep lights secure and firm. They can be easily loosen and fasten, and no tools are required." }
                });

            migrationBuilder.InsertData(
                table: "ProductNames",
                columns: new[] { "ProductId", "LanguageId", "Text" },
                values: new object[,]
                {
                    { 1, (byte)1, "Rower GIANT 26' SPORT" },
                    { 1, (byte)2, "GIANT bike 26 inch SPORT" },
                    { 2, (byte)1, "Rowerek dziecięcy" },
                    { 2, (byte)2, "children's bicycle" },
                    { 3, (byte)1, "Oświetlenie rowerowe LED" },
                    { 3, (byte)2, "LED bicycle lighting" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "AddressId", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { (byte)1, 1, "Sklep i Serwis rowerowy - Złote Tarasy", "shopZloteTarasy.jpg" },
                    { (byte)2, 2, "Giant Bicycles Polska", "shopGiant.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "ShopId", "ProductId", "Amount" },
                values: new object[,]
                {
                    { (byte)1, 1, 3 },
                    { (byte)1, 2, 1 },
                    { (byte)1, 3, 18 },
                    { (byte)2, 1, 9 },
                    { (byte)2, 2, 12 },
                    { (byte)2, 3, 44 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 1, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 1, (byte)2 });

            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 2, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 2, (byte)2 });

            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 3, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductDescriptions",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 3, (byte)2 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 1, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 1, (byte)2 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 2, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 2, (byte)2 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 3, (byte)1 });

            migrationBuilder.DeleteData(
                table: "ProductNames",
                keyColumns: new[] { "ProductId", "LanguageId" },
                keyValues: new object[] { 3, (byte)2 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)1, 1 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)1, 2 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)1, 3 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)2, 1 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)2, 2 });

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumns: new[] { "ShopId", "ProductId" },
                keyValues: new object[] { (byte)2, 3 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "190f6314-5283-4762-9ffd-42c3084adfb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b2d017d3-560b-4d8c-9e6b-67129981b2d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1bf412cc-3b22-4b71-93be-021399ce68b0");
        }
    }
}
