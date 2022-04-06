using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Database.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
                    PurchaseUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 3, 5, 25, 4, 0, DateTimeKind.Unspecified), "Category1" },
                    { 20, new DateTime(2017, 6, 9, 1, 21, 15, 0, DateTimeKind.Unspecified), "Category20" },
                    { 19, new DateTime(2017, 6, 8, 1, 20, 15, 0, DateTimeKind.Unspecified), "Category19" },
                    { 18, new DateTime(2017, 6, 9, 1, 19, 15, 0, DateTimeKind.Unspecified), "Category18" },
                    { 17, new DateTime(2017, 6, 8, 1, 18, 15, 0, DateTimeKind.Unspecified), "Category17" },
                    { 15, new DateTime(2017, 6, 8, 1, 16, 15, 0, DateTimeKind.Unspecified), "Category15" },
                    { 14, new DateTime(2017, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category14" },
                    { 13, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category13" },
                    { 12, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category12" },
                    { 11, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category11" },
                    { 16, new DateTime(2017, 6, 9, 1, 17, 15, 0, DateTimeKind.Unspecified), "Category16" },
                    { 9, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category9" },
                    { 8, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category8" },
                    { 7, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category7" },
                    { 6, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category6" },
                    { 5, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category5" },
                    { 4, new DateTime(2019, 5, 6, 2, 2, 2, 0, DateTimeKind.Unspecified), "Category4" },
                    { 3, new DateTime(2020, 4, 6, 3, 17, 25, 0, DateTimeKind.Unspecified), "Category3" },
                    { 2, new DateTime(2021, 4, 4, 6, 15, 14, 0, DateTimeKind.Unspecified), "Category2" },
                    { 10, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category10" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 36, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6479), "Ingredient30", 27m, 3m, 4 },
                    { 35, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6476), "Ingredient29", 26m, 2m, 2 },
                    { 34, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6473), "Ingredient28", 25m, 1m, 2 },
                    { 33, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6470), "Ingredient27", 24m, 1m, 2 },
                    { 28, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6456), "Ingredient22", 10m, 7m, 2 },
                    { 31, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6465), "Ingredient25", 22m, 1m, 2 },
                    { 30, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6462), "Ingredient24", 10m, 9m, 2 },
                    { 29, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6459), "Ingredient23", 10m, 8m, 2 },
                    { 37, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6482), "Ingredient31", 28m, 4m, 4 },
                    { 32, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6467), "Ingredient26", 23m, 1m, 2 },
                    { 38, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6484), "Ingredient32", 10m, 5m, 4 },
                    { 48, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6510), "Ingredient42", 10m, 1m, 4 },
                    { 40, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6489), "Ingredient34", 12m, 7m, 4 },
                    { 41, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6492), "Ingredient35", 13m, 3m, 4 },
                    { 42, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6495), "Ingredient36", 14m, 1m, 2 },
                    { 43, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6497), "Ingredient37", 15m, 3m, 4 },
                    { 44, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6500), "Ingredient38", 16m, 2m, 4 },
                    { 45, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6503), "Ingredient39", 17m, 1m, 4 },
                    { 46, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6505), "Ingredient40", 18m, 1m, 4 },
                    { 47, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6508), "Ingredient41", 10m, 1m, 4 },
                    { 27, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6411), "Ingredient21", 10m, 6m, 2 },
                    { 49, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6513), "Ingredient43", 10m, 1m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 50, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6515), "Ingredient44", 10m, 1m, 4 },
                    { 39, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6487), "Ingredient33", 10m, 6m, 4 },
                    { 26, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6409), "Ingredient20", 10m, 5m, 2 },
                    { 16, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6381), "Ingredient10", 19m, 1m, 2 },
                    { 24, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6404), "Ingredient18", 10m, 3m, 2 },
                    { 1, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(5080), "Oil", 3m, 1m, 4 },
                    { 2, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6328), "Flour", 30m, 25m, 2 },
                    { 3, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6342), "Sugar", 3m, 1m, 2 },
                    { 4, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6345), "Salt", 2m, 1m, 2 },
                    { 5, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6348), "Olive Oil", 20m, 1m, 4 },
                    { 6, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6353), "Egg", 9m, 30m, 0 },
                    { 7, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6356), "Ingredient1", 10m, 1m, 2 },
                    { 8, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6359), "Ingredient2", 11m, 2m, 2 },
                    { 9, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6361), "Ingredient3", 12m, 2m, 2 },
                    { 10, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6365), "Ingredient4", 13m, 2m, 2 },
                    { 11, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6368), "Ingredient5", 14m, 2m, 2 },
                    { 12, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6370), "Ingredient6", 15m, 2m, 2 },
                    { 13, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6373), "Ingredient7", 16m, 2m, 2 },
                    { 14, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6376), "Ingredient8", 17m, 2m, 2 },
                    { 15, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6378), "Ingredient9", 18m, 1m, 2 },
                    { 17, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6383), "Ingredient11", 20m, 1m, 2 },
                    { 18, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6387), "Ingredient12", 10m, 1m, 2 },
                    { 19, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6390), "Ingredient13", 10m, 1m, 2 },
                    { 20, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6393), "Ingredient14", 10m, 1m, 2 },
                    { 21, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6395), "Ingredient15", 10m, 1m, 2 },
                    { 22, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6398), "Ingredient16", 10m, 1m, 2 },
                    { 23, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6401), "Ingredient17", 10m, 2m, 2 },
                    { 25, new DateTime(2022, 4, 6, 21, 27, 25, 568, DateTimeKind.Local).AddTicks(6406), "Ingredient19", 10m, 4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, false, new byte[] { 4, 203, 65, 153, 54, 132, 73, 138, 164, 189, 57, 18, 24, 44, 48, 53, 87, 6, 34, 111, 120, 186, 30, 187, 160, 177, 167, 139, 144, 21, 51, 33, 186, 169, 185, 189, 194, 97, 187, 18, 39, 8, 152, 43, 239, 193, 61, 76, 36, 184, 243, 136, 184, 27, 11, 89, 158, 168, 119, 162, 247, 224, 192, 104 }, new byte[] { 247, 47, 137, 46, 17, 100, 37, 49, 155, 61, 187, 41, 71, 164, 92, 187, 129, 252, 10, 20, 124, 178, 245, 80, 212, 223, 245, 138, 133, 232, 55, 140, 7, 3, 219, 5, 254, 102, 57, 167, 220, 51, 227, 161, 199, 65, 75, 170, 70, 221, 222, 120, 16, 37, 7, 62, 132, 67, 212, 253, 239, 179, 193, 159, 96, 8, 164, 155, 20, 1, 212, 103, 26, 24, 12, 106, 236, 238, 40, 230, 25, 236, 89, 198, 39, 249, 195, 53, 97, 69, 147, 134, 118, 240, 155, 106, 252, 253, 238, 72, 170, 87, 23, 25, 162, 54, 86, 114, 227, 82, 170, 252, 102, 27, 28, 231, 13, 230, 119, 154, 143, 123, 132, 155, 52, 136, 66, 165 }, "user123" },
                    { 2, true, new byte[] { 4, 203, 65, 153, 54, 132, 73, 138, 164, 189, 57, 18, 24, 44, 48, 53, 87, 6, 34, 111, 120, 186, 30, 187, 160, 177, 167, 139, 144, 21, 51, 33, 186, 169, 185, 189, 194, 97, 187, 18, 39, 8, 152, 43, 239, 193, 61, 76, 36, 184, 243, 136, 184, 27, 11, 89, 158, 168, 119, 162, 247, 224, 192, 104 }, new byte[] { 247, 47, 137, 46, 17, 100, 37, 49, 155, 61, 187, 41, 71, 164, 92, 187, 129, 252, 10, 20, 124, 178, 245, 80, 212, 223, 245, 138, 133, 232, 55, 140, 7, 3, 219, 5, 254, 102, 57, 167, 220, 51, 227, 161, 199, 65, 75, 170, 70, 221, 222, 120, 16, 37, 7, 62, 132, 67, 212, 253, 239, 179, 193, 159, 96, 8, 164, 155, 20, 1, 212, 103, 26, 24, 12, 106, 236, 238, 40, 230, 25, 236, 89, 198, 39, 249, 195, 53, 97, 69, 147, 134, 118, 240, 155, 106, 252, 253, 238, 72, 170, 87, 23, 25, 162, 54, 86, 114, 227, 82, 170, 252, 102, 27, 28, 231, 13, 230, 119, 154, 143, 123, 132, 155, 52, 136, 66, 165 }, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 17, 1, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2410), "Description of a recipe whos id is $17", "Naziv recepta 17" },
                    { 10, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2227), "Description of a recipe whos id is $10", "Naziv recepta 10" },
                    { 22, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2569), "Description of a recipe whos id is $22", "Naziv recepta 22" },
                    { 23, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2595), "Description of a recipe whos id is $23", "Naziv recepta 23" },
                    { 24, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2620), "Description of a recipe whos id is $24", "Naziv recepta 24" },
                    { 31, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2798), "Description of a recipe whos id is $31", "Naziv recepta 31" },
                    { 33, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2849), "Description of a recipe whos id is $33", "Naziv recepta 33" },
                    { 45, 10, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3182), "Description of a recipe whos id is $45", "Naziv recepta 45" },
                    { 13, 11, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2305), "Description of a recipe whos id is $13", "Naziv recepta 13" },
                    { 15, 11, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2358), "Description of a recipe whos id is $15", "Naziv recepta 15" },
                    { 20, 11, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2517), "Description of a recipe whos id is $20", "Naziv recepta 20" },
                    { 28, 11, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2721), "Description of a recipe whos id is $28", "Naziv recepta 28" },
                    { 36, 12, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2956), "Description of a recipe whos id is $36", "Naziv recepta 36" },
                    { 9, 13, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2199), "Description of a recipe whos id is $9", "Naziv recepta 9" },
                    { 40, 14, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3055), "Description of a recipe whos id is $40", "Naziv recepta 40" },
                    { 49, 14, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3312), "Description of a recipe whos id is $49", "Naziv recepta 49" },
                    { 12, 16, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2280), "Description of a recipe whos id is $12", "Naziv recepta 12" },
                    { 27, 16, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2695), "Description of a recipe whos id is $27", "Naziv recepta 27" },
                    { 6, 17, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2122), "Description of a recipe whos id is $6", "Naziv recepta 6" },
                    { 19, 17, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2461), "Description of a recipe whos id is $19", "Naziv recepta 19" },
                    { 26, 17, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2670), "Description of a recipe whos id is $26", "Naziv recepta 26" },
                    { 1, 18, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(1902), "Description of a recipe whos id is $1", "Naziv recepta 1" },
                    { 48, 9, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3287), "Description of a recipe whos id is $48", "Naziv recepta 48" },
                    { 3, 19, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(1993), "Description of a recipe whos id is $3", "Naziv recepta 3" },
                    { 11, 9, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2253), "Description of a recipe whos id is $11", "Naziv recepta 11" },
                    { 30, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2772), "Description of a recipe whos id is $30", "Naziv recepta 30" },
                    { 37, 1, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2981), "Description of a recipe whos id is $37", "Naziv recepta 37" },
                    { 4, 2, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2020), "Description of a recipe whos id is $4", "Naziv recepta 4" },
                    { 39, 2, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3030), "Description of a recipe whos id is $39", "Naziv recepta 39" },
                    { 2, 3, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(1966), "Description of a recipe whos id is $2", "Naziv recepta 2" },
                    { 32, 3, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2824), "Description of a recipe whos id is $32", "Naziv recepta 32" },
                    { 44, 3, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3156), "Description of a recipe whos id is $44", "Naziv recepta 44" },
                    { 34, 4, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2906), "Description of a recipe whos id is $34", "Naziv recepta 34" },
                    { 46, 4, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3206), "Description of a recipe whos id is $46", "Naziv recepta 46" },
                    { 47, 4, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3231), "Description of a recipe whos id is $47", "Naziv recepta 47" },
                    { 16, 5, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2383), "Description of a recipe whos id is $16", "Naziv recepta 16" },
                    { 21, 5, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2543), "Description of a recipe whos id is $21", "Naziv recepta 21" },
                    { 43, 5, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3130), "Description of a recipe whos id is $43", "Naziv recepta 43" },
                    { 8, 6, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2173), "Description of a recipe whos id is $8", "Naziv recepta 8" },
                    { 38, 6, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3005), "Description of a recipe whos id is $38", "Naziv recepta 38" },
                    { 41, 7, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3080), "Description of a recipe whos id is $41", "Naziv recepta 41" },
                    { 42, 7, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(3104), "Description of a recipe whos id is $42", "Naziv recepta 42" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 5, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2046), "Description of a recipe whos id is $5", "Naziv recepta 5" },
                    { 7, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2148), "Description of a recipe whos id is $7", "Naziv recepta 7" },
                    { 14, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2332), "Description of a recipe whos id is $14", "Naziv recepta 14" },
                    { 25, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2646), "Description of a recipe whos id is $25", "Naziv recepta 25" },
                    { 29, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2746), "Description of a recipe whos id is $29", "Naziv recepta 29" },
                    { 35, 8, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2932), "Description of a recipe whos id is $35", "Naziv recepta 35" },
                    { 18, 19, new DateTime(2022, 4, 6, 21, 27, 25, 570, DateTimeKind.Local).AddTicks(2435), "Description of a recipe whos id is $18", "Naziv recepta 18" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 31, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 1, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 37, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 140m, 1 },
                    { 31, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 380m, 1 },
                    { 5, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 12, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 38, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 330m, 3 },
                    { 11, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 9, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 498m, 1 },
                    { 23, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167m, 1 },
                    { 7, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108m, 1 },
                    { 39, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108m, 1 },
                    { 5, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 264m, 1 },
                    { 40, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 21, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 423m, 3 },
                    { 41, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 156m, 1 },
                    { 27, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 264m, 1 },
                    { 33, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 39, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77m, 3 },
                    { 3, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 11, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 487m, 3 },
                    { 3, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 406m, 3 },
                    { 30, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 1, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 21, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 279m, 3 },
                    { 7, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 38, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 43, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 4, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 45, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 42, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78m, 1 },
                    { 34, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 24, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 418m, 3 },
                    { 23, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 22, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 425m, 3 },
                    { 38, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 29, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 13, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 441m, 1 },
                    { 28, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 248m, 1 },
                    { 43, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 451m, 1 },
                    { 22, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 47, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 187m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 27, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 20, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 1 },
                    { 33, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 219m, 1 },
                    { 25, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 357m, 1 },
                    { 5, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 13, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 30, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73m, 3 },
                    { 49, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 39, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 10, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 3 },
                    { 47, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81m, 1 },
                    { 10, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 407m, 1 },
                    { 40, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 309m, 1 },
                    { 34, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 47, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 41, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 19, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 301m, 1 },
                    { 23, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 154m, 1 },
                    { 2, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 5, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94m, 3 },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 29, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 16, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 43, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 12, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 1, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 14, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104m, 1 },
                    { 28, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 232m, 3 },
                    { 23, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 43, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 457m, 1 },
                    { 44, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 483m, 3 },
                    { 18, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 46, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 29, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 39, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 237m, 1 },
                    { 4, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 453m, 1 },
                    { 28, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 27, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 12, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 401m, 1 },
                    { 32, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 320m, 1 },
                    { 35, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 6, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 28, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 18, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 22, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98m, 3 },
                    { 27, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 127m, 3 },
                    { 21, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 13, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 279m, 1 },
                    { 23, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 3, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 30, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 272m, 3 },
                    { 29, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 3 },
                    { 31, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 11, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 26, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 4, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 27, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 38, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 378m, 1 },
                    { 13, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 19, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 312m, 1 },
                    { 20, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 320m, 3 },
                    { 6, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 143m, 3 },
                    { 47, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 34, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 147m, 1 },
                    { 28, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 312m, 1 },
                    { 6, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167m, 3 },
                    { 13, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 156m, 3 },
                    { 41, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 368m, 1 },
                    { 35, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 35, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 19, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 1 },
                    { 31, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 16, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 354m, 3 },
                    { 48, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 24, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 469m, 3 },
                    { 44, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 353m, 1 },
                    { 28, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 37, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 46, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94m, 3 },
                    { 9, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102m, 3 },
                    { 23, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 134m, 1 },
                    { 16, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57m, 3 },
                    { 33, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 36, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 428m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 31, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 1, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 33, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 6, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 16, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182m, 3 },
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185m, 1 },
                    { 20, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 39, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 36, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 11, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165m, 1 },
                    { 1, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 10, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 14, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 36, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 249m, 3 },
                    { 35, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 2, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 17, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 358m, 3 },
                    { 30, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 4, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 18, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 32, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165m, 3 },
                    { 47, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 352m, 3 },
                    { 29, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 34, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 12, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 450m, 1 },
                    { 44, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 26, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 30, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 21, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 8, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212m, 1 },
                    { 29, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 1, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 37, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198m, 3 },
                    { 16, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105m, 3 },
                    { 22, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 28, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195m, 1 },
                    { 4, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 24, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 5, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 41, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 157m, 3 },
                    { 42, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 221m, 1 },
                    { 28, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 304m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 38, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 349m, 3 },
                    { 47, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 13, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 42, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151m, 3 },
                    { 10, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 329m, 1 },
                    { 31, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 39, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 26, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 34, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 42, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 221m, 1 },
                    { 5, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 416m, 1 },
                    { 39, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 236m, 3 },
                    { 18, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 381m, 3 },
                    { 15, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 346m, 3 },
                    { 33, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 22, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 43, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 155m, 1 },
                    { 11, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 237m, 1 },
                    { 45, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 390m, 1 },
                    { 41, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, 3 },
                    { 18, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 297m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
