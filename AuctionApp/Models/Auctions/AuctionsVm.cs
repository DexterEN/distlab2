using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class AuctionsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndDate { get; set; }
    
    public string Description { get; set; }
    
    public string UserName { get; set; }

    
    
    public static AuctionsVm FromAuctions(Core.Auctions auctions)
    {
        return new AuctionsVm()
        {
            Id = auctions.Id,
            Title = auctions.Title,
            EndDate = auctions.EndDate,
            Description = auctions.Description,
            UserName = auctions.UserName
        };
    }
    
    
}