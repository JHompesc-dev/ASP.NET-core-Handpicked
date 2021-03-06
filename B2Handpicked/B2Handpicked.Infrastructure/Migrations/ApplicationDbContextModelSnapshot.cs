﻿// <auto-generated />
using System;
using B2Handpicked.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace B2Handpicked.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("B2Handpicked.DomainModel.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(64);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<int?>("LabelId");

                    b.Property<string>("Name")
                        .HasMaxLength(64);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Deadline");

                    b.Property<int>("Percentage");

                    b.Property<string>("Title");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Deal");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.DealEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DealId");

                    b.Property<int?>("EmployeeId");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DealEmployee");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gmail")
                        .HasMaxLength(128);

                    b.Property<bool>("HasAccess");

                    b.Property<int?>("LabelId");

                    b.Property<string>("Name")
                        .HasMaxLength(64);

                    b.Property<string>("OAuth");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("LabelId");

                    b.Property<int>("Number");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LabelId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.ContactPerson", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Customer", "Customer")
                        .WithMany("ContactPeople")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Customer", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Label", "Label")
                        .WithMany("Customers")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Deal", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Customer", "Customer")
                        .WithMany("Deals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.DealEmployee", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Deal", "Deal")
                        .WithMany("DealEmployees")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("B2Handpicked.DomainModel.Employee", "Employee")
                        .WithMany("DealEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Employee", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Label", "Label")
                        .WithMany("Employees")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("B2Handpicked.DomainModel.Invoice", b =>
                {
                    b.HasOne("B2Handpicked.DomainModel.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("B2Handpicked.DomainModel.Label", "Label")
                        .WithMany("Invoices")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
