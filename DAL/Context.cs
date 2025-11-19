using EL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context:IdentityDbContext<Kullanici, IdentityRole<int>, int >
    {
        public Context(DbContextOptions<Context> options) : base(options) { 
        
        }
        //public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Tedavi> Tedaviler { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<SaglikKaydi> SaglikKayitlari { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<Kullanici>(e =>
            {
                e.Property(x => x.AdSoyad).HasMaxLength(150).IsRequired();


                e.HasMany(x => x.Hayvanlar)
                 .WithOne(x => x.Sahip)
                 .HasForeignKey(x => x.SahipId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(x => x.Randevular)
                 .WithOne(x => x.Musteri)
                 .HasForeignKey(x => x.MusteriId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(x => x.Odemeler)
                 .WithOne(x => x.Musteri)
                 .HasForeignKey(x => x.MusteriId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<Hayvan>(e =>
            {
                e.Property(x => x.Ad).HasMaxLength(100).IsRequired();
                e.Property(x => x.Tur).HasMaxLength(50).IsRequired();
                e.Property(x => x.Cins).HasMaxLength(50);
                e.Property(x => x.Renk).HasMaxLength(50);

                e.Property(x => x.Cinsiyet)
                 .HasConversion<string>()
                 .HasMaxLength(20);

                e.HasIndex(x => new { x.SahipId, x.Ad });

                e.HasMany(x => x.Randevular)
                 .WithOne(x => x.Hayvan)
                 .HasForeignKey(x => x.HayvanId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<Randevu>(e =>
            {
                e.Property(x => x.Durum).HasConversion<string>().HasMaxLength(20);

                e.HasOne(x => x.Hayvan)
                 .WithMany(x => x.Randevular)
                 .HasForeignKey(x => x.HayvanId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Musteri)
                 .WithMany(x => x.Randevular)
                 .HasForeignKey(x => x.MusteriId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(x => x.RandevuZamani);
            });

            b.Entity<Tedavi>(e =>
            {
                e.Property(x => x.Ucret).HasPrecision(18, 2);

                e.HasOne(x => x.Randevu)
                 .WithMany(x => x.Tedaviler)
                 .HasForeignKey(x => x.RandevuId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            b.Entity<Odeme>(e =>
            {
                e.Property(x => x.Tutar).HasPrecision(18, 2);

                e.Property(x => x.Durum)
                 .HasConversion<string>()
                 .HasMaxLength(20);

                e.Property(x => x.OdemeYontemi)
                 .HasConversion<string>()
                 .HasMaxLength(20);

                e.HasOne(x => x.Randevu)
                 .WithMany(x => x.Odemeler)
                 .HasForeignKey(x => x.RandevuId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasIndex(x => new { x.MusteriId, x.OdemeTarihi });
            });

            b.Entity<SaglikKaydi>(e =>
            {
                e.HasOne(x => x.Hayvan)
                 .WithMany(x => x.SaglikKayitlari)
                 .HasForeignKey(x => x.HayvanId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Randevu)
                 .WithMany()
                 .HasForeignKey(x => x.RandevuId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            b.Entity<Fatura>(e =>
            {
                e.Property(x => x.ToplamTutar).HasPrecision(18, 2);
                e.Property(x => x.OdenenTutar).HasPrecision(18, 2);

                e.Property(x => x.Durum)
                 .HasConversion<string>()
                 .HasMaxLength(20);

                e.HasOne(x => x.Randevu)
                 .WithOne(x => x.Fatura)
                 .HasForeignKey<Fatura>(x => x.RandevuId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasIndex(x => x.RandevuId).IsUnique();

                e.Ignore(x => x.KalanTutar);
            });
        }


    }
}
