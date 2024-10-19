using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Persistence;

public class BidDb
{   
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Created { get; set; }
    
    [ForeignKey("AuctionId")]
    public AuctionDb AuctionDb { get; set; }
    
    public int AuctionId { get; set; }
}