using AuctionApp.Persistence;
using AutoMapper;


namespace AuctionApp.Mappers;

public class AuctionProfile : Profile
{
    public AuctionProfile()
    {
        CreateMap<AuctionDb, Action>().ReverseMap();
    }   
}