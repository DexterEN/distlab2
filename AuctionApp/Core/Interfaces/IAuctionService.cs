namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetAllOngoingAuctions(); 
    
    List<Auction> GetMyAuctions(string userName);
    Auction GetAuctionByID(int id);
    
    List<Auction> GetWonAuctions(string userName);
    
    void AddAuction(string title, DateTime endDate, string description, string userName);
    
    void EditAuctionDescription(int id, string newDescription);

    void PlaceBid(int id, string userName, DateTime created, int amount);
    
}