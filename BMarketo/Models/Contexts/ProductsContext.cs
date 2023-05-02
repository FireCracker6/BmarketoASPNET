using BMarketo.Models.Entities.Products;
using Microsoft.EntityFrameworkCore;
using static BMarketo.Models.Entities.Products.ReviewsEntity;

namespace BMarketo.Models.Contexts;


public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<ProductsEntity> Products { get; set; }
    public DbSet<ProductImagesEntity> ProductImages { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<CommentsEntity> Comments { get; set; }
    public DbSet<DescriptionEntity> AdditionalDescription { get; set; }
    public DbSet<AdditionalInfoEntity> AdditionalInfo { get; set; }
    public DbSet<ReviewsEntity> Reviews { get; set; }
    public DbSet<ShoppingDeliveryEntity> ShoppingDelivery { get; set; }

    public DbSet<ContactSubmissionEntity> ContactSubmissions { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);



        // Configure the "Products" table
        modelBuilder.Entity<ProductsEntity>()
            .ToTable("Products")
            .HasKey(p => p.Id);

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.SKUNumber)
            .HasMaxLength(20);

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.OldPrice)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<ProductsEntity>()
            .Property(p => p.Image);

        // Configure the "ProductImages" table
        modelBuilder.Entity<ProductImagesEntity>()
            .ToTable("ProductImages")
            .HasKey(p => p.Id);

        modelBuilder.Entity<ProductImagesEntity>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductImages)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductsEntity>()
      .HasMany(p => p.ProductImages)
      .WithOne(pi => pi.Product)
      .HasForeignKey(pi => pi.ProductId)
      .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductsEntity>()
       .HasOne(p => p.Category)
       .WithMany()
       .HasForeignKey(p => p.CategoryId)
       .IsRequired();

        modelBuilder.Entity<ProductsEntity>()
            .HasMany(p => p.Tags)
            .WithMany()
            .UsingEntity(j => j.ToTable("ProductTags"));

        modelBuilder.Entity<TagEntity>().HasData(
       new[]
       {
            new TagEntity { Id = 1, TagName = "TopSelling" },
            new TagEntity { Id = 2, TagName = "BestCollection" },
            new TagEntity { Id = 3, TagName = "Discounted" }
       });

        // Configure the "Comments" table
        modelBuilder.Entity<CommentsEntity>()
            .ToTable("Comments")
            .HasKey(c => c.Id);

        modelBuilder.Entity<CommentsEntity>()
            .Property(c => c.Username)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<CommentsEntity>()
            .Property(c => c.CommentText)
            .IsRequired();

        modelBuilder.Entity<CommentsEntity>()
            .HasOne(c => c.Product)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the "Descriptions" table
        modelBuilder.Entity<DescriptionEntity>()
            .ToTable("Descriptions")
            .HasKey(d => d.Id);

        modelBuilder.Entity<DescriptionEntity>()
            .HasOne(d => d.Product)
            .WithOne(p => p.AdditionalDescription)
            .HasForeignKey<DescriptionEntity>(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the "Additional Info" table
        modelBuilder.Entity<AdditionalInfoEntity>()
            .ToTable("AdditionalInfo")
            .HasKey(d => d.Id);

        modelBuilder.Entity<AdditionalInfoEntity>()
            .HasOne(d => d.Product)
            .WithOne(p => p.AdditionalInfo)
            .HasForeignKey<AdditionalInfoEntity>(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the "Reviews" table
        modelBuilder.Entity<ReviewsEntity>()
            .ToTable("ProductReviews")
            .HasKey(d => d.Id);

        modelBuilder.Entity<ReviewsEntity>()
            .HasOne(d => d.Product)
            .WithOne(p => p.Reviews)
            .HasForeignKey<ReviewsEntity>(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the "Shopping & Delivery" table
        modelBuilder.Entity<ShoppingDeliveryEntity>()
            .ToTable("ShoppingAndDelivery")
            .HasKey(d => d.Id);

        modelBuilder.Entity<ShoppingDeliveryEntity>()
            .HasOne(d => d.Product)
            .WithOne(p => p.ShoppingDelivery)
            .HasForeignKey<ShoppingDeliveryEntity>(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

    }

}
