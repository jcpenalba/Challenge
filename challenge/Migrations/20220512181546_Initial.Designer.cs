﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using challenge.Models;

namespace challenge.Migrations
{
    [DbContext(typeof(AplicationDBContext))]
    [Migration("20220512181546_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("challenge.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("actor");
                });

            modelBuilder.Entity("challenge.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("genero");
                });

            modelBuilder.Entity("challenge.Models.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Alto")
                        .HasColumnType("int");

                    b.Property<int>("Ancho")
                        .HasColumnType("int");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("imagen");
                });

            modelBuilder.Entity("challenge.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duracion")
                        .HasColumnType("time(6)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PresupuestoUsd")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductoraId")
                        .HasColumnType("int");

                    b.Property<decimal>("Puntuacion")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("ProductoraId");

                    b.ToTable("pelicula");
                });

            modelBuilder.Entity("challenge.Models.PeliculaActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("pelicula_actor");
                });

            modelBuilder.Entity("challenge.Models.Productora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFundacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("productora");
                });

            modelBuilder.Entity("challenge.Models.Imagen", b =>
                {
                    b.HasOne("challenge.Models.Pelicula", "Pelicula")
                        .WithOne("Portada")
                        .HasForeignKey("challenge.Models.Imagen", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("challenge.Models.Pelicula", b =>
                {
                    b.HasOne("challenge.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("challenge.Models.Productora", "Productora")
                        .WithMany()
                        .HasForeignKey("ProductoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Productora");
                });

            modelBuilder.Entity("challenge.Models.PeliculaActor", b =>
                {
                    b.HasOne("challenge.Models.Actor", "Actor")
                        .WithMany("Peliculas")
                        .HasForeignKey("ActorId")
                        .IsRequired();

                    b.HasOne("challenge.Models.Pelicula", "Pelicula")
                        .WithMany("Actores")
                        .HasForeignKey("PeliculaId")
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("challenge.Models.Actor", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("challenge.Models.Pelicula", b =>
                {
                    b.Navigation("Actores");

                    b.Navigation("Portada");
                });
#pragma warning restore 612, 618
        }
    }
}
