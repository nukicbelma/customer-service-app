using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class CustomerServiceAppDBContext : DbContext
    {
        public CustomerServiceAppDBContext()
        {
        }

        public CustomerServiceAppDBContext(DbContextOptions<CustomerServiceAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<Reward> Rewards { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OR40S9K;Initial Catalog=CustomerServiceAppDB;User ID=sa;Password=belma123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.HasIndex(e => e.EndDate, "IX_Campaign_EndDate");

                entity.HasIndex(e => e.StartDate, "IX_Campaign_StartDate");

                entity.Property(e => e.CampaignName).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Email, "IX_Customer_Email");

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D105342274EDBC")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "IX_Employee_Email");

                entity.HasIndex(e => e.UserId, "IX_Employee_UserId");

                entity.HasIndex(e => e.UserId, "UQ__Employee__1788CC4D28E1C4D9")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534FA7FBDA2")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__UserId__4316F928");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.HasIndex(e => e.Timestamp, "IX_Log_Timestamp");

                entity.HasIndex(e => e.UserId, "IX_Log_UserId");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Log__UserId__59FA5E80");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.HasIndex(e => e.CampaignId, "IX_Purchase_CampaignId");

                entity.HasIndex(e => e.CustomerId, "IX_Purchase_CustomerId");

                entity.HasIndex(e => e.PurchaseDate, "IX_Purchase_PurchaseDate");

                entity.Property(e => e.PurchaseAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__Purchase__Campai__5535A963");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__Custom__5441852A");
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.ToTable("Reward");

                entity.HasIndex(e => e.CampaignId, "IX_Reward_CampaignId");

                entity.HasIndex(e => e.CustomerId, "IX_Reward_CustomerId");

                entity.HasIndex(e => e.RewardDate, "IX_Reward_RewardDate");

                entity.Property(e => e.RewardAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RewardDate).HasColumnType("datetime");

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Rewards)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reward__Campaign__4F7CD00D");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rewards)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reward__Customer__5070F446");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B61607FBA4034")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

                entity.HasIndex(e => e.Username, "IX_User_Username");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4352A2422")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
