using System.Web.Mvc;

namespace Restaurants.Controllers
{
    public class CarouselController : Controller
    {
        public ActionResult Index()
        {

        }
        
        [HttpGet]
        public ActionResult UploadPhoto(FormCollection collection)
        {
            /*
            File entity = new File();
            FilesUploadVM model = new FilesUploadVM();
            PopulateViewModel(model, entity);
            return View(model);
            */
        }


        [HttpPost]
        public ActionResult UploadPhoto(FormCollection collection)
        {
            /*
            File entity = new File();
            FilesUploadVM model = new FilesUploadVM();
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    PopulateEntity(entity, model);
                    string filePath = System.IO.Path.Combine(Server.MapPath("~/Content/File"),
                        service.GetFileName(file.FileName));

                    entity.FilePath = filePath;
                    file.SaveAs(filePath);
                    service.Save(entity);
                    return RedirectToAction("Index");
                }
                return View("FileSizeError");
            }
            return View(model);
            */
        }

        public ActionResult DeletePhoto(int id)
        {
           /* 
            * File file = service.GetById(id);
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            service.Delete(file);

            return RedirectToAction("Index");
            */
        }
    }
}