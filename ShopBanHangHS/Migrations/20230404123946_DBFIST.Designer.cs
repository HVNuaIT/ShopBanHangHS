﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopBanHangHS.Data;

namespace ShopBanHangHS.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20230404123946_DBFIST")]
    partial class DBFIST
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ShopBanHangHS.Models.DanhMuc", b =>
                {
                    b.Property<int>("maDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("tenDanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maDanhMuc");

                    b.ToTable("DanhMuc");
                });

            modelBuilder.Entity("ShopBanHangHS.Models.Order", b =>
                {
                    b.Property<int>("maHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ghiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maSanPham")
                        .HasColumnType("int");

                    b.Property<int?>("maTaiKhoan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ngayMuaHang")
                        .HasColumnType("datetime2");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.Property<double>("thanhTien")
                        .HasColumnType("float");

                    b.Property<string>("trangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maHoaDon");

                    b.ToTable("DatHang");
                });

            modelBuilder.Entity("ShopBanHangHS.Models.Quyen", b =>
                {
                    b.Property<int>("maQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("tenQuen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maQuyen");

                    b.ToTable("Quyen");
                });

            modelBuilder.Entity("ShopBanHangHS.Models.SanPham", b =>
                {
                    b.Property<int>("maSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double?>("Gia")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("maLoai")
                        .HasColumnType("int");

                    b.Property<string>("moTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("soLuong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("tenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maSanPham");

                    b.HasIndex("maLoai");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("ShopBanHangHS.Models.User", b =>
                {
                    b.Property<int>("maTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("quyen")
                        .HasColumnType("bit");

                    b.Property<string>("soDT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("xacThucEmail")
                        .HasColumnType("bit");

                    b.HasKey("maTaiKhoan");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("ShopBanHangHS.Models.SanPham", b =>
                {
                    b.HasOne("ShopBanHangHS.Models.DanhMuc", "danhMuc")
                        .WithMany()
                        .HasForeignKey("maLoai");

                    b.Navigation("danhMuc");
                });
#pragma warning restore 612, 618
        }
    }
}