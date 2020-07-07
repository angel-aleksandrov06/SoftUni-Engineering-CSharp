namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using System;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(en =>
            {
                en.HasKey(t => t.TeamId);

                en.Property(t => t.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                en.Property(t => t.LogoUrl)
                .IsRequired(true)
                .IsUnicode(false);

                en.Property(t => t.Initials)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(3);

                en.Property(t => t.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

                en.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                en.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                en.HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TownId);
            });

            modelBuilder.Entity<Color>(en =>
            {
                en.HasKey(c => c.ColorId);

                en.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
            });

            modelBuilder.Entity<Town>(en =>
            {
                en.HasKey(t => t.TownId);

                en.Property(t => t.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                en.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
            });

            modelBuilder.Entity<Country>(en =>
            {
                en.HasKey(c => c.CountryId);

                en.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(en =>
            {
                en.HasKey(p => p.PlayerId);

                en.Property(p => p.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(80);

                en.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

                en.HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<Position>(en =>
            {
                en.HasKey(p => p.PositionId);

                en.Property(p => p.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
            });

            modelBuilder.Entity<PlayerStatistic>(en =>
            {
                en.HasKey(ps => new { ps.PlayerId, ps.GameId });

                en.HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

                en.HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);
            });

            modelBuilder.Entity<Game>(en =>
            {
                en.HasKey(g => g.GameId);

                en.Property(g => g.Result)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(7);

                en.HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                en.HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Bet>(en =>
            {
                en.HasKey(b => b.BetId);

                en.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

                en.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<User>(en =>
            {
                en.HasKey(u => u.UserId);

                en.Property(u => u.Username)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

                en.Property(u => u.Password)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(256);

                en.Property(u => u.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

                en.Property(u => u.Name)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(80);
            });
        }
    }
}
