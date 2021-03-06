﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioManager.Infrastructure;

namespace PortfolioManager.API.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20181201222316_AddAccountStatus")]
    partial class AddAccountStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.stockholdingseq", "'stockholdingseq', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.stockpriceseq", "'stockpriceseq', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.stockseq", "'stockseq', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.transactionseq", "'transactionseq', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:portfoliomanager.accountseq", "'accountseq', 'portfoliomanager', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "accountseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "portfoliomanager")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("accounts","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.AccountStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("accountstatus","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.StockHolding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "stockholdingseq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("BoughtDateTime");

                    b.Property<decimal>("BoughtPrice");

                    b.Property<decimal>("Commission");

                    b.Property<int>("StockId");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StockId");

                    b.ToTable("stockholdings","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "transactionseq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Commission");

                    b.Property<DateTime>("DateTime");

                    b.Property<decimal>("Price");

                    b.Property<int>("StockId");

                    b.Property<int>("TransactionTypeId");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StockId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("transactions","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("transactiontype","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.StockAggregate.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "stockseq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Symbol")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("stocks","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.StockAggregate.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "stockpriceseq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("DateTime");

                    b.Property<decimal>("Price");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("stockprices","portfoliomanager");
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account", b =>
                {
                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.AccountStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.StockHolding", b =>
                {
                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account")
                        .WithMany("StockHoldings")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortfolioManager.Domain.AggregatesModel.StockAggregate.Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Transaction", b =>
                {
                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortfolioManager.Domain.AggregatesModel.StockAggregate.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortfolioManager.Domain.AggregatesModel.AccountAggregate.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioManager.Domain.AggregatesModel.StockAggregate.StockPrice", b =>
                {
                    b.HasOne("PortfolioManager.Domain.AggregatesModel.StockAggregate.Stock")
                        .WithMany("StockPrices")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
