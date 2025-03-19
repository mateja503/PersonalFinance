﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinance.Repository.Data;

#nullable disable

namespace PersonalFinance.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalFinance.Domain.Identity.AccountUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("AccountUsers");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.AccountUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountUserId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AccountUserRoles");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.RoleManager.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.AccountUserBudget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountUserId")
                        .HasColumnType("int");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("int");

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountUserId");

                    b.HasIndex("BudgetId");

                    b.HasIndex("Categoryid");

                    b.ToTable("AccountUserBudgets");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.AccountUserFinancialGoals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountUserId")
                        .HasColumnType("int");

                    b.Property<int>("FinancialGoalsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountUserId");

                    b.HasIndex("FinancialGoalsId");

                    b.ToTable("AccountUserFinancialGoals");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BudgetMonth")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("budgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Budgets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BudgetMonth = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            budgetAmount = 100m
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            categoryName = "Намирници-Храна"
                        },
                        new
                        {
                            Id = 2,
                            categoryName = "Плата"
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.FinancialGoals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("amountGoal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("goalReachInTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("goalText")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("FinancialGoals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            amountGoal = 21000m,
                            goalReachInTime = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            goalText = "Потребни ми се 21.000$ за целосно опремување на стан"
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Купено Леб,Сирење,Чајна"
                        },
                        new
                        {
                            Id = 2,
                            Text = "Плата од фирма Апдомен чувај за стан!!!!"
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            TransactionType = 2,
                            amount = 200m,
                            dateTime = new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            TransactionType = 1,
                            amount = 500m,
                            dateTime = new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.TransactionNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionNotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NoteId = 1,
                            TransactionId = 1
                        },
                        new
                        {
                            Id = 2,
                            NoteId = 2,
                            TransactionId = 2
                        });
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.AccountUser", b =>
                {
                    b.OwnsOne("PersonalFinance.Domain.Identity.Auth", "UserAuthentication", b1 =>
                        {
                            b1.Property<int>("AccountUserId")
                                .HasColumnType("int");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("au_password")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("au_username")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.HasKey("AccountUserId");

                            b1.ToTable("AccountUsers");

                            b1.WithOwner()
                                .HasForeignKey("AccountUserId");
                        });

                    b.Navigation("UserAuthentication")
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.AccountUserRole", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Identity.AccountUser", "AccountUser")
                        .WithMany("Roles")
                        .HasForeignKey("AccountUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PersonalFinance.Domain.Identity.RoleManager.Role", "Role")
                        .WithMany("AccountUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AccountUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.AccountUserBudget", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Identity.AccountUser", "AccountUser")
                        .WithMany("AccountUserBudgetList")
                        .HasForeignKey("AccountUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PersonalFinance.Domain.Models.Budget", "Budget")
                        .WithMany("AccountUserBudgetList")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PersonalFinance.Domain.Models.Category", "Category")
                        .WithMany("AccountUserBudgetList")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AccountUser");

                    b.Navigation("Budget");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.AccountUserFinancialGoals", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Identity.AccountUser", "AccountUser")
                        .WithMany("AccontUserFinancialGoalList")
                        .HasForeignKey("AccountUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PersonalFinance.Domain.Models.FinancialGoals", "FinancialGoals")
                        .WithMany("AccountUserFinancialGoalList")
                        .HasForeignKey("FinancialGoalsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AccountUser");

                    b.Navigation("FinancialGoals");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Transaction", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Models.Category", "Category")
                        .WithMany("TransactionList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.TransactionNotes", b =>
                {
                    b.HasOne("PersonalFinance.Domain.Models.Note", "Note")
                        .WithMany("TransactionNoteList")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersonalFinance.Domain.Models.Transaction", "Transaction")
                        .WithMany("TransactionNoteList")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Note");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.AccountUser", b =>
                {
                    b.Navigation("AccontUserFinancialGoalList");

                    b.Navigation("AccountUserBudgetList");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Identity.RoleManager.Role", b =>
                {
                    b.Navigation("AccountUsers");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Budget", b =>
                {
                    b.Navigation("AccountUserBudgetList");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Category", b =>
                {
                    b.Navigation("AccountUserBudgetList");

                    b.Navigation("TransactionList");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.FinancialGoals", b =>
                {
                    b.Navigation("AccountUserFinancialGoalList");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Note", b =>
                {
                    b.Navigation("TransactionNoteList");
                });

            modelBuilder.Entity("PersonalFinance.Domain.Models.Transaction", b =>
                {
                    b.Navigation("TransactionNoteList");
                });
#pragma warning restore 612, 618
        }
    }
}
