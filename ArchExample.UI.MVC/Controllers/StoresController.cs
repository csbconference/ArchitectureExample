using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Services;
using ArchExample.UI.MVC.Models;

namespace ArchExample.UI.MVC.Controllers
{
    public class StoresController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoresController(ILogHelper logHelper, IStoreService storeService)
            : base(logHelper)
        {
            _storeService = storeService;
        }

        // GET: Stores
        public ActionResult Index()
        {
            try
            {
                int totalRecords;
                var stores = _storeService.Get(1, int.MaxValue, out totalRecords);
                var storesModel = new List<StoreModel>();
                foreach (var store in stores)
                {
                    storesModel.Add(new StoreModel
                    {
                        Id = store.Id,
                        Name = store.Name,
                        Address = store.Address
                    });
                }
                return View(storesModel);
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                return RedirectToAction("Error");
            }
        }
    }
}