using Business_Objects;
using Business_Objects.Interfaces;
using Business_Objects.Interfaces.Services;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Reporting;
//using Web.Reporting;
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
        public IReposCaseHeader CaseHeader { get; }

        public HomeController(IWorkService<VNDDTL> Vendors,
                              IWorkService<BILHDR> BillHeader,
                              IWorkService<ITMDTL> Items,
                               IWebHostEnvironment WebHost,
                              IWorkService<BILDTL> BillDetials,
                              IReposCaseHeader CaseHeader)
        {
            this.WebHost = WebHost;
            this.Vendors = Vendors;
            this.BillHeader = BillHeader;
            this.Items = Items;
            this.BillDetials = BillDetials;
            this.CaseHeader = CaseHeader;
        }

       public IActionResult Index(string Search)
        {
            List<BILHDR_VM> model = new List<BILHDR_VM>();
            int reqid = Convert.ToInt32(Search);
            if (!string.IsNullOrEmpty(Search)) {
                 BillHeader.GetAll().Where(x=>x.BILCOD ==reqid).ToList().ForEach(u =>
                 {
                     var VND_DTL = Vendors.GetById(u.VNDCOD);
                     BILHDR_VM BillHeader = new BILHDR_VM
                     {
                         BILCOD = u.BILCOD,
                         BILDAT = u.BILDAT,
                         BILPRC = u.BILPRC,
                         BILIMG = u.BILIMG,
                         VNDNAM = VND_DTL.VNDNAM
                     };
                     model.Add(BillHeader);
                 });

                return View(model);
            }
            BillHeader.GetAll().ToList().ForEach(u =>
            {
                var VND_DTL = Vendors.GetById(u.VNDCOD);
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
        public JsonResult CreateHDR(BILHDR_VM model)
        {
            
                if (model.File != null&& model.VNDCOD != 0)
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
               
                    return Json(Bill_Header);
                

            }
            return Json("ADdedd failed");
        }

        [HttpGet]
        public JsonResult GetAllBillDetails(int id)
        {
            if (id != 0)
            {
                List<BILDTI_VM> model = new List<BILDTI_VM>();
                BillDetials.GetAll().Where(x => x.BILCOD == id).ToList().ForEach(b =>
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
              
            
            return Json(model);
        }
            return Json("NOT FUNOD");
        }
        [HttpGet]
        public JsonResult GetAllVendors()
        {

            return Json(Vendors.GetAll().ToList());
        }
        [HttpGet]
        public JsonResult GetvendoerById(int id)
        {

            return Json(Vendors.GetById(id));
        }
        [HttpGet]
        public JsonResult GetAllItems()
        {

            return Json(Items.GetAll().ToList());
        }

        public JsonResult GetLastHeaderBill()
        {

            return Json(BillHeader.GetAll().OrderBy(x => x.BILCOD).LastOrDefault());
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public JsonResult CreateBillDetials(BILDTI_VM model)
        {

            if (model != null)
            {
               
                var Bill_Detials = new BILDTL
                {
                   DTLCOD=model.DTLCOD,
                    ITMCOD=model.ITMCOD,
                    ITMPRC=model.ITMPRC,
                    ITMQTY=model.ITMQTY,
                    BILCOD= model.BILCOD
                };
                BillDetials.Insert(Bill_Detials);

                return Json( "BILL DETAILS CREATE SUCCessfully" );


            }
            return Json("ADdedd failed" );
        }

        [HttpPost]
        public ActionResult DeleteConfirmedJson(int id)
        {
            BillHeader.Delete(id);
            return Json(true);
        }
        public ActionResult DeleteBilDeltials(int id)
        {
            BillDetials.Delete(id);
            return Json(true);
        }


        [HttpPost]
        public JsonResult IsNameItemsAvailable(IsVaild isVaild)
        {
            List<BILDTI_VM> model = new List<BILDTI_VM>();
            BillDetials.GetAll().Where(x => x.BILCOD == isVaild.HIDCODe).ToList().ForEach(b =>
            {
                var ITM_NAM = Items.GetById(b.ITMCOD);
                var BillDetials = new BILDTI_VM
                {
                    DTLCOD = b.DTLCOD,
                    ITMPRC = b.ITMPRC,
                    ITMQTY = b.ITMQTY,
                    ITMNAM = ITM_NAM.ITMNAM,
                    ITMCOD= ITM_NAM.ITMCOD

                };
                model.Add(BillDetials);

            });
            bool x= !model.Any(x => x.ITMCOD == isVaild.ITMe);
            return Json(x);
        }
        [HttpGet]
        public JsonResult GetBilDetailsById(int id)
        {

            return Json(BillDetials.GetById(id));
        }

        [HttpPost]
        public JsonResult EditBillDetials(BILDTI_VM model)
        {

            if (model != null)
            {

                var Bill_Detials = new BILDTL
                { 
                    DTLCOD = model.DTLCOD,
                    ITMCOD = model.ITMCOD,
                    ITMPRC = model.ITMPRC,
                    ITMQTY = model.ITMQTY,
                    BILCOD = model.BILCOD
                };
                BillDetials.Update (Bill_Detials);

                return Json("BILL DETAILS Edit SUCCessfully");


            }
            return Json("Edit  failed");
        }

        public JsonResult GetHeaderBillByid(int id)
        {

            return Json(BillHeader.GetById(id));
        }
        [HttpPost]
        public JsonResult EditHDR(BILHDR_VM model)
        {

            if (model.File != null && model.VNDCOD != 0)
            {
                string Uploads = Path.Combine(WebHost.WebRootPath, @"Img");
                string FullPath = Path.Combine(Uploads, model.File.FileName);
                model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                var Bill_Header = new BILHDR
                {
                    BILCOD = model.BILCOD,
                    BILDAT = model.BILDAT,
                    BILPRC = model.BILPRC,
                    VNDCOD = model.VNDCOD,
                    BILIMG = model.File.FileName

                };
                //Automapper
                BillHeader.Update(Bill_Header);

                return Json(Bill_Header);


            }
            return Json("ADdedd failed");
        }

        [HttpPost]
        public JsonResult UPdatePrice(TotalPrice model)
        {

            if (model!= null )
            {

                int id = model.BILCOD;
                decimal price = model.BILPRC;

                CaseHeader.UpdateCase(id, price);
                return Json("succsed");


            }
            return Json("ADdedd failed");
        }

        public JsonResult GetValSearch(string Search)
        {
            int reqid = Convert.ToInt32(Search.Trim());

            var Bill = BillHeader.GetById(reqid);

            return Json ( Bill );
        }

        // [HttpPost]
        //public ActionResult Search(decimal? reqid)
        //{4



        //    var req = BillHeader.GetById(reqid);
        //    if (reqid.HasValue)
        //    {
        //        req = req.Where(s => s.REQ_NO.Equals(reqid));
        //    }
        //    return View(req);
        //}




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
            var BILh = BillHeader.GetById(id);
            var VND_DTL = Vendors.GetById(BILh.VNDCOD);


            var Bill_Full = new BILFULL_VM()
            {
                BIL_HDR = BillHeader.GetById(id),
                VNDNAM = VND_DTL.VNDNAM,
                BILDTI_VM = model
             
        };

            if (Bill_Full == null)
            {
                return NotFound();
            }

            return View(Bill_Full);
        }



        public IActionResult Viewer(int id)
        {
            PrintBills rep = new PrintBills();
            rep.Parameters["parameter1"].Value = id;
            //Parameter param1 = new Parameter();
            //param1.Name = "parameter1";
            //param1.Type = typeof(System.Int32);
            //param1.Value = id;
            //rep.Parameters.Add(param1);
            return View(rep);
        }
        //public ActionResult BillingPrint(int Id)
        //{

        //    XtraReport rep = new XtraReport();
        //    rep = BillingPrintReport(Id);

        //   // ReportViewerExtension.ExportTo(rep, Request);
        //    return View(rep);
        //}


        //protected XtraReport BillingPrintReport(int  Id)
        //{
        //    BillingPrint rep = new BillingPrint();
        //    return rep;

        //}


    }
}
