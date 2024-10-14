using System.Data;
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

    public Auction GetAuctionByID(int id)
    {
        Auction a = _auctionPersistence.GetAuctionById(id);
        return a;
    }

    public List<Auction> GetMyWonAuctions(string userName)
    {
        throw new NotImplementedException();
    }

    public void AddAuction(string title, DateTime endDate, string description, string userName)
    {
        if ( title == "" || endDate == null || endDate == DateTime.MinValue || userName == null)
        {
            throw new DataException("Auction title, UserName and end date can't be null");
        }
        Auction auction = new Auction(title, endDate, description, userName);
        _auctionPersistence.Save(auction);
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