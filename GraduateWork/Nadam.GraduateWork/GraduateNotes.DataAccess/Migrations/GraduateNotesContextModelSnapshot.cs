﻿// <auto-generated />
using System;
using GraduateNotes.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraduateNotes.DataAccess.Migrations
{
    [DbContext(typeof(GraduateNotesContext))]
    partial class GraduateNotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraduateNotes.DataAccess.Contracts.Models.NoteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Location");

                    b.Property<string>("Owner");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contracts.Models.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}