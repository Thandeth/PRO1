using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s15480Context : DbContext
    {
        public s15480Context()
        {
        }

        public s15480Context(DbContextOptions<s15480Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Rodzaj> Rodzaj { get; set; }
        public virtual DbSet<Skladniki> Skladniki { get; set; }
        public virtual DbSet<Szczegoly> Szczegoly { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieDostawca> ZamowienieDostawca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15480;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdministrator)
                    .HasColumnName("id_Administrator")
                    .ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.IdAdres)
                    .HasName("Adres_pk");

                entity.Property(e => e.IdAdres)
                    .HasColumnName("id_Adres")
                    .ValueGeneratedNever();

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu).HasColumnName("Nr_domu");

                entity.Property(e => e.NrMieszkania).HasColumnName("Nr_mieszkania");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawca)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.IdDostawca)
                    .HasColumnName("id_Dostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("data_zatrudnienia")
                    .HasColumnType("date");

                entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Dostawca)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dostawca_Osoba");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient)
                    .HasColumnName("id_Klient")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .IsRequired()
                    .HasColumnName("numer_telefonu")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Klient)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Klient_Osoba");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Persona_pk");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("id_Persona")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("id_Pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rodzaj>(entity =>
            {
                entity.HasKey(e => e.IdRodzaj)
                    .HasName("Rodzaj_pk");

                entity.Property(e => e.IdRodzaj)
                    .HasColumnName("id_Rodzaj")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPizza).HasColumnName("id_Pizza");

                entity.Property(e => e.IdSkladniki).HasColumnName("id_Skladniki");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Rodzaj)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rodzaj_Pizza");

                entity.HasOne(d => d.IdSkladnikiNavigation)
                    .WithMany(p => p.Rodzaj)
                    .HasForeignKey(d => d.IdSkladniki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rodzaj_Skladniki");
            });

            modelBuilder.Entity<Skladniki>(entity =>
            {
                entity.HasKey(e => e.IdSkladniki)
                    .HasName("Skladniki_pk");

                entity.Property(e => e.IdSkladniki)
                    .HasColumnName("id_Skladniki")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Szczegoly>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdZamowienie })
                    .HasName("Szczegoly_pk");

                entity.Property(e => e.IdPizza).HasColumnName("id_Pizza");

                entity.Property(e => e.IdZamowienie).HasColumnName("id_Zamowienie");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Szczegoly)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Szczegoly_Pizza");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.Szczegoly)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Szczegoly_Zamowienie");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("id_Zamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresIdAdres).HasColumnName("Adres_id_Adres");

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("data_zamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.KlientIdKlient).HasColumnName("Klient_id_Klient");

                entity.Property(e => e.Platnosc)
                    .IsRequired()
                    .HasColumnName("platnosc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uwagi)
                    .IsRequired()
                    .HasColumnName("uwagi")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdresIdAdresNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.AdresIdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Adres");

                entity.HasOne(d => d.KlientIdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientIdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");
            });

            modelBuilder.Entity<ZamowienieDostawca>(entity =>
            {
                entity.HasKey(e => new { e.IdDostawca, e.IdZamowienie })
                    .HasName("Zamowienie_dostawca_pk");

                entity.ToTable("Zamowienie_dostawca");

                entity.Property(e => e.IdDostawca).HasColumnName("id_Dostawca");

                entity.Property(e => e.IdZamowienie).HasColumnName("id_Zamowienie");

                entity.HasOne(d => d.IdDostawcaNavigation)
                    .WithMany(p => p.ZamowienieDostawca)
                    .HasForeignKey(d => d.IdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_dostawca_Dostawca");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.ZamowienieDostawca)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_dostawca_Zamowienie");
            });
        }
    }
}
