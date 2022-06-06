using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cs_app.Migrations
{
    public partial class MyAwesomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    passport_details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false),
                    company_name = table.Column<string>(type: "text", nullable: false),
                    quantity_in_stock = table.Column<string>(type: "text", nullable: false),
                    date_of_service = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    parameters = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    customer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_item",
                columns: table => new
                {
                    customers_id = table.Column<long>(type: "bigint", nullable: false),
                    items_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_item", x => new { x.customers_id, x.items_id });
                    table.ForeignKey(
                        name: "fk_customer_item_customers_customers_id",
                        column: x => x.customers_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customer_item_items_items_id",
                        column: x => x.items_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    customers_id = table.Column<long>(type: "bigint", nullable: false),
                    orders_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order", x => new { x.customers_id, x.orders_id });
                    table.ForeignKey(
                        name: "fk_customer_order_customers_customers_id",
                        column: x => x.customers_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customer_order_orders_orders_id",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_order",
                columns: table => new
                {
                    items_id = table.Column<long>(type: "bigint", nullable: false),
                    orders_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_order", x => new { x.items_id, x.orders_id });
                    table.ForeignKey(
                        name: "fk_item_order_items_items_id",
                        column: x => x.items_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_item_order_orders_orders_id",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_customer_item_items_id",
                table: "customer_item",
                column: "items_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_orders_id",
                table: "customer_order",
                column: "orders_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_order_orders_id",
                table: "item_order",
                column: "orders_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_item");

            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "item_order");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
