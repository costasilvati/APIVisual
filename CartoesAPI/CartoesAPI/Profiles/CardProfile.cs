using System;
using AutoMapper;
using CartoesAPI.Data.Dtos;
using CartoesAPI.Model;

namespace CartoesAPI.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CreateCardDto, Card>();
            CreateMap<Card, ReadCardDto>();
            CreateMap<UpdateCardDto, Card>();
        }
    }
}
