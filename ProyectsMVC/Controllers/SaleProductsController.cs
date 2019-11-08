using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class SaleProductsController : Controller
    {
        // GET: SaleProducts
        public ActionResult Create()
        {
            Logica.BL.Categories categories = new Logica.BL.Categories();
            ViewBag.Categories = categories.GetCategories();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.SaleProductsCreateBindingModel model)
        {
            Logica.BL.Categories categories = new Logica.BL.Categories();
            ViewBag.Categories = categories.GetCategories();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            if (ModelState.IsValid)
            {
                //PARTE DEL FOR ES PARA CAPTURAR EL GUID DE LA IMAGEN A CARGAR
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    //int fileSize = file.ContentLength;
                    //string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    //System.IO.Stream fileContent = file.InputStream;

                    var guid = Guid.NewGuid();
                    var ext = mimeType.Split('/').LastOrDefault();
                    
                    //model.Photo = Convert.ToString(guid) + '.' + ext;
                    model.Photo = string.Format("{0}.{1}", guid, ext);
                    file.SaveAs(Server.MapPath("~/Images/Products/") +
                    string.Format("{0}.{1}", guid, ext));
                }

                Logica.BL.SaleDetails saleDetails = new Logica.BL.SaleDetails();
                saleDetails.CreateSaleProducts(model.Name,
                    model.Category,
                    model.Description,
                    model.Photo,
                    model.States,
                    model.Quantity,
                    model.Price,
                    model.ShippingCost,
                    model.Warranty);

                ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                          + "before you can log in.";

                return RedirectToAction("Create");
                
                
            }

            return View(model);
        }
    }


}