using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class AuctionDetailsVm
{
    
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndDate { get; set; }
    
    public string Description { get; set; }
    
    public string UserName { get; set; }
    
    public List<BidVm> Bids { get; set; } = new ();
    
    public int MinPrice { get; set; }

    
    
    public static AuctionDetailsVm FromAuctions(Core.Auction auction)
    {
        var auctionsVm = new AuctionDetailsVm()
        {
            Id = auction.Id,
            Title = auction.Title,
            EndDate = auction.EndDate,
            Description = auction.Description,
            UserName = auction.UserName,
            MinPrice = auction.MinPrice
        };
        foreach (var bid in auction.Bids)
        {
            auctionsVm.Bids.Add(BidVm.FromBid(bid));
        }

        return auctionsVm;
    }
}