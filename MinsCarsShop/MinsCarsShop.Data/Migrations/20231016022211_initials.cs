using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinsCarsShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(4563)),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(4956)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "default.png"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(7594)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(7849))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Totes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(5800)),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(6190)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Totes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ToteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.ToteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Carts_Totes_ToteId",
                        column: x => x.ToteId,
                        principalTable: "Totes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ToteId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    OrderPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ToteId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Totes_ToteId",
                        column: x => x.ToteId,
                        principalTable: "Totes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "1.jpg", "Canvas Tote" },
                    { 2, "2.jpg", "Jean Tote" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chưa xử lý" },
                    { 2, "Đang chuẩn bị" },
                    { 3, "Đang giao hàng" },
                    { 4, "Giao hàng thành công" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Avatar", "Email", "Name", "Password", "Phone", "RegisteredDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "3/2, Ninh Kieu, Can Tho", "myAvatar.jpg", "minhkhalectu@gmail.com", "Le Minh Kha", "leminhkha123", "0398897634", new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4309), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4310) },
                    { 2, "622/10, phuong 13, Cong Hoa, Tan Binh. Tp. HCM", "myChongiu.jpg", "silasnguyen@gmail.com", "Nguyen Tung Lam", "chongiu23", "0338307449", new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4311), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4312) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DeliveryTime", "OrderTime", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4267), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4266), 1, 1 },
                    { 2, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4271), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4270), 2, 2 },
                    { 3, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4272), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4272), 3, 1 },
                    { 4, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4274), new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4273), 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Totes",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4076), "1.jpg", "Ha Noi", 9 },
                    { 2, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4088), "2.jpg", "Women in front of the windown", 9 },
                    { 4, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4089), "4.jpg", "Portal to the Cat Dimension", 9 },
                    { 5, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4090), "5.jpg", "Stay Positive", 9 },
                    { 6, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4092), "6.jpg", "Couple see the earth", 9 },
                    { 7, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4093), "7.jpg", "The Bodacious Period", 9 },
                    { 8, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4094), "8.jpg", "Hide from reality", 9 },
                    { 9, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4095), "9.jpg", "Blue purple OLDI", 9 },
                    { 10, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4096), "10.jpg", "Purple Elephent angry", 9 },
                    { 11, 1, new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4097), "11.jpg", "Bag of Holand", 9 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "ToteId", "UserId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ToteId", "Amount", "OrderPrice" },
                values: new object[,]
                {
                    { 1, 1, 2, 138000 },
                    { 2, 2, 10, 999000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ToteId",
                table: "OrderDetails",
                column: "ToteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Totes_CategoryId",
                table: "Totes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Totes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
