using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserManageAPI.Models;

public partial class UserManageContext : DbContext
{
    public UserManageContext()
    {
    }

    public UserManageContext(DbContextOptions<UserManageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityInfo> CityInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=UserManage;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityInfo>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__CityInfo__F2D21B767B3D680E");

            entity.ToTable("CityInfo");

            entity.Property(e => e.CityName).HasMaxLength(20);
            entity.Property(e => e.Province).HasMaxLength(20);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC072E57DA31");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
