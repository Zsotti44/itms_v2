﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using itms_v2.Server.Services;

#nullable disable

namespace itms_v2.Server.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240204001222_EditProductCategory")]
    partial class EditProductCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("itms_v2.Server.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Goods_pal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("itms_v2.Server.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ADR")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategorys");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("dispatcherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("shift_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("dispatcherId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ADR")
                        .HasColumnType("bit");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Goods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Loaded")
                        .HasColumnType("bit");

                    b.Property<string>("ParkigLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Standby")
                        .HasColumnType("bit");

                    b.Property<bool>("Traffic")
                        .HasColumnType("bit");

                    b.Property<string>("owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ADR")
                        .HasColumnType("bit");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Standalone")
                        .HasColumnType("bit");

                    b.Property<bool>("Traffic")
                        .HasColumnType("bit");

                    b.Property<string>("owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("itms_v2.Server.Models.TruckDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ADR")
                        .HasColumnType("bit");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TruckDrivers");
                });

            modelBuilder.Entity("itms_v2.Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("dispatcher")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address_line1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_line2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_line3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_line4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("itms_v2.Server.Models.WorkTruck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("trailerId")
                        .HasColumnType("int");

                    b.Property<int>("truckId")
                        .HasColumnType("int");

                    b.Property<bool>("working")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShiftId");

                    b.HasIndex("driverId");

                    b.HasIndex("trailerId");

                    b.HasIndex("truckId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Workticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DispatcherId")
                        .HasColumnType("int");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("GoodsQty")
                        .HasColumnType("int");

                    b.Property<int>("PalQty")
                        .HasColumnType("int");

                    b.Property<bool>("Priority")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("finish_dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("lot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("preloading")
                        .HasColumnType("bit");

                    b.Property<DateTime>("request_dateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("truckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DispatcherId");

                    b.HasIndex("FromId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequesterId");

                    b.HasIndex("ToId");

                    b.HasIndex("truckId");

                    b.ToTable("Worktickets");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Product", b =>
                {
                    b.HasOne("itms_v2.Server.Models.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Shift", b =>
                {
                    b.HasOne("itms_v2.Server.Models.User", "dispatcher")
                        .WithMany()
                        .HasForeignKey("dispatcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dispatcher");
                });

            modelBuilder.Entity("itms_v2.Server.Models.WorkTruck", b =>
                {
                    b.HasOne("itms_v2.Server.Models.Shift", null)
                        .WithMany("trucks")
                        .HasForeignKey("ShiftId");

                    b.HasOne("itms_v2.Server.Models.TruckDriver", "driver")
                        .WithMany()
                        .HasForeignKey("driverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.Trailer", "trailer")
                        .WithMany()
                        .HasForeignKey("trailerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.Truck", "truck")
                        .WithMany()
                        .HasForeignKey("truckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("driver");

                    b.Navigation("trailer");

                    b.Navigation("truck");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Workticket", b =>
                {
                    b.HasOne("itms_v2.Server.Models.User", "Dispatcher")
                        .WithMany()
                        .HasForeignKey("DispatcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.Warehouse", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.User", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.Warehouse", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itms_v2.Server.Models.WorkTruck", "truck")
                        .WithMany()
                        .HasForeignKey("truckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dispatcher");

                    b.Navigation("From");

                    b.Navigation("Product");

                    b.Navigation("Requester");

                    b.Navigation("To");

                    b.Navigation("truck");
                });

            modelBuilder.Entity("itms_v2.Server.Models.Shift", b =>
                {
                    b.Navigation("trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
