namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auctions> GetAllOngoingAuctions(); 
    
    List<Auctions> GetMyAuctions(string userName);
    
    List<Auctions> GetMyWonAuctions(string userName);
    
    void AddAuction(string title, DateTime endDate, string description, string userName);
    
    void EditAuctionDescription(string title, string newDescription);

    void PlaceBid(string title, string userName, DateTime created, int amount);
    
}