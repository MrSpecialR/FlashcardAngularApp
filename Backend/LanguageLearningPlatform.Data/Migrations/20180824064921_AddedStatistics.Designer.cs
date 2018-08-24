﻿// <auto-generated />
using System;
using LanguageLearningPlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LanguageLearningPlatform.Data.Migrations
{
    [DbContext(typeof(LearningContext))]
    [Migration("20180824064921_AddedStatistics")]
    partial class AddedStatistics
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LanguageLearningPlatform.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<int>("DeckId");

                    b.Property<string>("Hint");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Translation")
                        .IsRequired();

                    b.Property<string>("Word")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorId");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("Description");

                    b.Property<bool>("IsPublic");

                    b.Property<int>("LanguageFromId");

                    b.Property<int>("LanguageToId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PosterURL");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LanguageFromId");

                    b.HasIndex("LanguageToId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Statistic", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<string>("UserId");

                    b.Property<int>("DeckId");

                    b.Property<int>("CheckedTimes");

                    b.Property<int>("CorrectTimes");

                    b.Property<DateTime?>("LastCheckedOn");

                    b.HasKey("CardId", "UserId", "DeckId");

                    b.HasIndex("DeckId", "UserId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.UserSubsrcriptionDeck", b =>
                {
                    b.Property<int>("DeckId");

                    b.Property<string>("UserId");

                    b.HasKey("DeckId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSubsrcriptionDecks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Card", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.Deck", "Deck")
                        .WithMany("Cards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Deck", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.User", "Creator")
                        .WithMany("UserCreatedDecks")
                        .HasForeignKey("CreatorId");

                    b.HasOne("LanguageLearningPlatform.Models.Language", "LanguageFrom")
                        .WithMany("DecksFromLanguage")
                        .HasForeignKey("LanguageFromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LanguageLearningPlatform.Models.Language", "LanguageTo")
                        .WithMany("DecksToLanguage")
                        .HasForeignKey("LanguageToId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.Statistic", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.Card", "Card")
                        .WithMany("Statistics")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguageLearningPlatform.Models.UserSubsrcriptionDeck", "Subscription")
                        .WithMany("Statistics")
                        .HasForeignKey("DeckId", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LanguageLearningPlatform.Models.UserSubsrcriptionDeck", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.Deck", "Deck")
                        .WithMany("Subscribers")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LanguageLearningPlatform.Models.User", "User")
                        .WithMany("UserSubscribedDecks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguageLearningPlatform.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LanguageLearningPlatform.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
