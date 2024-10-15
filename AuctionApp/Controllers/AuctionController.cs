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
            List<AuctionVm> auctionsVm = new List<AuctionVm>();
            foreach (var auction in auctions)
            {
                auctionsVm.Add(AuctionVm.FromAuctions(auction));
            }
            
            return View(auctionsVm);
        }

        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            Auction a = _auctionService.GetAuctionByID(id);
            AuctionDetailsVm auctionDetailsVm = new AuctionDetailsVm();
            auctionDetailsVm = AuctionDetailsVm.FromAuctions(a);
            
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

        /*
        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
    
        }
    */
    }
    
}
