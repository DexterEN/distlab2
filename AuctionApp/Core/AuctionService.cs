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
        if (string.IsNullOrEmpty(userName))
        {
            throw new DataException("UserName can't be null or empty");
        }
        
        List<Auction> auctions =  _auctionPersistence.GetMyBidAuctions(userName);
        return auctions;
    }

    public Auction GetAuctionByID(int id)
    {
        Auction a = _auctionPersistence.GetAuctionById(id);
        return a;
    }

    public List<Auction> GetWonAuctions(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            throw new DataException("UserName can't be null or empty");
        }
        
        List<Auction> auctions =  _auctionPersistence.GetMyWonAuctions(userName);
        return auctions;
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

    public void EditAuctionDescription(int id, string newDescription)
    {
        if (newDescription == null)
        {
            throw new DataException("Description can't be null");
        }
        
        _auctionPersistence.EditDescription(id, newDescription);
    }

    public void PlaceBid(int id, string userName, DateTime created, int amount)
    {
        if (amount <0 || created == DateTime.MinValue || userName == null )
        {
            throw new DataException("Bid or UserName Cant't be null");
        }   
        _auctionPersistence.PlaceBid(id, userName, created, amount);
    }
}