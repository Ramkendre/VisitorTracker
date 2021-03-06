﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitorTrackerStatelessService.StorageModel;

namespace VisitorTrackerStatelessService.Migrations
{
    [DbContext(typeof(VisitorContext))]
    [Migration("20190110124321_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VisitorTrackerStatelessService.StorageModel.Visitors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactPerson");

                    b.Property<string>("From");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Location");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Purpose");

                    b.Property<string>("VisitTime");

                    b.Property<string>("VisitorImage");

                    b.Property<string>("VisitorName");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });
#pragma warning restore 612, 618
        }
    }
}
