namespace AuctionApp.Core;

public class Bid
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public string UserName { get; set; }
    public DateTime Created { get; set; }

    public Bid(string userName, DateTime created, int amount)
    {
        UserName = userName;
        Created = created;
        Amount = amount;
    }
    public Bid(int id, string userName, DateTime created, int amount)
    {
        Id = id;
        UserName = userName;
        Created = created;
        Amount = amount;
    }
}