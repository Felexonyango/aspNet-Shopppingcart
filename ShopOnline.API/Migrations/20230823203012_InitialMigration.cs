using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFitType",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FitTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFitType", x => new { x.FitTypeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductFitType_FitTypes_FitTypeId",
                        column: x => x.FitTypeId,
                        principalTable: "FitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFitType_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => new { x.ProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductSize_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SHIRT" },
                    { 2, "BASIC" },
                    { 3, "SHIRT" },
                    { 4, "PRTINED" }
                });

            migrationBuilder.InsertData(
                table: "FitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "REGULAR" },
                    { 2, "OVERSIZE" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Wooden Soap", 806.46m, 924 },
                    { 2, "The Football Is Good For Training And Recreational Purposes", "Sleek Plastic Bike", 302.67m, 935 },
                    { 3, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Practical Rubber Shoes", 453.74m, 366 },
                    { 4, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Practical Soft Bacon", 207.08m, 618 },
                    { 5, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Sleek Cotton Computer", 885.47m, 825 },
                    { 6, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Small Plastic Sausages", 802.04m, 578 },
                    { 7, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Handmade Frozen Gloves", 181.85m, 986 },
                    { 8, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Tasty Concrete Bacon", 228.56m, 108 },
                    { 9, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Fresh Fish", 91.49m, 583 },
                    { 10, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Wooden Bacon", 244.89m, 222 },
                    { 11, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Practical Concrete Fish", 683.86m, 270 },
                    { 12, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Granite Fish", 179.55m, 164 },
                    { 13, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Refined Frozen Computer", 155.03m, 353 },
                    { 14, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Small Metal Ball", 836.89m, 111 },
                    { 15, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Unbranded Fresh Computer", 185.18m, 773 },
                    { 16, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Ergonomic Cotton Ball", 528.98m, 102 },
                    { 17, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Small Soft Chips", 847.43m, 571 },
                    { 18, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handcrafted Wooden Towels", 248.39m, 852 },
                    { 19, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Generic Cotton Chicken", 22.10m, 642 },
                    { 20, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Unbranded Steel Computer", 240.18m, 795 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" },
                    { 5, "XXL" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 10 },
                    { 1, 14 },
                    { 1, 18 },
                    { 2, 8 },
                    { 2, 16 },
                    { 2, 20 },
                    { 3, 5 },
                    { 3, 7 },
                    { 3, 9 },
                    { 3, 12 },
                    { 3, 15 },
                    { 3, 17 },
                    { 3, 19 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 6 },
                    { 4, 11 },
                    { 4, 13 }
                });

            migrationBuilder.InsertData(
                table: "ProductFitType",
                columns: new[] { "FitTypeId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductFitType",
                columns: new[] { "FitTypeId", "ProductId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=245127432", 1 },
                    { 2, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1994112749", 1 },
                    { 3, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1864630175", 2 },
                    { 4, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=68483515", 2 },
                    { 5, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=916806864", 3 },
                    { 6, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1034402201", 3 },
                    { 7, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=937019594", 4 },
                    { 8, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1276857974", 4 },
                    { 9, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=45806295", 5 },
                    { 10, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1793794736", 5 },
                    { 11, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1656729413", 6 },
                    { 12, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1397638177", 6 },
                    { 13, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=773749946", 7 },
                    { 14, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1853340836", 7 },
                    { 15, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=616022113", 8 },
                    { 16, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=319183836", 8 },
                    { 17, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=492937981", 9 },
                    { 18, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1262833996", 9 },
                    { 19, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1473042211", 10 },
                    { 20, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=159138249", 10 },
                    { 21, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1764146059", 11 },
                    { 22, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=719942953", 11 },
                    { 23, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1985767269", 12 },
                    { 24, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1032724115", 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 25, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=40648883", 13 },
                    { 26, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=720860175", 13 },
                    { 27, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=756843148", 14 },
                    { 28, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1646216841", 14 },
                    { 29, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=430630770", 15 },
                    { 30, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=21442986", 15 },
                    { 31, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=691062187", 16 },
                    { 32, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1254482939", 16 },
                    { 33, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=391426044", 17 },
                    { 34, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=714086503", 17 },
                    { 35, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1507088009", 18 },
                    { 36, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=329448207", 18 },
                    { 37, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1683503775", 19 },
                    { 38, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1698244492", 19 },
                    { 39, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=1694065347", 20 },
                    { 40, "https://loremflickr.com/640/480/clothes,fashion,model,shirt/any?lock=615290498", 20 }
                });

            migrationBuilder.InsertData(
                table: "ProductSize",
                columns: new[] { "ProductId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 9, 1 },
                    { 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductSize",
                columns: new[] { "ProductId", "SizeId" },
                values: new object[,]
                {
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 3 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 20, 1 },
                    { 20, 2 },
                    { 20, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFitType_ProductId",
                table: "ProductFitType",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AppUserId",
                table: "UserAddresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CityId",
                table: "UserAddresses",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductFitType");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FitTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
