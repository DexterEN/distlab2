namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetAllOngoingAuctions(); 
    
    List<Auction> GetMyAuctions(string userName);
    Auction GetAuctionByID(int id);
    
    List<Auction> GetMyWonAuctions(string userName);
    
    void AddAuction(string title, DateTime endDate, string description, string userName);
    
    void EditAuctionDescription(int id, string newDescription);

    void PlaceBid(string title, string userName, DateTime created, int amount);
    
}