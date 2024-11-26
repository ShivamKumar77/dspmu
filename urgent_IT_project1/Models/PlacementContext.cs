using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace urgent_IT_project1.Models
{
    public partial class PlacementContext : DbContext
    {
        public PlacementContext()
        {
        }

        public PlacementContext(DbContextOptions<PlacementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CDescrip1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("C_Descrip1");

                entity.Property(e => e.CDescrip2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("C_Descrip2");

                entity.Property(e => e.CDuration)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("C_Duration");

                entity.Property(e => e.CImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_Image");

                entity.Property(e => e.CName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("C_Name");

                entity.Property(e => e.CPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("C_Price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
