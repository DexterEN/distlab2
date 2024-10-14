using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class MockAuctionService : IAuctionService
{
    public List<Auction> GetAllOngoingAuctions()
    {
        List<Auction> auctions = new List<Auction>();
        auctions.Add(new Auction("Test", DateTime.Now, "TEST DESCRIPTION", "Dexter"));
        return auctions;
    }

    public List<Auction> GetMyAuctions(string userName)
    {
        List<Auction> auctions = new List<Auction>();
        auctions.Add(new Auction("bil", DateTime.Now, "bil DESCRIPTION", "Joel"));
        auctions[0].AddBid(new Bid(1, "1", DateTime.Now, 100));
        auctions[0].AddBid(new Bid(1,"1", DateTime.Now, 101));
        auctions[0].AddBid(new Bid(1,"1", DateTime.Now, 102));
        return auctions;
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