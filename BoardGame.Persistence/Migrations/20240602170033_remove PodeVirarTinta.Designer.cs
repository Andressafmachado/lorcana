﻿// <auto-generated />
using System;
using EFExemplo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace boardGame1._1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240602170033_remove PodeVirarTinta")]
    partial class removePodeVirarTinta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("boardGame.Carta", b =>
                {
                    b.Property<int>("CartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CartaId"));

                    b.Property<int>("Cor")
                        .HasColumnType("integer");

                    b.Property<int>("Custo")
                        .HasColumnType("integer");

                    b.Property<int>("DeckId")
                        .HasColumnType("integer");

                    b.Property<string>("Descrição")
                        .HasColumnType("text");

                    b.Property<int?>("EfeitoId")
                        .HasColumnType("integer");

                    b.Property<int?>("JogadorId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Número")
                        .HasColumnType("integer");

                    b.Property<int>("Raridade")
                        .HasColumnType("integer");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("CartaId");

                    b.HasIndex("DeckId");

                    b.HasIndex("EfeitoId");

                    b.HasIndex("JogadorId");

                    b.ToTable("Cartas");
                });

            modelBuilder.Entity("boardGame.Deck", b =>
                {
                    b.Property<int?>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("DeckId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("boardGame.Efeito", b =>
                {
                    b.Property<int>("EfeitoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EfeitoId"));

                    b.Property<string>("Descrição")
                        .HasColumnType("text");

                    b.Property<int?>("PontosDeAtaque")
                        .HasColumnType("integer");

                    b.Property<int?>("PontosDeDefesa")
                        .HasColumnType("integer");

                    b.HasKey("EfeitoId");

                    b.ToTable("Efeitos");
                });

            modelBuilder.Entity("boardGame.Jogador", b =>
                {
                    b.Property<int>("JogadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JogadorId"));

                    b.Property<int>("DeckId")
                        .HasColumnType("integer");

                    b.Property<int>("JogoId")
                        .HasColumnType("integer");

                    b.Property<int?>("JogoId1")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("JogadorId");

                    b.HasIndex("DeckId");

                    b.HasIndex("JogoId");

                    b.HasIndex("JogoId1")
                        .IsUnique();

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("boardGame.Jogo", b =>
                {
                    b.Property<int>("JogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JogoId"));

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TurnoId")
                        .HasColumnType("integer");

                    b.HasKey("JogoId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("boardGame.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TurnoId"));

                    b.Property<int?>("JogoId")
                        .HasColumnType("integer");

                    b.HasKey("TurnoId");

                    b.HasIndex("JogoId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("boardGame.Carta", b =>
                {
                    b.HasOne("boardGame.Deck", "Deck")
                        .WithMany("Cartas")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("boardGame.Efeito", "Efeito")
                        .WithMany()
                        .HasForeignKey("EfeitoId");

                    b.HasOne("boardGame.Jogador", null)
                        .WithMany("CartasNaMão")
                        .HasForeignKey("JogadorId");

                    b.Navigation("Deck");

                    b.Navigation("Efeito");
                });

            modelBuilder.Entity("boardGame.Jogador", b =>
                {
                    b.HasOne("boardGame.Deck", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("boardGame.Jogo", "Jogos")
                        .WithMany("Jogadores")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("boardGame.Jogo", null)
                        .WithOne("JogadorNaVez")
                        .HasForeignKey("boardGame.Jogador", "JogoId1");

                    b.Navigation("Deck");

                    b.Navigation("Jogos");
                });

            modelBuilder.Entity("boardGame.Turno", b =>
                {
                    b.HasOne("boardGame.Jogo", null)
                        .WithMany("Turnos")
                        .HasForeignKey("JogoId");
                });

            modelBuilder.Entity("boardGame.Deck", b =>
                {
                    b.Navigation("Cartas");
                });

            modelBuilder.Entity("boardGame.Jogador", b =>
                {
                    b.Navigation("CartasNaMão");
                });

            modelBuilder.Entity("boardGame.Jogo", b =>
                {
                    b.Navigation("JogadorNaVez")
                        .IsRequired();

                    b.Navigation("Jogadores");

                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
