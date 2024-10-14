using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Persistence;

public class AuctionDb
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    
    [Required]
    [MaxLength(640)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string UserName { get; set; }
    
    public List<BidDb> Bids { get; set; } = new List<BidDb>();

}