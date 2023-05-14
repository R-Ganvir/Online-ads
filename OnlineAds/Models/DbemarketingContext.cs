using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

public partial class DbemarketingContext : DbContext
{
    public DbemarketingContext()
    {
    }

    public DbemarketingContext(DbContextOptions<DbemarketingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=dbemarketing;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.Property(e => e.CatSubcatname).IsFixedLength();

            entity.HasOne(d => d.CatFkAdNavigation).WithMany(p => p.TblCategories).HasConstraintName("FK__tbl_categ__cat_f__276EDEB3");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasOne(d => d.ProFkCatNavigation).WithMany(p => p.TblProducts).HasConstraintName("FK__tbl_produ__pro_f__2E1BDC42");

            entity.HasOne(d => d.ProFkUserNavigation).WithMany(p => p.TblProducts).HasConstraintName("FK__tbl_produ__pro_f__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
