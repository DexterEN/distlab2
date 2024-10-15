using System.Data;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
   
        
        // GET: AuctionsController
        public ActionResult Index()
        { 
            List<Auction> auctions = _auctionService.GetAllOngoingAuctions();
           List<AuctionVm> auctionsVm = auctions
               .Select(a => AuctionVm.FromAuctions(a))
               .OrderBy(a => a.EndDate)  
               .ToList();
           
            return View(auctionsVm);
        }
        
        // GET: AuctionsController/MyBids/
        public ActionResult MyBids()
        { 
            List<Auction> auctions = _auctionService.GetMyAuctions(User.Identity.Name);
            List<AuctionVm> auctionsVm = auctions
                .Select(a => AuctionVm.FromAuctions(a))
                .OrderBy(a => a.EndDate)  
                .ToList();
           
            return View(auctionsVm);
        }
        
        // GET: AuctionsController/WonAuctions/
        public ActionResult WonAuctions()
        { 
            List<Auction> auctions = _auctionService.GetWonAuctions(User.Identity.Name);
            List<AuctionVm> auctionsVm = auctions
                .Select(a => AuctionVm.FromAuctions(a))
                .OrderBy(a => a.EndDate)  
                .ToList();
           
            return View(auctionsVm);
        }
        
        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            Auction a = _auctionService.GetAuctionByID(id);
            AuctionDetailsVm auctionDetailsVm = new AuctionDetailsVm();
            auctionDetailsVm = AuctionDetailsVm.FromAuctions(a);

            auctionDetailsVm.Bids = auctionDetailsVm.Bids
                .OrderByDescending(b => b.Amount)
                .ToList();
            
            return View(auctionDetailsVm);
        }

        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVm createAuctionVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _auctionService.AddAuction(createAuctionVm.Title,createAuctionVm.EndDate,createAuctionVm.Description, User.Identity.Name);
                    return RedirectToAction("Index");
                }
                return View(createAuctionVm);
            }
            catch(DataException ex)
            {
                return View(createAuctionVm);
            }
        }

        
        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            
            Auction a = _auctionService.GetAuctionByID(id);
            if (User.Identity.Name == a.UserName)
            {
                AuctionEditVm auctionEditVm = new AuctionEditVm();
                auctionEditVm = AuctionEditVm.FromAuctions(a);
            
                return View(auctionEditVm);
            }
            TempData["ErrorMessage"] = "You are not authorized to edit this auction.";
            return RedirectToAction("Index");
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuctionEditVm auctionEditVm)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    _auctionService.EditAuctionDescription(id, auctionEditVm.Description);
                    return RedirectToAction("Index");
                }

                return View(auctionEditVm);
            }
            catch
            {
                return View(auctionEditVm);
            }
        }
        
        // POST: AuctionsController/PlaceBid/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceBid(int auctionId, int bidAmount)
        {
            try
            {
                Auction a = _auctionService.GetAuctionByID(auctionId);
                if (User.Identity.Name == a.UserName)
                {
                    TempData["ErrorMessage"] = "Cant Bid on your own auction.";
                    return RedirectToAction("Details", new { id = auctionId });
                }
                
                var max = 0;
                if (a.Bids != null && a.Bids.Any())
                {
                    max = a.Bids.Max(b => b.Amount);
                }
                // Ensure the bid amount is valid
                if (bidAmount <= 0 || bidAmount < max)
                {
                    TempData["ErrorMessage"] = "Bid amount must be greater than 0 and current highest bid";
                    return RedirectToAction("Details", new { id = auctionId });
                }

                // Add the bid using the auction service
                _auctionService.PlaceBid(auctionId, User.Identity.Name, DateTime.Now ,bidAmount);

                return RedirectToAction("Details", new { id = auctionId });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                TempData["ErrorMessage"] = "An error occurred while placing your bid. "+ex.Message;
                return RedirectToAction("Details", new { id = auctionId });
            }
        }

    }
    
}
