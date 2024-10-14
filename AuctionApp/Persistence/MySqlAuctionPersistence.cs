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
            .ToList(); 

        List<Auction> result = new List<Auction>();
        foreach(AuctionDb pdb in projectDbs)
        {
            Auction project = _mapper.Map<Auction>(pdb);
            result.Add(project);
        }

        return result;
    }
/*
    public Project GetById(int id, string userName)
    {
        ProjectDb? projectdb = _dbContext.ProjectDbs
            .Where(p => p.Id == id && p.UserName.Equals(userName))
            .Include(p => p.TaskDbs)
            .FirstOrDefault(); // null if not found!
        
        if (projectdb == null) throw new DataException("project not found");

        Project project = _mapper.Map<Project>(projectdb);
        foreach (TaskDb taskDb in projectdb.TaskDbs)
        {
            Task task = _mapper.Map<Task>(taskDb);
            project.AddTask(task);
        }

        return project;
    }

    public void Save(Project project)
    {
        throw new NotImplementedException("Save");
    }
    */
}