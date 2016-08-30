namespace Restaurants.Controllers
{
    using System;
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ViewModels.Carousel;
    using Restautants.ViewModels.Carousel;
    using Filter;

    [AdminAuthentication]
    public class CarouselController : BaseController<CarouselEntity, CarouselEditVM, CarouselListVM, CarouselFilterVM>
    {
        public override BaseRepository<CarouselEntity> CreateRepository()
        {
            return new CarouselRepository();
        }

        public override void PopulateEntity(CarouselEntity entity, CarouselEditVM model)
        {
            entity.ImageUrl = model.ImageUrl;
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.CreateTime = DateTime.Now;
        }

        public override void PopulateModel(CarouselEditVM model, CarouselEntity entity)
        {
            model.ImageUrl = entity.ImageUrl;
            model.Title = entity.Title;
            model.Description = entity.Description;
            model.CreateTime = entity.CreateTime;
        }
        
        //public ActionResult Index()
        //{

        //}

        //[HttpGet]
        //public ActionResult UploadPhoto(FormCollection collection)
        //{
        //    /*
        //    File entity = new File();
        //    FilesUploadVM model = new FilesUploadVM();
        //    PopulateViewModel(model, entity);
        //    return View(model);
        //    */
        //}


        //[HttpPost]
        //public ActionResult UploadPhoto(FormCollection collection)
        //{
        //    /*
        //    File entity = new File();
        //    FilesUploadVM model = new FilesUploadVM();
        //    TryUpdateModel(model);
        //    if (ModelState.IsValid)
        //    {
        //        if (file != null)
        //        {
        //            PopulateEntity(entity, model);
        //            string filePath = System.IO.Path.Combine(Server.MapPath("~/Content/File"),
        //                service.GetFileName(file.FileName));

        //            entity.FilePath = filePath;
        //            file.SaveAs(filePath);
        //            service.Save(entity);
        //            return RedirectToAction("Index");
        //        }
        //        return View("FileSizeError");
        //    }
        //    return View(model);
        //    */
        //}

        //public ActionResult DeletePhoto(int id)
        //{
        //   /* 
        //    * File file = service.GetById(id);
        //    if (System.IO.File.Exists(file.FilePath))
        //    {
        //        System.IO.File.Delete(file.FilePath);
        //    }
        //    service.Delete(file);

        //    return RedirectToAction("Index");
        //    */
        //}
    }
}