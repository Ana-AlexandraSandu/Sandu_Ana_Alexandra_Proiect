﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sandu_Ana_Alexandra_Proiect.Data;

namespace Sandu_Ana_Alexandra_Proiect.Migrations
{
    [DbContext(typeof(Sandu_Ana_Alexandra_ProiectContext))]
    [Migration("20201220201718_Primul")]
    partial class Primul
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sandu_Ana_Alexandra_Proiect.Models.Vacanta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dataplecare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datasosire")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ghid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tara")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vacanta");
                });
#pragma warning restore 612, 618
        }
    }
}
