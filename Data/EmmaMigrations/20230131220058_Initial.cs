using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmaProject.Data.EmmaMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustFirst = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustLast = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CustPhone = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CustAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CustCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustProvince = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    CustPostal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpFirst = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmpLast = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmpUserName = table.Column<string>(type: "TEXT", nullable: false),
                    EmpPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    UPC_ID = table.Column<string>(type: "TEXT", nullable: false),
                    InvName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InvSize = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InvQuantity = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    InvAdjustedPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    InvMarkupPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    InvCurrent = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.UPC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    OtherDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PosTitle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PosID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PosTitle);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    SupPhone = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    SupEmail = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SupAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SupCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SupProvince = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    SupPostal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupID);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    OrderRequestID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustID = table.Column<int>(type: "INTEGER", nullable: false),
                    ORequestDesc = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OReqSendData = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    OReqReciveData = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ExternalOrderNum = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.OrderRequestID);
                    table.ForeignKey(
                        name: "FK_OrderRequests_Customers_CustID",
                        column: x => x.CustID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpLogins",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SinIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SinOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmpID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpLogins", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_EmpLogins_Employees_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Appreciation = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    InvoiceSubtotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustID = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "INTEGER", nullable: false),
                    PosID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => new { x.EmpID, x.PosID });
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PosID",
                        column: x => x.PosID,
                        principalTable: "Positions",
                        principalColumn: "PosTitle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UPC_ID = table.Column<string>(type: "TEXT", nullable: false),
                    PricePurchasedCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    PricePurchasedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PriceCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SupID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK_Prices_Inventories_UPC_ID",
                        column: x => x.UPC_ID,
                        principalTable: "Inventories",
                        principalColumn: "UPC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_Suppliers_SupID",
                        column: x => x.SupID,
                        principalTable: "Suppliers",
                        principalColumn: "SupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequestInventories",
                columns: table => new
                {
                    OrderRequestID = table.Column<int>(type: "INTEGER", nullable: false),
                    UPC_ID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequestInventories", x => new { x.OrderRequestID, x.UPC_ID });
                    table.ForeignKey(
                        name: "FK_OrderRequestInventories_Inventories_UPC_ID",
                        column: x => x.UPC_ID,
                        principalTable: "Inventories",
                        principalColumn: "UPC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRequestInventories_OrderRequests_OrderRequestID",
                        column: x => x.OrderRequestID,
                        principalTable: "OrderRequests",
                        principalColumn: "OrderRequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    UPC_ID = table.Column<string>(type: "TEXT", nullable: false),
                    OtQuanity = table.Column<int>(type: "INTEGER", nullable: false),
                    OtSalePrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => new { x.InvoiceID, x.UPC_ID });
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Inventories_UPC_ID",
                        column: x => x.UPC_ID,
                        principalTable: "Inventories",
                        principalColumn: "UPC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePayments",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePayments", x => new { x.InvoiceID, x.PaymentID });
                    table.ForeignKey(
                        name: "FK_InvoicePayments_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpLogins_EmpID",
                table: "EmpLogins",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PosID",
                table: "EmployeePositions",
                column: "PosID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceID",
                table: "InvoiceLines",
                column: "InvoiceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_UPC_ID",
                table: "InvoiceLines",
                column: "UPC_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_PaymentID",
                table: "InvoicePayments",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmpID",
                table: "Invoices",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequestInventories_UPC_ID",
                table: "OrderRequestInventories",
                column: "UPC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_CustID",
                table: "OrderRequests",
                column: "CustID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SupID",
                table: "Prices",
                column: "SupID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_UPC_ID",
                table: "Prices",
                column: "UPC_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpLogins");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "InvoicePayments");

            migrationBuilder.DropTable(
                name: "OrderRequestInventories");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "OrderRequests");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
