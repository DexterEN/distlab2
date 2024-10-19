namespace AuctionApp.Persistence;

using Microsoft.EntityFrameworkCore;


public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    public DbSet<BidDb> BidDbs { get; set; }
    public DbSet<AuctionDb> AuctionDbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AuctionDb adb = new AuctionDb
        {
            Id = -1, 
            Title = "Learn ASP.NET Core with MVC",
            EndDate = DateTime.Now,
            Description = "Bla bla",
            UserName = "anderslm@kth.se",
            Bids = new List<BidDb>(),
            MinPrice = 100
        };
        modelBuilder.Entity<AuctionDb>().HasData(adb);

        BidDb bid1 = new BidDb()
        {
            Id = -1,
            Amount = 100,
            UserName= "Jeff",
            Created = DateTime.Now,
            AuctionId = -1,
        };
        
        BidDb bid2 = new BidDb()
        {
            Id = -2,
            Amount = 200,
            UserName= "Steffe",
            Created = DateTime.Now,
            AuctionId = -1,
        };
        
        modelBuilder.Entity<BidDb>().HasData(bid1);
        modelBuilder.Entity<BidDb>().HasData(bid2);

    }
}