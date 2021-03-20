﻿// <auto-generated />
using System;
using API.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210320181655_modelsBetter")]
    partial class modelsBetter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Haandvaerker", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("HVAnsaettelsedato")
                        .HasColumnType("datetime2");

                    b.Property<string>("HVEfternavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFagomraade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFornavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Haandværkere");
                });

            modelBuilder.Entity("API.Models.Vaerktoej", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("VTAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<string>("VTFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTSerienr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaerktoejskasseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vaerktøjer");
                });

            modelBuilder.Entity("API.Models.Vaerktoejskasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("VTKAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<string>("VTKFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKFarve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKSerienummer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vaerktoejskasser");
                });

            modelBuilder.Entity("API.Models.Haandvaerker", b =>
                {
                    b.HasOne("API.Models.Vaerktoejskasse", "Vaerktoejskasse")
                        .WithOne("Haandvaerker")
                        .HasForeignKey("API.Models.Haandvaerker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaerktoejskasse");
                });

            modelBuilder.Entity("API.Models.Vaerktoej", b =>
                {
                    b.HasOne("API.Models.Vaerktoejskasse", "Vaerktoejskasse")
                        .WithMany("Vaerktoej")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaerktoejskasse");
                });

            modelBuilder.Entity("API.Models.Vaerktoejskasse", b =>
                {
                    b.Navigation("Haandvaerker");

                    b.Navigation("Vaerktoej");
                });
#pragma warning restore 612, 618
        }
    }
}