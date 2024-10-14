namespace AuctionApp.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllOngoingAuctions(); 
    Auction GetAuctionById(int id);
}