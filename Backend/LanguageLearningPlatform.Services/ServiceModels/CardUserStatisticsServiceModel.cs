using AutoMapper;

namespace LanguageLearningPlatform.Services.ServiceModels
{
    using System;
    using Models;
    using Infrastructure;


    public class CardUserStatisticsServiceModel : ICustomMapConfiguration
    {
        public CardServiceModel Card { get; set; }

        public decimal Accuracy
        {
            get { return 100.0M * this.CorrectTimes / this.CheckedTimes; }
        }

        public DateTime? LastCheckedOn { get; set; }

        public int CheckedTimes { get; set; }

        public int CorrectTimes { get; set; }
        public void ConfigureMap(Profile profile)
        {
            profile.CreateMap<Statistic, CardUserStatisticsServiceModel>()
                .ForMember(m => m.Card, cfg => cfg.MapFrom(c => c.Card));
        }
    }
}