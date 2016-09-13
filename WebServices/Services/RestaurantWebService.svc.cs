namespace WebServices.Services
{
    using DataAccess.Entity;
    using ServiceLayer.Services;
    using System.Collections.Generic;
    using System.Linq;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestaurantWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestaurantWebService.svc or RestaurantWebService.svc.cs at the Solution Explorer and start debugging.
    public class RestaurantWebService : IRestaurantWebService
    {
        private readonly RestaurantsService service;

        public RestaurantWebService()
        {
            service = new RestaurantsService();
        }

        public List<RestaurantEntity> GetAll()
        {
            return service.GetAll().ToList();
        }

        public RestaurantEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public void Save(RestaurantEntity entity)
        {
            service.Save(entity);
        }

        public void Delete(RestaurantEntity entity)
        {
            service.Delete(entity);
        }
    }
}
