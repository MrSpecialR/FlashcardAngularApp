using LanguageLearningPlatform.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearningPlatform.Services
{
    using AutoMapper;
    using Data;
    using Models;
    using ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardsService : ICardsService
    {
        private readonly LearningContext db;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public CardsService(LearningContext context, IMapper mapper, IUsersService usersService)
        {
            this.db = context;
            this.mapper = mapper;
            this.usersService = usersService;
        }


        public CardServiceModel GetCardById(int id, string userId)
        {
            var card = this.db.Cards.Include(c => c.Deck).SingleOrDefault(c => c.Id == id);

            if (card == null)
            {
                throw new ArgumentException("Card does not exist");
            }

            if (!card.Deck.IsPublic && card.Deck.CreatorId.CompareTo(userId) != 0 && !this.usersService.IsAdminByUserId(userId))
            {
                throw new AuthorizationException("You are unauthorized to view this card");
            }

            return this.mapper.Map<Card, CardServiceModel>(card);
        }

        public IEnumerable<CardServiceModel> GetCardsByDeckId(int deckId, string userId)
        {
            this.CheckIfDeckExists(deckId);

            var deck = this.db.Decks.Include(d => d.Cards).SingleOrDefault(d => d.Id == deckId);

            if (deck == null)
            {
                throw new ArgumentException("Deck does not exist");
            }

            if (!deck.IsPublic && deck.CreatorId.CompareTo(userId) != 0 && !this.usersService.IsAdminByUserId(userId))
            {
                throw new AuthorizationException("You are unauthorized to view this deck");
            }

            return deck.Cards.Select(c => this.mapper.Map<Card, CardServiceModel>(c))
                .ToList();
        }

        public int CreateCard(int deckId, string userId, string word, string translation, string hint, string imageUrl)
        {
            this.CheckIfDeckExists(deckId);

            var deck = this.db.Decks.Single(d => d.Id == deckId);
            bool isAdmin = this.usersService.IsAdminByUserId(userId);

            if (deck.CreatorId.CompareTo(userId) != 0 && !isAdmin)
            {
                throw new AuthorizationException("You don't have the permissions to add a card to this deck!");
            }

            var card = new Card
            {
                DeckId = deckId,
                Word = word,
                Translation = translation,
                Hint = hint,
                ImageUrl = imageUrl
            };

            this.db.Cards.Add(
                card
            );

            this.db.SaveChanges();
            return card.Id;
        }

        public int DeleteCard(int id, string userId)
        {
            var card = this.db.Cards.Include(c => c.Deck).SingleOrDefault(c => c.Id == id);

            if (card == null)
            {
                throw new ArgumentException("Card does not exist");
            }

            if (!card.Deck.IsPublic && card.Deck.CreatorId.CompareTo(userId) != 0 && !this.usersService.IsAdminByUserId(userId))
            {
                throw new AuthorizationException("You are unauthorized to edit this card");
            }

            this.db.Remove(card);
            this.db.SaveChanges();
            return card.DeckId;
        }

        public int EditCard(int id, string userId, string word, string translation, string hint, string imageUrl)
        {
            var card = this.db.Cards.Include(c => c.Deck).SingleOrDefault(d => d.Id == id);
            if (card == null)
            {
                throw new ArgumentException("Deck does not exist");
            }

            bool isAdmin = this.usersService.IsAdminByUserId(userId);

            if (card.Deck.CreatorId.CompareTo(userId) != 0 && !isAdmin)
            {
                throw new AuthorizationException("You don't have the privilleges to edit this.");
            }

            card.Word = word;
            card.Translation= translation;
            card.Hint = hint;
            card.ImageUrl = imageUrl;
            
            this.db.SaveChanges();

            return card.DeckId;
        }

        private void CheckIfDeckExists(int deckId)
        {
            var deck = this.db.Decks.SingleOrDefault(d => d.Id == deckId);

            if (deck == null)
            {
                throw new ArgumentException("Deck does not exist!");
            }
        }
    }
}