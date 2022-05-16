﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUser.DAL;

#nullable disable

namespace WebUser.DAL.Migrations
{
    [DbContext(typeof(IESContext))]
    partial class IESContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebUser.DAL.Tables.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("brithDate")
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.HasKey("UserName");

                    b.ToTable("Alumnos");
                });
#pragma warning restore 612, 618
        }
    }
}
