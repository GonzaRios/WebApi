using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServicioWebApi.Models;

namespace ServicioWebApi.Data
{
    public partial class pubsContext : DbContext
    {
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }

        public pubsContext(DbContextOptions<pubsContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<publisher>(entity =>
            {
                entity.HasKey(e => e.pub_id)
                    .HasName("UPKCL_pubind");

                entity.Property(e => e.pub_id)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.city).IsUnicode(false);

                entity.Property(e => e.country)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.pub_name).IsUnicode(false);

                entity.Property(e => e.state)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
