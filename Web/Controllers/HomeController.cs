using Business_Objects;
using Business_Objects.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment WebHost;
        public IWorkService<VNDDTL> Vendors { get; }
        public IWorkService<BILHDR> BillHeader { get; }
        public IWorkService<ITMDTL> Items { get; }
        public IWorkService<BILDTL> BillDetials { get; }
        public HomeController(IWorkService<VNDDTL> Vendors,
                              IWorkService<BILHDR> BillHeader,
                              IWorkService<ITMDTL> Items,
                               IWebHostEnvironment WebHost,
                              IWorkService<BILDTL> BillDetials)
        {
            this.WebHost = WebHost;
            this.Vendors = Vendors;
            this.BillHeader = BillHeader;
            this.Items = Items;
            this.BillDetials = BillDetials;
        }

       public IActionResult Index()
        {
            List<BILHDR_VM> model = new List<BILHDR_VM>();
            BillHeader.GetAll().ToList().ForEach(u =>
            {
                var VND_DTL = Vendors.GetById(u.BILCOD);
                BILHDR_VM BillHeader = new BILHDR_VM
                {
                    BILCOD=u.BILCOD,
                    BILDAT=u.BILDAT,
                    BILPRC=u.BILPRC,
                    BILIMG=u.BILIMG,
                    VNDNAM= VND_DTL.VNDNAM
                };
                model.Add(BillHeader);
            });
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateHDR(BILHDR_VM model )
        {
            
                if (model.File != null)
                {
                    string Uploads = Path.Combine(WebHost.WebRootPath, @"Img");
                    string FullPath = Path.Combine(Uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                    var Bill_Header = new BILHDR
                    {
                        BILCOD=model.BILCOD,
                        BILDAT=model.BILDAT,
                        BILPRC=model.BILPRC,
                        VNDCOD=model.VNDCOD,
                        BILIMG=model.File.FileName
                    
                    };
                    //Automapper
                     BillHeader.Insert(Bill_Header);
               
                    return Json("ADD Successfully");
                

            }
            return Json("ADD failed");
        }
        [HttpGet]
        public JsonResult GetAllVendors()
        {

            return Json(Vendors.GetAll().ToList());
        }



        // GET: Bill/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<BILDTI_VM> model = new List<BILDTI_VM>();
            BillDetials.GetAll().Where(x=>x.BILCOD==id).ToList().ForEach(b =>
            {
                var ITM_NAM = Items.GetById(b.ITMCOD);
                var BillDetials = new BILDTI_VM
                {
                    DTLCOD = b.DTLCOD,
                    ITMPRC = b.ITMPRC,
                    ITMQTY = b.ITMQTY,
                    ITMNAM = ITM_NAM.ITMNAM
                };
                model.Add(BillDetials);
            });

            var Bill_Full = new BILFULL_VM()
            {
                BIL_HDR = BillHeader.GetById(id),
                BILDTI_VM = model
             
        };

            if (Bill_Full == null)
            {
                return NotFound();
            }

            return View(Bill_Full);
        }
    }
}
