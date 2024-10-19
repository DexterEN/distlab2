using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class CreateAuctionVm
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndDate { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "MinPrice must be greater than 0.")]
    public int MinPrice { get; set; }
    
}