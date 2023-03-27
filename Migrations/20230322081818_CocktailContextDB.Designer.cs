﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpgaverApi.Sections.Contex;

#nullable disable

namespace OpgaverApi.Migrations
{
    [DbContext(typeof(CocktailContext))]
    [Migration("20230322081818_CocktailContextDB")]
    partial class CocktailContextDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CocktailIngredientCocktailRecipe", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.Property<int>("cocktailRecipesId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsId", "cocktailRecipesId");

                    b.HasIndex("cocktailRecipesId");

                    b.ToTable("CocktailIngredientCocktailRecipe");
                });

            modelBuilder.Entity("OpgaverApi.Sections.Entities.CocktailIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("OpgaverApi.Sections.Entities.CocktailRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("OpgaverApi.Sections.Entities.Quantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CocktailIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("CocktailRecipeId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CocktailIngredientId");

                    b.HasIndex("CocktailRecipeId");

                    b.ToTable("Quantities");
                });

            modelBuilder.Entity("CocktailIngredientCocktailRecipe", b =>
                {
                    b.HasOne("OpgaverApi.Sections.Entities.CocktailIngredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpgaverApi.Sections.Entities.CocktailRecipe", null)
                        .WithMany()
                        .HasForeignKey("cocktailRecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpgaverApi.Sections.Entities.Quantity", b =>
                {
                    b.HasOne("OpgaverApi.Sections.Entities.CocktailIngredient", "CocktailIngredient")
                        .WithMany()
                        .HasForeignKey("CocktailIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpgaverApi.Sections.Entities.CocktailRecipe", "CocktailRecipe")
                        .WithMany()
                        .HasForeignKey("CocktailRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CocktailIngredient");

                    b.Navigation("CocktailRecipe");
                });
#pragma warning restore 612, 618
        }
    }
}
