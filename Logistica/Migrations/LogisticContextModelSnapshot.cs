﻿// <auto-generated />
using System;
using Logistica.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logistica.Migrations
{
    [DbContext(typeof(LogisticContext))]
    partial class LogisticContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Logistica.Model.Logistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guide")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logistics");
                });
#pragma warning restore 612, 618
        }
    }
}