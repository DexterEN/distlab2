using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class MockAuctionService : IAuctionService
{
    public List<Auctions> GetAllOngoingAuctions()
    {
        List<Auctions> auctions = new List<Auctions>();
        auctions.Add(new Auctions("Test", DateTime.Now, "TEST DESCRIPTION", "Dexter"));
        return auctions;
    }

    public List<Auctions> GetMyAuctions(string userName)
    {
        List<Auctions> auctions = new List<Auctions>();
        auctions.Add(new Auctions("bil", DateTime.Now, "bil DESCRIPTION", "Joel"));
        return auctions;
    }

    public List<Auctions> GetMyWonAuctions(string userName)
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