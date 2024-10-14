using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class AuctionService : IAuctionService
{
    private readonly IAuctionPersistence _auctionPersistence;

    
    public AuctionService(IAuctionPersistence auctionPersistence)
    {
        _auctionPersistence = auctionPersistence;
    }
    
    public List<Auction> GetAllOngoingAuctions()
    {
        List<Auction> auctions = _auctionPersistence.GetAllOngoingAuctions();
        return auctions;
    }

    public List<Auction> GetMyAuctions(string userName)
    {
        throw new NotImplementedException();
    }

    public List<Auction> GetMyWonAuctions(string userName)
    {
        throw new NotImplementedException();
    }

    public void AddAuction(string title, DateTime endDate, string description, string userName)
    {
        throw new NotImplementedException();
    }

    public void EditAuctionDescription(string title, string newDescription)
    {
        throw new NotImplementedException();
    }

    public void PlaceBid(string title, string userName, DateTime created, int amount)
    {
        throw new NotImplementedException();
    }
}