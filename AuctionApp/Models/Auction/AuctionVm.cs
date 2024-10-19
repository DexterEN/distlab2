using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class AuctionVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndDate { get; set; }
    
    public string Description { get; set; }
    
    public string UserName { get; set; }

    public int MinPrice { get; set; }
    
    public static AuctionVm FromAuctions(Core.Auction auction)
    {
        return new AuctionVm()
        {
            Id = auction.Id,
            Title = auction.Title,
            EndDate = auction.EndDate,
            Description = auction.Description,
            UserName = auction.UserName,
            MinPrice = auction.MinPrice
        };
    }
    
    
}