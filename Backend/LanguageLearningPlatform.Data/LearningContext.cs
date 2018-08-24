namespace LanguageLearningPlatform.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class LearningContext : IdentityDbContext<User>
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserSubsrcriptionDeck> UserSubsrcriptionDecks { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

        public LearningContext(DbContextOptions<LearningContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Card>()
                .HasOne(c => c.Deck)
                .WithMany(d => d.Cards)
                .HasForeignKey(c => c.DeckId);

            builder.Entity<Deck>()
                .HasOne(d => d.LanguageFrom)
                .WithMany(l => l.DecksFromLanguage)
                .HasForeignKey(d => d.LanguageFromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Deck>()
                .HasOne(d => d.LanguageTo)
                .WithMany(l => l.DecksToLanguage)
                .HasForeignKey(d => d.LanguageToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Deck>()
                .HasOne(d => d.Creator)
                .WithMany(c => c.UserCreatedDecks)
                .HasForeignKey(d => d.CreatorId);

            builder.Entity<UserSubsrcriptionDeck>()
                .HasKey(usd => new {usd.DeckId, usd.UserId});

            builder.Entity<Deck>()
                .HasMany(d => d.Subscribers)
                .WithOne(usd => usd.Deck)
                .HasForeignKey(usd => usd.DeckId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(u => u.UserSubscribedDecks)
                .WithOne(usd => usd.User)
                .HasForeignKey(usd => usd.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Statistic>()
                .HasKey(s => new
                {
                    s.CardId,
                    s.UserId,
                    s.DeckId
                });

            builder.Entity<Statistic>()
                .HasOne(s => s.Card)
                .WithMany(c => c.Statistics)
                .HasForeignKey(s => s.CardId);

            builder.Entity<Statistic>()
                .HasOne(s => s.Subscription)
                .WithMany(usd => usd.Statistics)
                .HasForeignKey(s => new
                {
                    s.DeckId,
                    s.UserId
                });

            base.OnModelCreating(builder);
        }
    }
}