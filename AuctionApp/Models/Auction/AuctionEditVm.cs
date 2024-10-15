using Microsoft.Build.Framework;

namespace AuctionApp.Models;

public class AuctionEditVm
{
    [Required]
    public string Description { get; set; }
    
    
    public static AuctionEditVm FromAuctions(Core.Auction auction)
    {
        var auctionsVm = new AuctionEditVm()
        {
         
            Description = auction.Description,
        
        };
       

        return auctionsVm;
    }
    
}