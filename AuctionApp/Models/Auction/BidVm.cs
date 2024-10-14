using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models;

public class BidVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public int Amount { get; set; }
    
    [Display(Name = "User name")]
    public string UserName { get; set; }
    
    [Display(Name = "Created date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime Created { get; set; }

    public static BidVm FromBid(Bid bid)
    {
        return new BidVm()
        {
            Id = bid.Id,
            Amount = bid.Amount,
            Created = bid.Created,
            UserName = bid.UserName
        };
    }
}