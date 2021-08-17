using Microsoft.EntityFrameworkCore;

namespace ApiProject.Models
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<PossibleProject> PossibleProjects { get; set; }
        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.HasIndex(e => e.Id, "UQ_Distribution_ID")
                    .IsUnique();

                entity.HasIndex(e => new { e.WorkerId, e.ProjectId, e.DateStart }, "uc_Person")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateStart)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Start");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Distributions)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Distributions)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PossibleProject>(entity =>
            {
                entity.HasIndex(e => e.Id, "UQ_PossibleProjects_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.PossibleProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.PossibleProjects)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.ProjectId, "UQ_Report_Project_Project_ID")
                    .IsUnique();

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Project_name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.Property(e => e.WorkerPosition)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Worker_Position");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._11).HasColumnName("11");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._13).HasColumnName("13");

                entity.Property(e => e._14).HasColumnName("14");

                entity.Property(e => e._15).HasColumnName("15");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._17).HasColumnName("17");

                entity.Property(e => e._18).HasColumnName("18");

                entity.Property(e => e._19).HasColumnName("19");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._21).HasColumnName("21");

                entity.Property(e => e._22).HasColumnName("22");

                entity.Property(e => e._23).HasColumnName("23");

                entity.Property(e => e._24).HasColumnName("24");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._26).HasColumnName("26");

                entity.Property(e => e._27).HasColumnName("27");

                entity.Property(e => e._28).HasColumnName("28");

                entity.Property(e => e._29).HasColumnName("29");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._31).HasColumnName("31");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._9).HasColumnName("9");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasIndex(e => e.WorkerId, "UQ_Workers_Worker_ID")
                    .IsUnique();

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.Property(e => e.WorkerFio)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Worker_FIO");

                entity.Property(e => e.WorkerPosition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Worker_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}