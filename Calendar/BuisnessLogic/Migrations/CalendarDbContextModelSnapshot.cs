﻿// <auto-generated />
using System;
using BuisnessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuisnessLogic.Migrations
{
    [DbContext(typeof(CalendarDbContext))]
    partial class CalendarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RepeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RepeatId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Models.EventRepeat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Day")
                        .HasColumnType("bit");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<bool>("Month")
                        .HasColumnType("bit");

                    b.Property<int>("RepeatsCount")
                        .HasColumnType("int");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.Property<bool>("Week")
                        .HasColumnType("bit");

                    b.Property<bool>("Year")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Repeats");
                });

            modelBuilder.Entity("Models.EventTheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Models.Event", b =>
                {
                    b.HasOne("Models.EventRepeat", "Repeat")
                        .WithMany()
                        .HasForeignKey("RepeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.EventTheme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repeat");

                    b.Navigation("Theme");
                });
#pragma warning restore 612, 618
        }
    }
}
