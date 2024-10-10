using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class AuctionsDetailsVm
{
    
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndDate { get; set; }
    
    public string Description { get; set; }
    
    public string UserName { get; set; }
    
    public List<BidVm> Bids { get; set; }
    
    
    public static AuctionsDetailsVm FromAuctions(Core.Auctions auctions)
    {
        var auctionsVm = new AuctionsDetailsVm()
        {
            Id = auctions.Id,
            Title = auctions.Title,
            EndDate = auctions.EndDate,
            Description = auctions.Description,
            UserName = auctions.UserName
        };
        foreach (var bid in auctions.Bids)
        {
            auctionsVm.Bids.Add(BidVm.FromBid(bid));
        }

        return auctionsVm;
    }
}