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

    public class StatisticsService : IStatisticsService
    {
        private readonly LearningContext db;
        private readonly IMapper mapper;

        public StatisticsService(LearningContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public CardUserStatisticsServiceModel GetUserCardStatistics(int deckId, int cardId, string userId)
        {
            var statistic = this.db.Statistics.SingleOrDefault(s =>
                s.UserId.CompareTo(userId) == 0 && deckId == s.DeckId && cardId == s.CardId);

            if (statistic == null)
            {
                throw new ArgumentException("Statistics for card not found, please test out more!");
            }

            return this.mapper.Map<Statistic, CardUserStatisticsServiceModel>(statistic);
        }

        public IEnumerable<CardUserStatisticsServiceModel> GetUserDeckStatistics(int deckId, string userId)
        {
            return this.db
                .Statistics
                .Where(s => s.UserId.CompareTo(userId) == 0
                            && s.DeckId == deckId)
                .Select(s => this.mapper.Map<Statistic, CardUserStatisticsServiceModel>(s))
                .ToList();
        }

        public IEnumerable<CardUserStatisticsServiceModel> GetUserGlobalStatistics(string userId)
        {
            return this.db
                .Statistics
                .Where(s => s.UserId.CompareTo(userId) == 0)
                .Select(s => this.mapper.Map<Statistic, CardUserStatisticsServiceModel>(s))
                .ToList();
        }

        public IEnumerable<CardUserStatisticsServiceModel> GetDeckGlobalStatistics(int deckId)
        {
            return this.db
                .Statistics
                .Where(s => s.DeckId == deckId)
                .Include(s => s.Card)
                .Select(s => this.mapper.Map<Statistic, CardUserStatisticsServiceModel>(s))
                .ToList();
        }

        public IEnumerable<CardUserStatisticsServiceModel> GetCardGlobalStatistics(int cardId)
        {
            return this.db
                .Statistics
                .Where(s => s.CardId == cardId)
                .Select(s => this.mapper.Map<Statistic, CardUserStatisticsServiceModel>(s))
                .ToList();
        }

        public void UpdateUserStatisticsForCard(int deckId, int cardId, string userId, bool isSuccessful)
        {

            var statistic = this.db.Statistics.SingleOrDefault(s =>
                s.UserId.CompareTo(userId) == 0 && deckId == s.DeckId && cardId == s.CardId);

            this.UpdateUserStatisticsForCardWithoutSaving(statistic, deckId, cardId, userId, isSuccessful);
            this.db.SaveChanges();
        }

        public void UpdateUserStatisticsForCardWithoutSaving(Statistic statistic, int deckId, int cardId, string userId, bool isSuccessful)
        {
            if (statistic == null)
            {
                statistic = new Statistic
                {
                    CardId = cardId,
                    UserId = userId,
                    DeckId = deckId,
                    CheckedTimes = 0,
                    CorrectTimes = 0
                };
                this.db.Statistics.Add(statistic);
            }

            if (isSuccessful)
            {
                statistic.CorrectTimes++;
            }

            statistic.CheckedTimes++;
            statistic.LastCheckedOn = DateTime.UtcNow;
        }

        public void UpdateUserStatisticsForCards(IEnumerable<StatisticsUpdateServiceModel> results)
        {
            var statistics = this.db.Statistics.Where(s =>
                results.Any(r => r.UserId.CompareTo(s.UserId) == 0 && r.CardId == s.CardId && r.DeckId == s.DeckId)).ToList();
            foreach (var statistic in results)
            {
                this.UpdateUserStatisticsForCardWithoutSaving(
                    statistics
                        .SingleOrDefault(s =>
                            s.UserId.CompareTo(statistic.UserId) == 0 &&
                            statistic.DeckId == s.DeckId &&
                            statistic.CardId == s.CardId)
                    ,
                    statistic.DeckId,
                    statistic.CardId,
                    statistic.UserId,
                    statistic.IsSuccessful
                    );
            }

            this.db.SaveChanges();
        }
    }
}