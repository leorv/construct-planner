﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(ConstructContext))]
    [Migration("20211212000612_PropTotalOfLevel")]
    partial class PropTotalOfLevel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Domain.Entities.Bidding.Additive", b =>
                {
                    b.Property<long>("AdditiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    b.Property<sbyte>("Closed")
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT");

                    b.Property<long>("ContractId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("VARCHAR(512)");

                    b.Property<string>("Justification")
                        .HasMaxLength(2048)
                        .HasColumnType("VARCHAR(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<int>("Number")
                        .HasColumnType("INT");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("DECIMAL(65,30)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("INT");

                    b.HasKey("AdditiveId");

                    b.HasIndex("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("Additive");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveAgreement", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveId")
                        .HasColumnType("BIGINT");

                    b.Property<sbyte>("IsAgree")
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT");

                    b.HasKey("UserId", "AdditiveId");

                    b.HasIndex("AdditiveId");

                    b.ToTable("AdditiveAgreement");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveClause", b =>
                {
                    b.Property<long>("AdditiveClauseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveID")
                        .HasColumnType("BIGINT");

                    b.Property<bool>("Closed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Text")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)");

                    b.HasKey("AdditiveClauseId");

                    b.HasIndex("AdditiveID");

                    b.ToTable("AdditiveClause");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveLevel", b =>
                {
                    b.Property<long>("AdditiveLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveSpreadsheetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("AdditiveLevelId");

                    b.HasIndex("AdditiveSpreadsheetId");

                    b.ToTable("AdditiveLevel");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveSpreadsheet", b =>
                {
                    b.Property<long>("AdditiveSpreadsheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Author")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("EncumberType")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("AdditiveSpreadsheetId");

                    b.HasIndex("AdditiveId")
                        .IsUnique();

                    b.ToTable("AdditiveSpreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveSpreadsheetItem", b =>
                {
                    b.Property<long>("AdditiveSpreadsheetItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveLevelId")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("Code")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("ManPower")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Material")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Source")
                        .HasMaxLength(48)
                        .HasColumnType("varchar(48)");

                    b.Property<string>("Unit")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("AdditiveSpreadsheetItemId");

                    b.HasIndex("AdditiveLevelId");

                    b.ToTable("AdditiveSpreadsheetItem");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Clause", b =>
                {
                    b.Property<long>("ClauseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Closed")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("ContractId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Text")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)");

                    b.HasKey("ClauseId");

                    b.HasIndex("ContractId");

                    b.ToTable("Clause");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Contract", b =>
                {
                    b.Property<long>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    b.Property<sbyte>("Closed")
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT");

                    b.Property<long>("ContractedUserId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Object")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.ContractAgreement", b =>
                {
                    b.Property<long>("ContractId")
                        .HasColumnType("bigint");

                    b.Property<sbyte>("IsAgree")
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("ContractAgreement");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.ContractUser", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ContractId")
                        .HasColumnType("BIGINT");

                    b.HasKey("UserId", "ContractId");

                    b.HasIndex("ContractId");

                    b.ToTable("ContractUser");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Level", b =>
                {
                    b.Property<long>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<long>("SpreadsheetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<long>("Total")
                        .HasColumnType("BIGINT");

                    b.HasKey("LevelId");

                    b.HasIndex("SpreadsheetId");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.BDI", b =>
                {
                    b.Property<long>("BDIId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("BDIValue")
                        .HasColumnType("double");

                    b.Property<double>("CPRB")
                        .HasColumnType("double");

                    b.Property<double>("Cofins")
                        .HasColumnType("double");

                    b.Property<long>("ContractId")
                        .HasColumnType("BIGINT");

                    b.Property<double>("FinantialExpenses")
                        .HasColumnType("double");

                    b.Property<double>("GeneralExpenses")
                        .HasColumnType("double");

                    b.Property<double>("ISS")
                        .HasColumnType("double");

                    b.Property<double>("Insurance")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Number")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<double>("PIS")
                        .HasColumnType("double");

                    b.Property<double>("PersonnelAdministration")
                        .HasColumnType("double");

                    b.Property<double>("Profit")
                        .HasColumnType("double");

                    b.Property<double>("Risks")
                        .HasColumnType("double");

                    b.Property<double>("Warranty")
                        .HasColumnType("double");

                    b.HasKey("BDIId");

                    b.HasIndex("ContractId");

                    b.ToTable("BDI");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.Input", b =>
                {
                    b.Property<long>("InputId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("Code")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("SourceId")
                        .HasColumnType("bigint");

                    b.Property<long>("SourceItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)");

                    b.Property<string>("Unit")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("InputId");

                    b.HasIndex("SourceId");

                    b.HasIndex("SourceItemId");

                    b.ToTable("Input");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.Source", b =>
                {
                    b.Property<long>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Day")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("EncumberType")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.Property<int>("Month")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(48)
                        .HasColumnType("varchar(48)");

                    b.Property<string>("SourceFamily")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("SourceId");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.SourceItem", b =>
                {
                    b.Property<long>("SourceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("ManPower")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Material")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("SourceId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalUnitValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Unit")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("SourceItemId");

                    b.HasIndex("SourceId");

                    b.ToTable("SourceItem");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Spreadsheet", b =>
                {
                    b.Property<long>("SpreadsheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AdditiveId")
                        .HasColumnType("bigint");

                    b.Property<string>("Author")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<long>("ContractId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("EncumberType")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("SpreadsheetId");

                    b.HasIndex("ContractId");

                    b.ToTable("Spreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.SpreadsheetItem", b =>
                {
                    b.Property<long>("SpreadsheetItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("Code")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<long>("LevelId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ManPower")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Material")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Source")
                        .HasMaxLength(48)
                        .HasColumnType("varchar(48)");

                    b.Property<string>("Unit")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("SpreadsheetItemId");

                    b.HasIndex("LevelId");

                    b.ToTable("SpreadsheetItem");
                });

            modelBuilder.Entity("Domain.Entities.Common.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AdditiveSpreadsheetId")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Complement")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Country")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("District")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<long>("SpreadsheetId")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Street")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("AddressId");

                    b.HasIndex("AdditiveSpreadsheetId");

                    b.HasIndex("SpreadsheetId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Password")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Photo")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Additive", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("Additives")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Additives")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveAgreement", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Additive", "Additive")
                        .WithMany("AdditiveAgreements")
                        .HasForeignKey("AdditiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("AdditiveAgreements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additive");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveClause", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Additive", "Additive")
                        .WithMany("AdditiveClauses")
                        .HasForeignKey("AdditiveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additive");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveLevel", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.AdditiveSpreadsheet", "AdditiveSpreadsheet")
                        .WithMany("AdditiveLevels")
                        .HasForeignKey("AdditiveSpreadsheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditiveSpreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveSpreadsheet", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Additive", "Additive")
                        .WithOne("AdditiveSpreadsheet")
                        .HasForeignKey("Domain.Entities.Bidding.AdditiveSpreadsheet", "AdditiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additive");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveSpreadsheetItem", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.AdditiveLevel", "AdditiveLevel")
                        .WithMany("AdditiveSpreadsheetItems")
                        .HasForeignKey("AdditiveLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditiveLevel");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Clause", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("Clauses")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Contract", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Contracts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.ContractAgreement", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("ContractAgreements")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("ContractAgreements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.ContractUser", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("ContractUsers")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("ContractUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Level", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Spreadsheet", "Spreadsheet")
                        .WithMany("Levels")
                        .HasForeignKey("SpreadsheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.BDI", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("BDIs")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.Input", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.PriceReference.Source", "Source")
                        .WithMany("Inputs")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Bidding.PriceReference.SourceItem", "SourceItem")
                        .WithMany("Inputs")
                        .HasForeignKey("SourceItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");

                    b.Navigation("SourceItem");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.SourceItem", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.PriceReference.Source", "Source")
                        .WithMany("SourceItems")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Spreadsheet", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Contract", "Contract")
                        .WithMany("Spreadsheets")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.SpreadsheetItem", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.Level", "Level")
                        .WithMany("SpreadsheetItems")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Domain.Entities.Common.Address", b =>
                {
                    b.HasOne("Domain.Entities.Bidding.AdditiveSpreadsheet", null)
                        .WithMany("Addresses")
                        .HasForeignKey("AdditiveSpreadsheetId");

                    b.HasOne("Domain.Entities.Bidding.Spreadsheet", "Spreadsheet")
                        .WithMany("Addresses")
                        .HasForeignKey("SpreadsheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Additive", b =>
                {
                    b.Navigation("AdditiveAgreements");

                    b.Navigation("AdditiveClauses");

                    b.Navigation("AdditiveSpreadsheet");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveLevel", b =>
                {
                    b.Navigation("AdditiveSpreadsheetItems");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.AdditiveSpreadsheet", b =>
                {
                    b.Navigation("AdditiveLevels");

                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Contract", b =>
                {
                    b.Navigation("Additives");

                    b.Navigation("BDIs");

                    b.Navigation("Clauses");

                    b.Navigation("ContractAgreements");

                    b.Navigation("ContractUsers");

                    b.Navigation("Spreadsheets");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Level", b =>
                {
                    b.Navigation("SpreadsheetItems");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.Source", b =>
                {
                    b.Navigation("Inputs");

                    b.Navigation("SourceItems");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.PriceReference.SourceItem", b =>
                {
                    b.Navigation("Inputs");
                });

            modelBuilder.Entity("Domain.Entities.Bidding.Spreadsheet", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Levels");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("AdditiveAgreements");

                    b.Navigation("Additives");

                    b.Navigation("ContractAgreements");

                    b.Navigation("Contracts");

                    b.Navigation("ContractUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
