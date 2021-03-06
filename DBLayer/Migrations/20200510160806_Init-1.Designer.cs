﻿// <auto-generated />
using DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20200510160806_Init-1")]
    partial class Init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBLayer.Entityes.Content", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DirectiryId");

                    b.Property<string>("DirectoryId");

                    b.Property<string>("Html");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DBLayer.Entityes.Directory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Html");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Directory");
                });

            modelBuilder.Entity("DBLayer.Entityes.Content", b =>
                {
                    b.HasOne("DBLayer.Entityes.Directory", "Directory")
                        .WithMany("Books")
                        .HasForeignKey("DirectoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
