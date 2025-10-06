using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BitTech.Models;

public partial class Database : DbContext
{
    public Database()
    {
    }

    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<DetailRequest> DetailRequests { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connect = "Server=lordkuyq\\SQLEXPRESS;Database=byttech;Trusted_Connection=True; TrustServerCertificate=True";
        string connect_vki = "Server=dbsrv\\ag2024;Database=nikitinda_bittech;Trusted_Connection=True; TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connect_vki);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__client$__CB9A1CDFCA97298F");

            entity.ToTable("client$");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__comment$__CDDE91BD2DD3F890");

            entity.ToTable("comment$");

            entity.Property(e => e.CommentId).HasColumnName("commentID");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message");
            entity.Property(e => e.RequestId).HasColumnName("requestID");

            entity.HasOne(d => d.Master).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK_comment$_master$");

            entity.HasOne(d => d.Request).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_comment$_request$1");
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detail$__3214EC27E4693ADD");

            entity.ToTable("detail$");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<DetailRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detail_r__3213E83F8D78106A");

            entity.ToTable("detail_request$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DetailId).HasColumnName("detailID");
            entity.Property(e => e.RequestId).HasColumnName("requestID");

            entity.HasOne(d => d.Detail).WithMany(p => p.DetailRequests)
                .HasForeignKey(d => d.DetailId)
                .HasConstraintName("FK_detail_request$_detail$");

            entity.HasOne(d => d.Request).WithMany(p => p.DetailRequests)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_detail_request$_request$");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__equipmen__3214EC2710D4BFFE");

            entity.ToTable("equipment$");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.HomeTechModel)
                .HasMaxLength(255)
                .HasColumnName("homeTechModel");
            entity.Property(e => e.HomeTechType)
                .HasMaxLength(255)
                .HasColumnName("homeTechType");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__master$__3214EC2707544D48");

            entity.ToTable("master$");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__operator__3214EC27BD2976C7");

            entity.ToTable("operator$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__request$__E3C5DE51983EBD7C");

            entity.ToTable("request$");

            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.CompletionDate).HasColumnName("completionDate");
            entity.Property(e => e.EquipmentId).HasColumnName("equipmentID");
            entity.Property(e => e.ProblemDescryption)
                .HasMaxLength(255)
                .HasColumnName("problemDescryption");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(255)
                .HasColumnName("requestStatus");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_request$_client$1");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Requests)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_request$_equipment$");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
