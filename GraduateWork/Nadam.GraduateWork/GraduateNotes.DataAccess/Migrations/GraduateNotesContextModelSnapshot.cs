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

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.EventMonitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<string>("EventTypeType");

                    b.Property<DateTime>("Occure");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("EventTypeType");

                    b.ToTable("MyProperty");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.EventType", b =>
                {
                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Type");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.ExceptionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExceptionTypeType");

                    b.Property<DateTime>("HappendOn");

                    b.Property<string>("Message");

                    b.HasKey("Id");

                    b.HasIndex("ExceptionTypeType");

                    b.ToTable("ExceptionLogs");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.ExceptionType", b =>
                {
                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Type");

                    b.ToTable("ExceptionTypes");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.NoteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileTitle");

                    b.Property<int>("OwnerId");

                    b.Property<string>("PublicUrl");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.NoteSharing", b =>
                {
                    b.Property<int>("OwnerId");

                    b.Property<int>("SharedWithId");

                    b.Property<int>("NoteId");

                    b.HasKey("OwnerId", "SharedWithId", "NoteId");

                    b.HasAlternateKey("NoteId", "OwnerId", "SharedWithId");

                    b.HasIndex("SharedWithId");

                    b.ToTable("NoteSharing");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NoteIdId");

                    b.Property<int?>("NotifiedId");

                    b.Property<DateTime>("Occur");

                    b.HasKey("Id");

                    b.HasIndex("NoteIdId");

                    b.HasIndex("NotifiedId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.EventMonitor", b =>
                {
                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.UserEntity", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeType");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.ExceptionLog", b =>
                {
                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.ExceptionType", "ExceptionType")
                        .WithMany()
                        .HasForeignKey("ExceptionTypeType");
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.NoteEntity", b =>
                {
                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.NoteSharing", b =>
                {
                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.NoteEntity", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.UserEntity", "SharedWith")
                        .WithMany()
                        .HasForeignKey("SharedWithId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GraduateNotes.DataAccess.Contract.Models.Notification", b =>
                {
                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.NoteEntity", "NoteId")
                        .WithMany()
                        .HasForeignKey("NoteIdId");

                    b.HasOne("GraduateNotes.DataAccess.Contract.Models.UserEntity", "Notified")
                        .WithMany()
                        .HasForeignKey("NotifiedId");
                });
#pragma warning restore 612, 618
        }
    }
}
