using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WpfApp001.EntityFramework;

public partial class szpitalContext : DbContext
{
    public szpitalContext()
    {
    }

    public szpitalContext(DbContextOptions<szpitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Funkcje> Funkcjes { get; set; }

    public virtual DbSet<Mailmessage> Mailmessages { get; set; }

    public virtual DbSet<Pacjenci> Pacjencis { get; set; }

    public virtual DbSet<Pomieszczenium> Pomieszczenia { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<TypyPom> TypyPoms { get; set; }

    public virtual DbSet<TypyWyd> TypyWyds { get; set; }

    public virtual DbSet<Urlopy> Urlopies { get; set; }

    public virtual DbSet<Uzytkownicy> Uzytkownicies { get; set; }

    public virtual DbSet<WydPacj> WydPacjs { get; set; }

    public virtual DbSet<WydPrac> WydPracs { get; set; }

    public virtual DbSet<Wydarzenium> Wydarzenia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Ensure correct path
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string connectionString = configuration.GetConnectionString("MyDbContext");

            optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Funkcje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("funkcje")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Nazwa, "nazwa_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(100)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Mailmessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("mailmessages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SenderId, "FK_mail1_idx");

            entity.HasIndex(e => e.ReceiverId, "FK_mail2_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.ReceiverId)
                .HasColumnType("int(11)")
                .HasColumnName("receiverId");
            entity.Property(e => e.SenderId)
                .HasColumnType("int(11)")
                .HasColumnName("senderId");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MailmessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mail2");

            entity.HasOne(d => d.Sender).WithMany(p => p.MailmessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mail1");
        });

        modelBuilder.Entity<Pacjenci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pacjenci")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Pesel, "pesel_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataRejestracji).HasColumnName("data_rejestracji");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.DataZgonu).HasColumnName("data_zgonu");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.Imie)
                .HasMaxLength(100)
                .HasColumnName("imie");
            entity.Property(e => e.Informacje)
                .HasMaxLength(500)
                .HasColumnName("informacje");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(100)
                .HasColumnName("nazwisko");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .HasColumnName("pesel");
        });

        modelBuilder.Entity<Pomieszczenium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pomieszczenia")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdTypyPom, "FK_pomieszczenia_typy_pom_idx");

            entity.HasIndex(e => e.Nazwa, "nazwa_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.Dostepnosc)
                .HasMaxLength(100)
                .HasColumnName("dostepnosc");
            entity.Property(e => e.IdTypyPom)
                .HasColumnType("int(11)")
                .HasColumnName("id_typy_pom");
            entity.Property(e => e.Komentarz)
                .HasMaxLength(200)
                .HasColumnName("komentarz");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .HasColumnName("nazwa");

            entity.HasOne(d => d.IdTypyPomNavigation).WithMany(p => p.Pomieszczenia)
                .HasForeignKey(d => d.IdTypyPom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pomieszczenia_typy_pom");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pracownicy")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdFunkcji, "FK_pracownicy_funkcje_idx");

            entity.HasIndex(e => e.Pesel, "pesel_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("dis");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdFunkcji)
                .HasColumnType("int(11)")
                .HasColumnName("id_funkcji");
            entity.Property(e => e.Imie)
                .HasMaxLength(100)
                .HasColumnName("imie");
            entity.Property(e => e.Medyczny)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("medyczny");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(100)
                .HasColumnName("nazwisko");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .HasColumnName("pesel");
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .HasColumnName("telefon");

            entity.HasOne(d => d.IdFunkcjiNavigation).WithMany(p => p.Pracownicies)
                .HasForeignKey(d => d.IdFunkcji)
                .HasConstraintName("FK_pracownicy_funkcje");
        });

        modelBuilder.Entity<TypyPom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("typy_pom")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Nazwa, "nazwa_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(100)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<TypyWyd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("typy_wyd")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdWymaganegoPom, "FK_typy_wyd_pomieszczenia_idx");

            entity.HasIndex(e => e.IdWymaganejFunk, "FK_typy_wyd_specjalizacje_idx");

            entity.HasIndex(e => e.Nazwa, "nazwa_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.IdWymaganegoPom)
                .HasColumnType("int(11)")
                .HasColumnName("id_wymaganego_pom");
            entity.Property(e => e.IdWymaganejFunk)
                .HasColumnType("int(11)")
                .HasColumnName("id_wymaganej_funk");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(100)
                .HasColumnName("nazwa");

            entity.HasOne(d => d.IdWymaganegoPomNavigation).WithMany(p => p.TypyWyds)
                .HasForeignKey(d => d.IdWymaganegoPom)
                .HasConstraintName("FK_typy_wyd_pomieszczenia");

            entity.HasOne(d => d.IdWymaganejFunkNavigation).WithMany(p => p.TypyWyds)
                .HasForeignKey(d => d.IdWymaganejFunk)
                .HasConstraintName("FK_typy_wyd_specjalizacje");
        });

        modelBuilder.Entity<Urlopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("urlopy")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdPracownicy, "FK_urlopy_pracownicy_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataRozpoczecia).HasColumnName("data_rozpoczecia");
            entity.Property(e => e.DataZakonczenia).HasColumnName("data_zakonczenia");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.IdPracownicy)
                .HasColumnType("int(11)")
                .HasColumnName("id_pracownicy");
            entity.Property(e => e.TypUrlopu)
                .HasMaxLength(100)
                .HasColumnName("typ_urlopu");

            entity.HasOne(d => d.IdPracownicyNavigation).WithMany(p => p.Urlopies)
                .HasForeignKey(d => d.IdPracownicy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_urlopy_pracownicy");
        });

        modelBuilder.Entity<Uzytkownicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("uzytkownicy")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdPracownika, "FK_uzytkownicy_pracownicy_idx");

            entity.HasIndex(e => e.Haslo, "haslo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasDefaultValueSql("'000'")
                .HasColumnType("tinyint(3) unsigned zerofill")
                .HasColumnName("dis");
            entity.Property(e => e.Haslo)
                .HasMaxLength(100)
                .HasColumnName("haslo");
            entity.Property(e => e.IdPracownika)
                .HasColumnType("int(11)")
                .HasColumnName("id_pracownika");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Medyczny)
                .HasColumnType("tinyint(4)")
                .HasColumnName("medyczny");

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Uzytkownicies)
                .HasForeignKey(d => d.IdPracownika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_uzytkownicy_pracownicy");
        });

        modelBuilder.Entity<WydPacj>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wyd_pacj")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdPacjenci, "wyd_pacj_pacjenci_idx");

            entity.HasIndex(e => e.IdWydarzenia, "wyd_pacj_wydarzenia_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.IdPacjenci)
                .HasColumnType("int(11)")
                .HasColumnName("id_pacjenci");
            entity.Property(e => e.IdWydarzenia)
                .HasColumnType("int(11)")
                .HasColumnName("id_wydarzenia");

            entity.HasOne(d => d.IdPacjenciNavigation).WithMany(p => p.WydPacjs)
                .HasForeignKey(d => d.IdPacjenci)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wyd_pacj_pacjenci");

            entity.HasOne(d => d.IdWydarzeniaNavigation).WithMany(p => p.WydPacjs)
                .HasForeignKey(d => d.IdWydarzenia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wyd_pacj_wydarzenia");
        });

        modelBuilder.Entity<WydPrac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wyd_prac")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdPracownicy, "FK_wyd_prac_pracownicy_idx");

            entity.HasIndex(e => e.IdWydarzenia, "FK_wyd_prac_wydarzenia_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.IdPracownicy)
                .HasColumnType("int(11)")
                .HasColumnName("id_pracownicy");
            entity.Property(e => e.IdWydarzenia)
                .HasColumnType("int(11)")
                .HasColumnName("id_wydarzenia");

            entity.HasOne(d => d.IdPracownicyNavigation).WithMany(p => p.WydPracs)
                .HasForeignKey(d => d.IdPracownicy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_wyd_prac_pracownicy");

            entity.HasOne(d => d.IdWydarzeniaNavigation).WithMany(p => p.WydPracs)
                .HasForeignKey(d => d.IdWydarzenia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_wyd_prac_wydarzenia");
        });

        modelBuilder.Entity<Wydarzenium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wydarzenia")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdPomieszczenia, "FK_wydarzenia_pomieszczenia_idx");

            entity.HasIndex(e => e.IdTypyWyd, "FK_wydarzenia_typy_wyd_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataICzas)
                .HasColumnType("datetime")
                .HasColumnName("data_i_czas");
            entity.Property(e => e.Dis)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dis");
            entity.Property(e => e.IdPomieszczenia)
                .HasColumnType("int(11)")
                .HasColumnName("id_pomieszczenia");
            entity.Property(e => e.IdTypyWyd)
                .HasColumnType("int(11)")
                .HasColumnName("id_typy_wyd");
            entity.Property(e => e.Opis)
                .HasMaxLength(500)
                .HasColumnName("opis");

            entity.HasOne(d => d.IdPomieszczeniaNavigation).WithMany(p => p.Wydarzenia)
                .HasForeignKey(d => d.IdPomieszczenia)
                .HasConstraintName("FK_wydarzenia_pomieszczenia");

            entity.HasOne(d => d.IdTypyWydNavigation).WithMany(p => p.Wydarzenia)
                .HasForeignKey(d => d.IdTypyWyd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_wydarzenia_typy_wyd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
