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
            throw new DataException("UserName can't be null or empty.");
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
            throw new DataException("UserName can't be null or empty.");
        }
        
        List<Auction> auctions =  _auctionPersistence.GetMyWonAuctions(userName);
        return auctions;
    }

    public void AddAuction(string title, DateTime endDate, string description, string userName, int minPrice)
    {
        if (minPrice <= 0) { throw new DataException("Min price can't be less than or equal to 0."); }
        
        if (endDate == DateTime.MinValue) { throw new DataException("EndDate can't be min value."); }
        
        if (string.IsNullOrEmpty(title) || userName == null || description == null) { throw new DataException("Auction title, UserName, Descrtiption and end date can't be null."); }
        
        Auction auction = new Auction(title, endDate, description, userName, minPrice);
        _auctionPersistence.Save(auction);
    }

    public void EditAuctionDescription(int id, string newDescription)
    {
        if (newDescription == null)
        {
            throw new DataException("Description can't be null.");
        }
        
        _auctionPersistence.EditDescription(id, newDescription);
    }

    public void PlaceBid(int id, string userName, DateTime created, int amount)
    {
        if (created == DateTime.MinValue) { throw new DataException("Created can't be min value."); }
        
        if (amount <= 0) { throw new DataException("Amount cant't be less than or equal to 0."); }
        
        if ( userName == null ) { throw new DataException("UserName Cant't be null."); }   
        
        _auctionPersistence.PlaceBid(id, userName, created, amount);
    }
}