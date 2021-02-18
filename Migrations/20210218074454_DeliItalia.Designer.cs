﻿// <auto-generated />
using System;
using DelliItalia_Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DelliItalia_Razor.Migrations
{
    [DbContext(typeof(DelliItalia_RazorContext))]
    [Migration("20210218074454_DeliItalia")]
    partial class DeliItalia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DelliItalia_Razor.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chosen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eco")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Sale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sale_Percent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ProductModel");
                });
#pragma warning restore 612, 618
        }
    }
}
