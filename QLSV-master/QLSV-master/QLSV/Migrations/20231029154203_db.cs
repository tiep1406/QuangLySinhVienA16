﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSV.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    TaiKhoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.TaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gia = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad_Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Admin_Ad_Username",
                        column: x => x.Ad_Username,
                        principalTable: "Admin",
                        principalColumn: "TaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddFundTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddFundTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_AddFundTransaction_Fund_FundId",
                        column: x => x.FundId,
                        principalTable: "Fund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddFundTransaction_HocSinh_UserId",
                        column: x => x.UserId,
                        principalTable: "HocSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DatePurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_HocSinh_UserID",
                        column: x => x.UserID,
                        principalTable: "HocSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiemHocSinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHocSinh = table.Column<int>(type: "int", nullable: false),
                    IdKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    SoDiem = table.Column<int>(type: "int", nullable: false),
                    NhanXet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemHocSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemHocSinh_HocSinh_IdHocSinh",
                        column: x => x.IdHocSinh,
                        principalTable: "HocSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiemHocSinh_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiaoVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKhoaHoc = table.Column<int>(type: "int", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoVien_KhoaHoc_IdKhoaHoc",
                        column: x => x.IdKhoaHoc,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.Id, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetail_KhoaHoc_ProductID",
                        column: x => x.ProductID,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_Id",
                        column: x => x.Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Refund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DatePurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refund_HocSinh_UserID",
                        column: x => x.UserID,
                        principalTable: "HocSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Refund_KhoaHoc_ProductID",
                        column: x => x.ProductID,
                        principalTable: "KhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Refund_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddFundTransaction_FundId",
                table: "AddFundTransaction",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_AddFundTransaction_UserId",
                table: "AddFundTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Ad_Username",
                table: "Blog",
                column: "Ad_Username");

            migrationBuilder.CreateIndex(
                name: "IX_DiemHocSinh_IdHocSinh",
                table: "DiemHocSinh",
                column: "IdHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_DiemHocSinh_IdKhoaHoc",
                table: "DiemHocSinh",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoVien_IdKhoaHoc",
                table: "GiaoVien",
                column: "IdKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_OrderID",
                table: "Refund",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_ProductID",
                table: "Refund",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_UserID",
                table: "Refund",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddFundTransaction");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "DiemHocSinh");

            migrationBuilder.DropTable(
                name: "GiaoVien");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Refund");

            migrationBuilder.DropTable(
                name: "Fund");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "KhoaHoc");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "HocSinh");
        }
    }
}
