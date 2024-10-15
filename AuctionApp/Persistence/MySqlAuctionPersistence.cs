using Microsoft.Build.Evaluation;

namespace AuctionApp.Persistence;
using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;

using Task = AuctionApp.Core.Bid;



public class MySqlAuctionPersistence : IAuctionPersistence
{
    private readonly AuctionDbContext _dbContext;
    private readonly IMapper _mapper;

    public MySqlAuctionPersistence(AuctionDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public List<Auction> GetAllOngoingAuctions()
    {
        var projectDbs = _dbContext.AuctionDbs
            .Where(a => a.EndDate > DateTime.Now).ToList(); 

        List<Auction> result = new List<Auction>();
        foreach(AuctionDb pdb in projectDbs)
        {
            Auction project = _mapper.Map<Auction>(pdb);
            result.Add(project);
        }

        return result;
    }

    public List<Auction> GetMyBidAuctions(string userName)
    {
        var projectDbs = _dbContext.AuctionDbs
            .Where(a => a.EndDate > DateTime.Now && a.Bids.Any(b => b.UserName == userName))
            .ToList(); 

        List<Auction> result = new List<Auction>();
        foreach(AuctionDb pdb in projectDbs)
        {
            Auction project = _mapper.Map<Auction>(pdb);
            result.Add(project);
        }

        return result;
    }

    public List<Auction> GetMyWonAuctions(string userName)
    {
        var projectDbs = _dbContext.AuctionDbs
            .Where(a => a.EndDate < DateTime.Now && 
                        a.Bids.Any() && 
                        a.Bids.OrderByDescending(b => b.Amount).FirstOrDefault().UserName == userName)
            .ToList(); 

        List<Auction> result = new List<Auction>();
        foreach(AuctionDb pdb in projectDbs)
        {
            Auction project = _mapper.Map<Auction>(pdb);
            result.Add(project);
        }

        return result;
    }

    public Auction GetAuctionById(int id)
    {
        var projectDbs = _dbContext.AuctionDbs.Where(a => a.Id == id).Include(a => a.Bids)
            .FirstOrDefault();
        if (projectDbs == null) throw new DataException("project not found");
        
        return _mapper.Map<Auction>(projectDbs);
    }

    public void EditDescription(int id, String newDescription)
    {
        AuctionDb adb = _dbContext.AuctionDbs.Find(id);
        adb.Description = newDescription;
        _dbContext.SaveChanges();
    }
    
    public void Save(Auction auction)
    {
        AuctionDb adb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDbs.Add(adb);
        _dbContext.SaveChanges();
    }
    
}