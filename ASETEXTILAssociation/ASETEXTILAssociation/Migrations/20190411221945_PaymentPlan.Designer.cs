﻿// <auto-generated />
using System;
using ASETEXTILAssociation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASETEXTILAssociation.Migrations
{
    [DbContext(typeof(AContext))]
    [Migration("20190411221945_PaymentPlan")]
    partial class PaymentPlan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASETEXTILAssociation.Models.Affiliate", b =>
                {
                    b.Property<int>("AffiliateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("JobPosition");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<double>("NetSalary");

                    b.Property<int?>("PaymentPlanId");

                    b.Property<int?>("UserTypeId");

                    b.HasKey("AffiliateId");

                    b.HasIndex("PaymentPlanId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Affiliates");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.Credit", b =>
                {
                    b.Property<int>("CreditId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AffiliateId");

                    b.Property<double>("Amount");

                    b.Property<bool>("Aproved");

                    b.Property<int?>("PaymentPlanId");

                    b.Property<string>("Purpose");

                    b.Property<int>("State");

                    b.Property<int?>("TypeCreditTypeId");

                    b.HasKey("CreditId");

                    b.HasIndex("AffiliateId");

                    b.HasIndex("PaymentPlanId");

                    b.HasIndex("TypeCreditTypeId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.CreditType", b =>
                {
                    b.Property<int>("CreditTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Interest");

                    b.Property<int>("MonthTerm");

                    b.Property<string>("Name");

                    b.HasKey("CreditTypeId");

                    b.ToTable("CreditType");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.PaymentPlan", b =>
                {
                    b.Property<int>("PaymentPlanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amortization");

                    b.Property<double>("FinalBalance");

                    b.Property<double>("InitialBalance");

                    b.Property<int>("Interest");

                    b.Property<int>("Month");

                    b.Property<int>("MonthlyFee");

                    b.HasKey("PaymentPlanId");

                    b.ToTable("PaymentPlans");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.Saving", b =>
                {
                    b.Property<int>("SavingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AffiliateId");

                    b.Property<double>("Amount");

                    b.Property<int?>("TypeSavingTypeId");

                    b.HasKey("SavingId");

                    b.HasIndex("AffiliateId");

                    b.HasIndex("TypeSavingTypeId");

                    b.ToTable("Savings");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.SavingType", b =>
                {
                    b.Property<int>("SavingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Interest");

                    b.Property<int>("MonthTerm");

                    b.Property<string>("Name");

                    b.HasKey("SavingTypeId");

                    b.ToTable("SavingType");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<int?>("UserTypeId");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.Affiliate", b =>
                {
                    b.HasOne("ASETEXTILAssociation.Models.PaymentPlan", "PaymentPlan")
                        .WithMany()
                        .HasForeignKey("PaymentPlanId");

                    b.HasOne("ASETEXTILAssociation.Models.UserType", "UserType")
                        .WithMany("Affiliates")
                        .HasForeignKey("UserTypeId");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.Credit", b =>
                {
                    b.HasOne("ASETEXTILAssociation.Models.Affiliate", "Affiliate")
                        .WithMany("Credits")
                        .HasForeignKey("AffiliateId");

                    b.HasOne("ASETEXTILAssociation.Models.PaymentPlan", "PaymentPlan")
                        .WithMany()
                        .HasForeignKey("PaymentPlanId");

                    b.HasOne("ASETEXTILAssociation.Models.CreditType", "Type")
                        .WithMany("Credits")
                        .HasForeignKey("TypeCreditTypeId");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.Saving", b =>
                {
                    b.HasOne("ASETEXTILAssociation.Models.Affiliate", "Affiliate")
                        .WithMany()
                        .HasForeignKey("AffiliateId");

                    b.HasOne("ASETEXTILAssociation.Models.SavingType", "Type")
                        .WithMany("Savings")
                        .HasForeignKey("TypeSavingTypeId");
                });

            modelBuilder.Entity("ASETEXTILAssociation.Models.User", b =>
                {
                    b.HasOne("ASETEXTILAssociation.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
