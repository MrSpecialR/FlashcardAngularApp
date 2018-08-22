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

        public CardsService(LearningContext context, IMapper mapper)
        {
            this.db = context;
            this.mapper = mapper;
        }


        public CardServiceModel GetCardById(int id)
        {
            return this.mapper.Map<Card, CardServiceModel>(this.db.Cards.SingleOrDefault(c => c.Id == id));
        }

        public IEnumerable<CardServiceModel> GetCardsByDeckId(int deckId)
        {
            this.CheckIfDeckExists(deckId);


            return this.db.Cards.Where(c => c.DeckId == deckId).Select(c => this.mapper.Map<Card, CardServiceModel>(c))
                .ToList();
        }

        public int CreateCard(int deckId, string word, string translation, string hint, string imageUrl)
        {
            this.CheckIfDeckExists(deckId);

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