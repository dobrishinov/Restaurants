namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using ViewModels;

    public abstract class BaseController<T, EVM, IVM, F> : Controller
        // T - Entity
        where T : BaseEntity, new()
        //Edit - one element
        where EVM : BaseEditVM, new()
        // Filter
        where F : BaseFilterVM<T>, new()
        //Index - all elements
        where IVM : BaseListVM<T, F>, new()
    {
        public BaseController()
        {
            this.Repository = CreateRepository();
        }

        protected BaseRepository<T> Repository = null;
        public abstract BaseRepository<T> CreateRepository();
        public abstract void PopulateModel(EVM model, T entity);
        public abstract void PopulateEntity(T entity, EVM model);
        protected Expression<Func<T, bool>> Filter { get; set; }
        
        public virtual ActionResult RedirectTo(T entity)
        {
            return RedirectToAction("Index");
        }

        protected virtual void BeforeList(IVM model) { }

        // GET: Base
        public virtual ActionResult Index()
        {
            //if (AuthenticationManager.LoggedUser == null)
            //    return RedirectToAction("Login", "Account");

            IVM model = new IVM();
            TryUpdateModel(model);
            model.Items = Repository.GetAll(model.Filter.BuildFilter()).ToList();

            BeforeList(model);

            //Pager
            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Pager = new Pager(Repository.GetAll(model.Filter.BuildFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            //Filter
            model.Filter.ParentPager = model.Pager;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Account");

            T entity = (id == null || id <= 0) ? new T() : Repository.GetById(id);
            EVM model = new EVM();
            PopulateModel(model, entity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Account");

            EVM model = new EVM();
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                T entity = (model.Id <= 0) ? new T() : Repository.GetById(model.Id);
                PopulateEntity(entity, model);
                Repository.Save(entity);
                return RedirectTo(entity);
            }
            return View(model);

        }

        public ActionResult Details (int id)
        {
            EVM model = new EVM();
            if (ModelState.IsValid)
            {
                T entity = Repository.GetById(id);
                PopulateModel(model, entity);
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Account");


            T entity = Repository.GetById(id);
            Repository.Delete(entity);

            return RedirectTo(entity);
        }
    }
}