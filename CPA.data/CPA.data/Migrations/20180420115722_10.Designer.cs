﻿// <auto-generated />
using CPA.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CPA.data.Migrations
{
    [DbContext(typeof(CPAcontext))]
    [Migration("20180420115722_10")]
    partial class _10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPA.domain.Buy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<int?>("WhatId");

                    b.Property<int?>("WhenId");

                    b.Property<int?>("WhereId");

                    b.Property<int?>("WhyId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WhatId");

                    b.HasIndex("WhenId");

                    b.HasIndex("WhereId");

                    b.HasIndex("WhyId");

                    b.ToTable("Buy");
                });

            modelBuilder.Entity("CPA.domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CPA.domain.What", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("What");
                });

            modelBuilder.Entity("CPA.domain.When", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("When");
                });

            modelBuilder.Entity("CPA.domain.Where", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Where");
                });

            modelBuilder.Entity("CPA.domain.Why", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Why");
                });

            modelBuilder.Entity("CPA.domain.Buy", b =>
                {
                    b.HasOne("CPA.domain.Customer", "Customer")
                        .WithMany("Buy")
                        .HasForeignKey("CustomerId");

                    b.HasOne("CPA.domain.What", "What")
                        .WithMany()
                        .HasForeignKey("WhatId");

                    b.HasOne("CPA.domain.When", "When")
                        .WithMany()
                        .HasForeignKey("WhenId");

                    b.HasOne("CPA.domain.Where", "Where")
                        .WithMany()
                        .HasForeignKey("WhereId");

                    b.HasOne("CPA.domain.Why", "Why")
                        .WithMany()
                        .HasForeignKey("WhyId");
                });
#pragma warning restore 612, 618
        }
    }
}
