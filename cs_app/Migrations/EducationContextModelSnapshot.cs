﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cs_app.Data;

#nullable disable

namespace cs_app.Migrations
{
    [DbContext(typeof(EducationContext))]
    partial class EducationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cs_app.Data.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PassportDetails")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("passport_details");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("cs_app.Data.Models.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("cost");

                    b.Property<string>("DateOfService")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_of_service");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Parameters")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("parameters");

                    b.Property<string>("QuantityInStock")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("quantity_in_stock");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("cs_app.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("customer");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("order_amount");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CustomerItem", b =>
                {
                    b.Property<long>("CustomersId")
                        .HasColumnType("bigint")
                        .HasColumnName("customers_id");

                    b.Property<long>("ItemsId")
                        .HasColumnType("bigint")
                        .HasColumnName("items_id");

                    b.HasKey("CustomersId", "ItemsId")
                        .HasName("pk_customer_item");

                    b.HasIndex("ItemsId")
                        .HasDatabaseName("ix_customer_item_items_id");

                    b.ToTable("customer_item", (string)null);
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.Property<long>("CustomersId")
                        .HasColumnType("bigint")
                        .HasColumnName("customers_id");

                    b.Property<long>("OrdersId")
                        .HasColumnType("bigint")
                        .HasColumnName("orders_id");

                    b.HasKey("CustomersId", "OrdersId")
                        .HasName("pk_customer_order");

                    b.HasIndex("OrdersId")
                        .HasDatabaseName("ix_customer_order_orders_id");

                    b.ToTable("customer_order", (string)null);
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.Property<long>("ItemsId")
                        .HasColumnType("bigint")
                        .HasColumnName("items_id");

                    b.Property<long>("OrdersId")
                        .HasColumnType("bigint")
                        .HasColumnName("orders_id");

                    b.HasKey("ItemsId", "OrdersId")
                        .HasName("pk_item_order");

                    b.HasIndex("OrdersId")
                        .HasDatabaseName("ix_item_order_orders_id");

                    b.ToTable("item_order", (string)null);
                });

            modelBuilder.Entity("CustomerItem", b =>
                {
                    b.HasOne("cs_app.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_item_customers_customers_id");

                    b.HasOne("cs_app.Data.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_item_items_items_id");
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.HasOne("cs_app.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_order_customers_customers_id");

                    b.HasOne("cs_app.Data.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_order_orders_orders_id");
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.HasOne("cs_app.Data.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_order_items_items_id");

                    b.HasOne("cs_app.Data.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_order_orders_orders_id");
                });
#pragma warning restore 612, 618
        }
    }
}