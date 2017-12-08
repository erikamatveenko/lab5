﻿// <auto-generated />
using lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace lab5.Migrations
{
    [DbContext(typeof(UchetContext))]
    [Migration("20171112004646_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab4.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandCategory");

                    b.Property<string>("BrandCharacteristic");

                    b.Property<string>("BrandCompany");

                    b.Property<string>("BrandCountry");

                    b.Property<string>("BrandDescription");

                    b.Property<DateTime>("BrandEndingDate");

                    b.Property<string>("BrandName");

                    b.Property<DateTime>("BrandStartDate");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("lab4.Models.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandID");

                    b.Property<string>("CarColor");

                    b.Property<string>("CarDescription");

                    b.Property<DateTime>("CarLastCheckupDate");

                    b.Property<int>("CarNumberOfBody");

                    b.Property<int>("CarNumberOfMotor");

                    b.Property<int>("CarNumberOfPassport");

                    b.Property<int>("CarPhoto");

                    b.Property<DateTime>("CarRegistrationDate");

                    b.Property<int>("CarRegistrationNumber");

                    b.Property<DateTime>("CarReleaseDate");

                    b.Property<int>("OwnerID");

                    b.HasKey("CarID");

                    b.HasIndex("BrandID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("lab4.Models.Owner", b =>
                {
                    b.Property<int>("OwnerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OwnerAddress");

                    b.Property<DateTime>("OwnerBirthDate");

                    b.Property<string>("OwnerCategory");

                    b.Property<DateTime>("OwnerLicenseDeliveryDate");

                    b.Property<DateTime>("OwnerLicenseValidityDate");

                    b.Property<string>("OwnerMoreInformation");

                    b.Property<string>("OwnerName");

                    b.Property<int>("OwnerNumberOfDriverLicense");

                    b.Property<string>("OwnerPassport");

                    b.HasKey("OwnerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("lab4.Models.Car", b =>
                {
                    b.HasOne("lab4.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("lab4.Models.Owner", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
