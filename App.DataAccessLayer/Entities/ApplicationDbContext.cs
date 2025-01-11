using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities
{
    public partial class ApplicationDbContext : DbContext,IApplicationDBContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Attachment> Attachments { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Parameter> Parameters { get; set; }

        public virtual DbSet<ParameterType> ParameterTypes { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<RedirectLink> RedirectLinks { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }


        public async Task<int> SaveChangesAsync()
        {
          return await  base.SaveChangesAsync();
        }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NexaEComDb;Integrated Security=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.Addresses).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Attachme__3214EC0775C41B7E");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.AssetUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.CollectionName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ConversionsDisk)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DeletedAt).HasColumnType("datetime");
                entity.Property(e => e.Disk)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.MimeType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.OriginalUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Size)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Brand__3214EC072A3C5887");

                entity.ToTable("Brand");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DeletedAt).HasColumnType("datetime");
                entity.Property(e => e.MetaDescription).HasMaxLength(500);
                entity.Property(e => e.MetaTitle).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Slug).HasMaxLength(255);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.BrandBanner).WithMany(p => p.BrandBrandBanners)
                    .HasForeignKey(d => d.BrandBannerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Attachments");

                entity.HasOne(d => d.BrandImage).WithMany(p => p.BrandBrandImages)
                    .HasForeignKey(d => d.BrandImageId)
                    .HasConstraintName("FK_Brand_Attachments1");

                entity.HasOne(d => d.BrandMetaImage).WithMany(p => p.BrandBrandMetaImages)
                    .HasForeignKey(d => d.BrandMetaImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Attachments2");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__3214EC078C25F8EF");

                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CommissionRate).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DeletedAt).HasColumnType("datetime");
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.MetaDescription).HasColumnType("text");
                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryIcon).WithMany(p => p.CategoryCategoryIcons)
                    .HasForeignKey(d => d.CategoryIconId)
                    .HasConstraintName("FK_Category_Attachments");

                entity.HasOne(d => d.CategoryImage).WithMany(p => p.CategoryCategoryImages)
                    .HasForeignKey(d => d.CategoryImageId)
                    .HasConstraintName("FK_Category_Attachments1");

                entity.HasOne(d => d.CategoryMetaImage).WithMany(p => p.CategoryCategoryMetaImages)
                    .HasForeignKey(d => d.CategoryMetaImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Attachments2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("Parameter");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
                entity.Property(e => e.EditedOn).HasColumnType("datetime");
                entity.Property(e => e.ParameterName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.ParameterNameN).HasMaxLength(500);

                entity.HasOne(d => d.ParameterType).WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.ParameterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parameter_ParameterType");
            });

            modelBuilder.Entity<ParameterType>(entity =>
            {
                entity.ToTable("ParameterType");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");
                entity.Property(e => e.ParameterTypeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.ParameterTypeNameN).HasMaxLength(200);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.Payments).HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<RedirectLink>(entity =>
            {
                entity.HasKey(e => e.Link).HasName("PK__Redirect__A26923802C4CB3E9");

                entity.ToTable("RedirectLink");

                entity.Property(e => e.Link)
                    .ValueGeneratedNever()
                    .HasColumnName("link");
                entity.Property(e => e.Linktype)
                    .HasMaxLength(500)
                    .HasColumnName("linktype");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FullName).HasMaxLength(250);
                entity.Property(e => e.UserName).HasDefaultValue("");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
