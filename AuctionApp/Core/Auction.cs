namespace AuctionApp.Core;

public class Auction
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
    
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;
    
    public int MinPrice { get; set; }

    public Auction(string title, DateTime endDate, string description, string userName, int minPrice)
    {
        Title = title;
        EndDate = endDate;
        Description = description;
        UserName = userName;
        MinPrice = minPrice;
    }

    public Auction(int id, string title, DateTime endDate, string description, string userName, int minPrice)
    {
        Id = id;
        Title = title;
        EndDate = endDate;  
        Description = description;
        UserName = userName;
        MinPrice = minPrice;
    }
    
    public Auction( ){ }

    public void AddBid(Bid bid)
    {
        _bids.Add(bid);
    }

    public bool isOngiong()
    {
        return EndDate < DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Id}: {Title}: {Description} created by {UserName} ends: {EndDate}";
    }
    
}