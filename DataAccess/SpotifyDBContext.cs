using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class SpotifyDBContext : DbContext
    {
        public SpotifyDBContext()
        {
        }

        public SpotifyDBContext(DbContextOptions<SpotifyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chartbusters> Chartbusters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=SpotifyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Chartbusters>(entity =>
            {
                entity.ToTable("chartbusters", "spotifydb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acousticness).HasColumnName("acousticness");

                entity.Property(e => e.Artists)
                    .HasColumnName("artists")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Danceability).HasColumnName("danceability");

                entity.Property(e => e.DurationMs)
                    .HasColumnName("duration_ms")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Energy).HasColumnName("energy");

                entity.Property(e => e.Instrumentalness).HasColumnName("instrumentalness");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Liveness).HasColumnName("liveness");

                entity.Property(e => e.Loudness).HasColumnName("loudness");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Speechiness).HasColumnName("speechiness");

                entity.Property(e => e.Tempo).HasColumnName("tempo");

                entity.Property(e => e.TimeSignature)
                    .HasColumnName("time_signature")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valence).HasColumnName("valence");
            });
        }
    }
}
