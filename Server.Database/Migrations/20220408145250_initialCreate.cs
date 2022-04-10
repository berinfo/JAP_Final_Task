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
                    RecommSellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { 36, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1379), "Ingredient30", 27m, 3m, 4 },
                    { 35, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1377), "Ingredient29", 26m, 2m, 2 },
                    { 34, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1374), "Ingredient28", 25m, 1m, 2 },
                    { 33, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1370), "Ingredient27", 24m, 1m, 2 },
                    { 28, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1313), "Ingredient22", 10m, 7m, 2 },
                    { 31, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1320), "Ingredient25", 22m, 1m, 2 },
                    { 30, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1318), "Ingredient24", 10m, 9m, 2 },
                    { 29, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1316), "Ingredient23", 10m, 8m, 2 },
                    { 37, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1382), "Ingredient31", 28m, 4m, 4 },
                    { 32, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1367), "Ingredient26", 23m, 1m, 2 },
                    { 38, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1384), "Ingredient32", 10m, 5m, 4 },
                    { 48, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1409), "Ingredient42", 10m, 1m, 4 },
                    { 40, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1389), "Ingredient34", 12m, 7m, 4 },
                    { 41, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1392), "Ingredient35", 13m, 3m, 4 },
                    { 42, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1394), "Ingredient36", 14m, 1m, 2 },
                    { 43, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1397), "Ingredient37", 15m, 3m, 4 },
                    { 44, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1399), "Ingredient38", 16m, 2m, 4 },
                    { 45, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1402), "Ingredient39", 17m, 1m, 4 },
                    { 46, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1404), "Ingredient40", 18m, 1m, 4 },
                    { 47, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1407), "Ingredient41", 10m, 1m, 4 },
                    { 27, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1311), "Ingredient21", 10m, 6m, 2 },
                    { 49, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1411), "Ingredient43", 10m, 1m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 50, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1414), "Ingredient44", 10m, 1m, 4 },
                    { 39, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1387), "Ingredient33", 10m, 6m, 4 },
                    { 26, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1308), "Ingredient20", 10m, 5m, 2 },
                    { 16, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1282), "Ingredient10", 19m, 1m, 2 },
                    { 24, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1303), "Ingredient18", 10m, 3m, 2 },
                    { 1, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(106), "Oil", 3m, 1m, 4 },
                    { 2, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1230), "Flour", 30m, 25m, 2 },
                    { 3, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1245), "Sugar", 3m, 1m, 2 },
                    { 4, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1248), "Salt", 2m, 1m, 2 },
                    { 5, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1251), "Olive Oil", 20m, 1m, 4 },
                    { 6, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1256), "Egg", 9m, 30m, 0 },
                    { 7, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1259), "Ingredient1", 10m, 1m, 2 },
                    { 8, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1261), "Ingredient2", 11m, 2m, 2 },
                    { 9, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1264), "Ingredient3", 12m, 2m, 2 },
                    { 10, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1267), "Ingredient4", 13m, 2m, 2 },
                    { 11, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1269), "Ingredient5", 14m, 2m, 2 },
                    { 12, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1272), "Ingredient6", 15m, 2m, 2 },
                    { 13, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1274), "Ingredient7", 16m, 2m, 2 },
                    { 14, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1277), "Ingredient8", 17m, 2m, 2 },
                    { 15, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1280), "Ingredient9", 18m, 1m, 2 },
                    { 17, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1285), "Ingredient11", 20m, 1m, 2 },
                    { 18, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1288), "Ingredient12", 10m, 1m, 2 },
                    { 19, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1291), "Ingredient13", 10m, 1m, 2 },
                    { 20, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1293), "Ingredient14", 10m, 1m, 2 },
                    { 21, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1296), "Ingredient15", 10m, 1m, 2 },
                    { 22, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1298), "Ingredient16", 10m, 1m, 2 },
                    { 23, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1301), "Ingredient17", 10m, 2m, 2 },
                    { 25, new DateTime(2022, 4, 8, 16, 52, 49, 694, DateTimeKind.Local).AddTicks(1306), "Ingredient19", 10m, 4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, false, new byte[] { 231, 199, 207, 98, 192, 49, 239, 10, 7, 28, 221, 218, 161, 68, 156, 46, 122, 179, 1, 132, 163, 48, 151, 199, 168, 217, 238, 131, 104, 176, 79, 97, 164, 154, 220, 87, 45, 69, 55, 166, 142, 220, 11, 161, 50, 149, 252, 191, 170, 11, 250, 39, 210, 71, 160, 247, 97, 201, 194, 81, 219, 48, 176, 140 }, new byte[] { 133, 41, 169, 57, 100, 145, 101, 29, 63, 57, 42, 6, 220, 237, 40, 72, 133, 237, 141, 96, 160, 161, 141, 115, 5, 94, 194, 12, 166, 12, 96, 174, 252, 236, 36, 9, 203, 50, 223, 109, 252, 231, 247, 195, 193, 248, 189, 234, 53, 150, 82, 14, 252, 222, 36, 135, 194, 184, 129, 34, 181, 13, 49, 24, 112, 121, 172, 177, 156, 64, 57, 25, 77, 9, 115, 161, 80, 220, 174, 87, 128, 227, 215, 223, 103, 81, 95, 76, 64, 191, 126, 61, 68, 99, 250, 227, 97, 158, 251, 80, 196, 100, 206, 135, 201, 215, 198, 8, 169, 205, 186, 198, 218, 209, 174, 196, 139, 45, 169, 96, 5, 215, 134, 226, 132, 22, 43, 127 }, "user123" },
                    { 2, true, new byte[] { 231, 199, 207, 98, 192, 49, 239, 10, 7, 28, 221, 218, 161, 68, 156, 46, 122, 179, 1, 132, 163, 48, 151, 199, 168, 217, 238, 131, 104, 176, 79, 97, 164, 154, 220, 87, 45, 69, 55, 166, 142, 220, 11, 161, 50, 149, 252, 191, 170, 11, 250, 39, 210, 71, 160, 247, 97, 201, 194, 81, 219, 48, 176, 140 }, new byte[] { 133, 41, 169, 57, 100, 145, 101, 29, 63, 57, 42, 6, 220, 237, 40, 72, 133, 237, 141, 96, 160, 161, 141, 115, 5, 94, 194, 12, 166, 12, 96, 174, 252, 236, 36, 9, 203, 50, 223, 109, 252, 231, 247, 195, 193, 248, 189, 234, 53, 150, 82, 14, 252, 222, 36, 135, 194, 184, 129, 34, 181, 13, 49, 24, 112, 121, 172, 177, 156, 64, 57, 25, 77, 9, 115, 161, 80, 220, 174, 87, 128, 227, 215, 223, 103, 81, 95, 76, 64, 191, 126, 61, 68, 99, 250, 227, 97, 158, 251, 80, 196, 100, 206, 135, 201, 215, 198, 8, 169, 205, 186, 198, 218, 209, 174, 196, 139, 45, 169, 96, 5, 215, 134, 226, 132, 22, 43, 127 }, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "RecommSellingPrice" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6023), "Description of a recipe whos id is $6", "Naziv recepta 6", 0m },
                    { 46, 12, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7089), "Description of a recipe whos id is $46", "Naziv recepta 46", 0m },
                    { 49, 12, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7195), "Description of a recipe whos id is $49", "Naziv recepta 49", 0m },
                    { 4, 13, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(5972), "Description of a recipe whos id is $4", "Naziv recepta 4", 0m },
                    { 21, 13, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6466), "Description of a recipe whos id is $21", "Naziv recepta 21", 0m },
                    { 20, 14, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6411), "Description of a recipe whos id is $20", "Naziv recepta 20", 0m },
                    { 28, 14, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6632), "Description of a recipe whos id is $28", "Naziv recepta 28", 0m },
                    { 2, 15, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(5922), "Description of a recipe whos id is $2", "Naziv recepta 2", 0m },
                    { 5, 15, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(5997), "Description of a recipe whos id is $5", "Naziv recepta 5", 0m },
                    { 14, 15, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6267), "Description of a recipe whos id is $14", "Naziv recepta 14", 0m },
                    { 36, 15, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6852), "Description of a recipe whos id is $36", "Naziv recepta 36", 0m },
                    { 26, 16, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6584), "Description of a recipe whos id is $26", "Naziv recepta 26", 0m },
                    { 42, 16, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6993), "Description of a recipe whos id is $42", "Naziv recepta 42", 0m },
                    { 1, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(5862), "Description of a recipe whos id is $1", "Naziv recepta 1", 0m },
                    { 3, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(5947), "Description of a recipe whos id is $3", "Naziv recepta 3", 0m },
                    { 10, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6167), "Description of a recipe whos id is $10", "Naziv recepta 10", 0m },
                    { 15, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6291), "Description of a recipe whos id is $15", "Naziv recepta 15", 0m },
                    { 31, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6701), "Description of a recipe whos id is $31", "Naziv recepta 31", 0m },
                    { 47, 17, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7112), "Description of a recipe whos id is $47", "Naziv recepta 47", 0m },
                    { 7, 18, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6091), "Description of a recipe whos id is $7", "Naziv recepta 7", 0m },
                    { 13, 18, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6243), "Description of a recipe whos id is $13", "Naziv recepta 13", 0m },
                    { 33, 18, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6750), "Description of a recipe whos id is $33", "Naziv recepta 33", 0m },
                    { 43, 11, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7017), "Description of a recipe whos id is $43", "Naziv recepta 43", 0m },
                    { 44, 18, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7041), "Description of a recipe whos id is $44", "Naziv recepta 44", 0m },
                    { 11, 11, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6193), "Description of a recipe whos id is $11", "Naziv recepta 11", 0m },
                    { 32, 10, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6726), "Description of a recipe whos id is $32", "Naziv recepta 32", 0m },
                    { 9, 1, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6141), "Description of a recipe whos id is $9", "Naziv recepta 9", 0m },
                    { 16, 1, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6314), "Description of a recipe whos id is $16", "Naziv recepta 16", 0m },
                    { 24, 1, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6537), "Description of a recipe whos id is $24", "Naziv recepta 24", 0m },
                    { 29, 3, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6655), "Description of a recipe whos id is $29", "Naziv recepta 29", 0m },
                    { 8, 4, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6117), "Description of a recipe whos id is $8", "Naziv recepta 8", 0m },
                    { 40, 4, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6947), "Description of a recipe whos id is $40", "Naziv recepta 40", 0m },
                    { 27, 5, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6607), "Description of a recipe whos id is $27", "Naziv recepta 27", 0m },
                    { 35, 5, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6828), "Description of a recipe whos id is $35", "Naziv recepta 35", 0m },
                    { 41, 5, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6970), "Description of a recipe whos id is $41", "Naziv recepta 41", 0m },
                    { 18, 6, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6363), "Description of a recipe whos id is $18", "Naziv recepta 18", 0m },
                    { 22, 6, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6489), "Description of a recipe whos id is $22", "Naziv recepta 22", 0m },
                    { 19, 7, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6387), "Description of a recipe whos id is $19", "Naziv recepta 19", 0m },
                    { 25, 7, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6559), "Description of a recipe whos id is $25", "Naziv recepta 25", 0m },
                    { 30, 7, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6679), "Description of a recipe whos id is $30", "Naziv recepta 30", 0m },
                    { 48, 7, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7170), "Description of a recipe whos id is $48", "Naziv recepta 48", 0m },
                    { 45, 8, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(7066), "Description of a recipe whos id is $45", "Naziv recepta 45", 0m }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "RecommSellingPrice" },
                values: new object[,]
                {
                    { 12, 9, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6218), "Description of a recipe whos id is $12", "Naziv recepta 12", 0m },
                    { 17, 9, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6338), "Description of a recipe whos id is $17", "Naziv recepta 17", 0m },
                    { 34, 9, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6805), "Description of a recipe whos id is $34", "Naziv recepta 34", 0m },
                    { 38, 9, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6899), "Description of a recipe whos id is $38", "Naziv recepta 38", 0m },
                    { 23, 10, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6513), "Description of a recipe whos id is $23", "Naziv recepta 23", 0m },
                    { 37, 10, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6876), "Description of a recipe whos id is $37", "Naziv recepta 37", 0m },
                    { 39, 19, new DateTime(2022, 4, 8, 16, 52, 49, 695, DateTimeKind.Local).AddTicks(6924), "Description of a recipe whos id is $39", "Naziv recepta 39", 0m }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 30, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 217m, 1 },
                    { 39, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 407m, 3 },
                    { 44, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 218m, 1 },
                    { 25, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 37, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 19, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169m, 3 },
                    { 22, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 46, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 428m, 1 },
                    { 39, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 191m, 1 },
                    { 25, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 20, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 27, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 26, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128m, 1 },
                    { 22, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 429m, 3 },
                    { 18, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 403m, 3 },
                    { 27, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 23, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 30, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 302m, 3 },
                    { 34, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198m, 1 },
                    { 33, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 21, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 433m, 3 },
                    { 7, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 10, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 471m, 1 },
                    { 11, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 46, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 1 },
                    { 43, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105m, 1 },
                    { 3, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 152m, 1 },
                    { 34, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 397m, 3 },
                    { 37, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 252m, 1 },
                    { 40, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 332m, 1 },
                    { 46, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 41, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 41, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 244m, 3 },
                    { 14, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209m, 1 },
                    { 26, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 480m, 1 },
                    { 43, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 472m, 3 },
                    { 2, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 35, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101m, 3 },
                    { 29, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 23, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 42, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202m, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 14, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111m, 1 },
                    { 46, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 464m, 1 },
                    { 32, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124m, 1 },
                    { 12, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 49, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 28, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 378m, 3 },
                    { 7, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 437m, 1 },
                    { 44, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 41, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 34, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 453m, 1 },
                    { 8, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 2, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 193m, 1 },
                    { 11, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 446m, 1 },
                    { 27, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 6, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212m, 1 },
                    { 28, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 37, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 21, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 31, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 434m, 1 },
                    { 11, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 3, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 24, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99m, 3 },
                    { 22, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 46, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 35, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 16, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 152m, 1 },
                    { 25, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 19, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 2, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 377m, 3 },
                    { 3, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 36, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 29, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 423m, 1 },
                    { 41, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 20, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 14, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 485m, 1 },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 22, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 162m, 1 },
                    { 24, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m, 1 },
                    { 45, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 18, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74m, 3 },
                    { 23, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 14, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 34, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 5, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 45, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 15, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 19, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 44, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 4, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 392m, 1 },
                    { 27, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 192m, 1 },
                    { 38, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 491m, 3 },
                    { 33, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 23, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 27, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 31, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 385m, 1 },
                    { 34, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 3 },
                    { 28, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207m, 3 },
                    { 24, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 15, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203m, 1 },
                    { 4, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 480m, 1 },
                    { 39, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 2, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 29, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 229m, 3 },
                    { 33, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 380m, 3 },
                    { 23, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 447m, 3 },
                    { 31, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165m, 1 },
                    { 14, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 28, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 4, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 37, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 37, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 13, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 22, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 433m, 3 },
                    { 20, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 466m, 1 },
                    { 25, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 13, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181m, 3 },
                    { 5, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 232m, 3 },
                    { 8, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 3, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 13, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 47, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 9, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 23, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 261m, 3 },
                    { 10, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 23, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 31, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 390m, 3 },
                    { 11, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 27, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 457m, 1 },
                    { 22, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 42, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 39, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115m, 1 },
                    { 12, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 241m, 3 },
                    { 37, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67m, 3 },
                    { 41, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 30, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 277m, 1 },
                    { 48, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 330m, 3 },
                    { 16, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 395m, 3 },
                    { 37, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 481m, 3 },
                    { 30, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 32, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 19, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 254m, 3 },
                    { 9, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 32, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 415m, 3 },
                    { 32, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 10, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 2, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158m, 1 },
                    { 43, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 14, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111m, 3 },
                    { 3, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 292m, 3 },
                    { 1, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 34, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 383m, 1 },
                    { 47, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 398m, 3 },
                    { 41, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 149m, 1 },
                    { 38, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 258m, 1 },
                    { 24, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 42, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 14, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 431m, 3 },
                    { 47, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 2, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 396m, 1 },
                    { 36, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 35, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 3, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 16, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 258m, 1 },
                    { 49, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 491m, 3 },
                    { 6, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 324m, 3 },
                    { 15, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 49, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 37, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 35, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 29, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 17, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 248m, 1 },
                    { 39, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 384m, 3 },
                    { 5, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71m, 3 },
                    { 1, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 232m, 3 },
                    { 17, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 1, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 33, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 7, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 357m, 1 },
                    { 19, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 26, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 33, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 137m, 3 },
                    { 40, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 35, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 24, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 354m, 1 },
                    { 22, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 477m, 3 },
                    { 1, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 297m, 3 },
                    { 22, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 24, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 299m, 3 }
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
