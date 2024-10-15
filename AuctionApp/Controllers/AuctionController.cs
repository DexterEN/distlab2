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

        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            Auction a = _auctionService.GetAuctionByID(id);
            AuctionDetailsVm auctionDetailsVm = new AuctionDetailsVm();
            auctionDetailsVm = AuctionDetailsVm.FromAuctions(a);

            auctionDetailsVm.Bids
                .OrderBy(b => b.Amount)
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

    }
    
}
