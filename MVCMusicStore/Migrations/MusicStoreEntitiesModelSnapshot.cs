﻿// <auto-generated />
using System;
using MVCMusicStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCMusicStore.Migrations
{
    [DbContext(typeof(MusicStoreEntities))]
    partial class MusicStoreEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MVCMusicStore.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlbumArtUrl")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Tab_Album");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Tab_Artist");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Cart", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CartId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.HasKey("RecordId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tab_Cart");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Tab_Genre");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Tab_Order");
                });

            modelBuilder.Entity("MVCMusicStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.HasIndex("OrderId");

                    b.ToTable("Tab_OrderDetail");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Tab_Usuario");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Album", b =>
                {
                    b.HasOne("MVCMusicStore.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCMusicStore.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Cart", b =>
                {
                    b.HasOne("MVCMusicStore.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MVCMusicStore.Models.OrderDetail", b =>
                {
                    b.HasOne("MVCMusicStore.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCMusicStore.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("MVCMusicStore.Models.Order", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Genre", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MVCMusicStore.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
