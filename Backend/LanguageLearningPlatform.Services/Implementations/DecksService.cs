﻿namespace LanguageLearningPlatform.Services
{
    using System;
    using AutoMapper;
    using Data;
    using Exceptions;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using ServiceModels;
    using System.Collections.Generic;
    using System.Linq;

    public class DecksService : IDecksService
    {
        private readonly LearningContext db;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public DecksService(LearningContext db, IMapper mapper, IUsersService usersService)
        {
            this.db = db;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public DeckServiceModel GetById(int id, string userId)
        {
           var deck = this.db.Decks
               .Include(d => d.LanguageTo)
               .Include(d => d.LanguageFrom)
               .Include(d => d.Creator)
               .Include(d => d.Subscribers)
               .Include(d => d.Cards)
               .SingleOrDefault(d => d.Id == id);

            if (deck == null)
            {
                throw new ArgumentException("Deck does not exist!");
            }

            if (!deck.IsPublic && deck.CreatorId.CompareTo(userId) != 0 && !this.usersService.IsAdminByUserId(userId))
            {
                throw new AuthorizationException("You don't have the privilleges to view this.");
            }

            return new DeckServiceModel
            {
                Id = deck.Id,
                Name = deck.Name,
                Cards = deck.Cards.Count(),
                Creator = deck.Creator.UserName,
                Description = deck.Description,
                IsPublic = deck.IsPublic,
                LanguageFrom = deck.LanguageFrom.Name,
                LanguageTo = deck.LanguageTo.Name,
                PosterURL = deck.PosterURL,
                Subscribers = deck.Subscribers.Count(),
                IsUserSubscribed = deck.Subscribers.Any(s => s.UserId.CompareTo(userId) == 0)
            };
        }

        public IEnumerable<DeckServiceModel> GetByUser(string userId)
        {
            return this.db.Decks
                .Where(d => d.CreatorId == userId)
                .Include(d => d.LanguageTo)
                .Include(d => d.LanguageFrom)
                .Include(d => d.Creator)
                .Include(d => d.Subscribers)
                .Include(d => d.Cards)
                    .Select(d => new DeckServiceModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Cards = d.Cards.Count(),
                        Creator = d.Creator.UserName,
                        Description = d.Description,
                        IsPublic = d.IsPublic,
                        LanguageFrom = d.LanguageFrom.Name,
                        LanguageTo = d.LanguageTo.Name,
                        PosterURL = d.PosterURL,
                        Subscribers = d.Subscribers.Count(),
                        IsUserSubscribed = d.Subscribers.Any(s => s.UserId.CompareTo(userId) == 0)
                    }).ToList();
        }

        public IEnumerable<DeckServiceModel> AvailableDecksForUser(string userId)
        {
            return this.db.Decks.Where(d => d.IsPublic)
                .Where(d => d.CreatorId.CompareTo(userId) != 0)
                .Include(d => d.LanguageTo)
                .Include(d => d.LanguageFrom)
                .Include(d => d.Creator)
                .Include(d => d.Subscribers)
                .Include(d => d.Cards)
                .Select(d => new DeckServiceModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Cards = d.Cards.Count(),
                    Creator = d.Creator.UserName,
                    Description = d.Description,
                    IsPublic = d.IsPublic,
                    LanguageFrom = d.LanguageFrom.Name,
                    LanguageTo = d.LanguageTo.Name,
                    PosterURL = d.PosterURL,
                    Subscribers = d.Subscribers.Count(),
                    IsUserSubscribed = d.Subscribers.Any(s => s.UserId.CompareTo(userId) == 0)
                }).ToList();

        }

        public IEnumerable<DeckServiceModel> GetUserSubscriptions(string userId)
        {
            return this.db.UserSubsrcriptionDecks
                .Where(usd => usd.UserId == userId)
                .Select(usd => usd.Deck)
                .Include(d => d.LanguageTo)
                .Include(d => d.LanguageFrom)
                .Include(d => d.Creator)
                .Include(d => d.Subscribers)
                .Include(d => d.Cards)
                .Select(d => this.mapper.Map<Deck, DeckServiceModel>(d))
                .ToList();
        }

        public void SubscribeToDeck(string userId, int deckId)
        {
            var subscription =
                this.db.UserSubsrcriptionDecks.SingleOrDefault(usd => usd.UserId.CompareTo(userId) == 0 && deckId == usd.DeckId);
            if (subscription != null)
            {
                throw new ArgumentException("User is already subscribed to deck");
            }

            this.db.UserSubsrcriptionDecks.Add(
                new UserSubsrcriptionDeck
                {
                    DeckId = deckId,
                    UserId = userId
                }
            );

            this.db.SaveChanges();
        }

        public void UnsubscribeToDeck(string userId, int deckId)
        {
            var subscription =
                this.db.UserSubsrcriptionDecks.SingleOrDefault(usd => usd.UserId == userId && deckId == usd.DeckId);
            if (subscription == null)
            {
                throw new ArgumentException("User is not subscribed to deck");
            }

            this.db.UserSubsrcriptionDecks.Remove(subscription);

            this.db.SaveChanges();
        }


        public IEnumerable<DeckServiceModel> All()
        {
            return this.db.Decks
                .Where(d => d.IsPublic)
                .Include(d => d.LanguageTo)
                .Include(d => d.LanguageFrom)
                .Include(d => d.Creator)
                .Include(d => d.Subscribers)
                .Include(d => d.Cards)
                .Select(d => this.mapper.Map<Deck, DeckServiceModel>(d))
                .ToList();

        }

        public IEnumerable<DeckServiceModel> AllFromLanguage(string userId, string language)
        {
            return this.AvailableDecksForUser(userId)
                .Where(d => d.LanguageFrom.Contains(language))
                .ToList();
        }


        public IEnumerable<DeckServiceModel> AllToLanguage(string userId, string language)
        {
            return this.AvailableDecksForUser(userId)
                .Where(d => d.LanguageTo.Contains(language))
                .ToList();
        }

        public IEnumerable<DeckServiceModel> AllFromAndtoLanguage(string userId, string languageFrom, string languageTo)
        {
            return this.AvailableDecksForUser(userId)
                .Where(d => d.LanguageTo.Contains(languageTo)  && d.LanguageFrom.Contains(languageFrom))
                .ToList();
        }

        public int CreateDeck(int languageFromId, int languageToId, string creatorId, string name, string description, string posterUrl,
            bool isPublic = false)
        {
            var deck = new Deck
            {
                LanguageFromId = languageFromId,
                LanguageToId = languageToId,
                CreatorId = creatorId,
                Name = name,
                IsPublic = isPublic,
                PosterURL = posterUrl,
                Description = description
            };

            this.db.Decks.Add(
                deck
            );

            this.db.UserSubsrcriptionDecks.Add(new UserSubsrcriptionDeck
            {
                UserId = creatorId,
                Deck = deck
            });


            this.db.SaveChanges();

            return deck.Id;
        }

        public int EditDeck(int deckId, int languageFromId, int languageToId, string userId, string name, string description,
            string posterUrl, bool isPublic = false)
        {
            var deck = this.db.Decks.SingleOrDefault(d => d.Id == deckId);
            if (deck == null)
            {
                throw new ArgumentException("Deck does not exist");
            }

            bool isAdmin = this.usersService.IsAdminByUserId(userId);

            if (deck.CreatorId.CompareTo(userId) != 0 && !isAdmin)
            {
                throw new AuthorizationException("You don't have the privilleges to edit this.");
            }

            deck.LanguageToId = languageToId;
            deck.LanguageFromId = languageFromId;
            deck.Name = name;
            deck.Description = description;
            deck.PosterURL = posterUrl;
            deck.IsPublic = isPublic;

            this.db.SaveChanges();

            return deckId;
        }

        public void DeleteDeck(int id, string userId)
        {
            var deck = this.db.Decks.SingleOrDefault(d => d.Id == id);
            if (deck == null)
            {
                throw new ArgumentException("Deck does not exist");
            }

            bool isAdmin = this.usersService.IsAdminByUserId(userId);

            if (deck.CreatorId.CompareTo(userId) != 0 && !isAdmin)
            {
                throw new AuthorizationException("You don't have the privilleges to delete this.");
            }

            this.db.UserSubsrcriptionDecks.RemoveRange(
                this.db.UserSubsrcriptionDecks.Where(usd => usd.DeckId == id)
            );

            this.db.Decks.Remove(deck);
            this.db.SaveChanges();
        }
    }
}