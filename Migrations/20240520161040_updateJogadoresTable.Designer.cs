﻿// <auto-generated />
using System;
using EFExemplo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace boardGame1._1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240520161040_updateJogadoresTable")]
    partial class updateJogadoresTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("boardGame.Carta", b =>
                {
                    b.Property<int>("CartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Custo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeckId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descrição")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EfeitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JogadorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Número")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PodeVirarTinta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Raridade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartaId");

                    b.HasIndex("DeckId");

                    b.HasIndex("EfeitoId");

                    b.HasIndex("JogadorId");

                    b.ToTable("Cartas");
                });

            modelBuilder.Entity("boardGame.Deck", b =>
                {
                    b.Property<int>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("boardGame.Efeito", b =>
                {
                    b.Property<int>("EfeitoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descrição")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PontosDeAtaque")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PontosDeDefesa")
                        .HasColumnType("INTEGER");

                    b.HasKey("EfeitoId");

                    b.ToTable("Efeitos");
                });

            modelBuilder.Entity("boardGame.Jogador", b =>
                {
                    b.Property<int>("JogadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeckId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JogoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JogoId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JogoId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("boardGame.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JogoId")
                        .HasColumnType("INTEGER");

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
