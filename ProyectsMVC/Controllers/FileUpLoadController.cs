using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class FileUpLoadController : Controller
    {
        // GET: FileUpLoad
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Upload()
        {
            var name = Request.Form["Name"];

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                //int fileSize = file.ContentLength;
                //string fileName = file.FileName;
                string mimeType = file.ContentType;
                //System.IO.Stream fileContent = file.InputStream;

                var guid = Guid.NewGuid();
                var ext = mimeType.Split('/').LastOrDefault();

                ViewBag.Guid = string.Format("{0}.{1}", guid, ext);

                file.SaveAs(Server.MapPath("~/Images/") +
                    string.Format("{0}.{1}", guid, ext));
            }
            return View("Index");
        }

    }
}