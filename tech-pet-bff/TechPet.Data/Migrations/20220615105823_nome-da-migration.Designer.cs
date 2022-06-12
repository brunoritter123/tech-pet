﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechPet.Data.Context;

#nullable disable

namespace TechPet.Data.Migrations
{
    [DbContext(typeof(TechPetContext))]
    [Migration("20220615105823_nome-da-migration")]
    partial class nomedamigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TechPet.Domain.Entities.Empresas.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("TechPet.Domain.Entities.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("TechPet.Domain.Entities.Empresas.Empresa", b =>
                {
                    b.OwnsOne("TechPet.Domain.ValueObjects.CnpjObject.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("varchar(14)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.Navigation("Cnpj")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
