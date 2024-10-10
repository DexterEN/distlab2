namespace AuctionApp.Core;

public class Auctions
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
    
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;

    public Auctions(string title, DateTime endDate, string description, string userName)
    {
        Title = title;
        EndDate = endDate;
        Description = description;
        UserName = userName;
    }

    public Auctions(int id, string title, DateTime endDate, string description, string userName)
    {
        Id = id;
        Title = title;
        EndDate = endDate;  
        Description = description;
        UserName = userName;
    }
    
    public Auctions( ){ }

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