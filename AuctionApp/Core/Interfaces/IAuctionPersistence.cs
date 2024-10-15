namespace AuctionApp.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllOngoingAuctions(); 
    List<Auction> GetMyBidAuctions(string userName); 
    List<Auction> GetMyWonAuctions(string userName); 
    Auction GetAuctionById(int id);
    void Save(Auction auction);
    public void EditDescription(int id, String newDescription);
    
}