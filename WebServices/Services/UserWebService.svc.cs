namespace WebServices.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using DataAccess.Entity;
    using ServiceLayer.Services;
    using WebServices.Services;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserWebService.svc or UserWebService.svc.cs at the Solution Explorer and start debugging.
    public class UserWebService : IUserWebService
    {
        private readonly UsersService service;

        public UserWebService()
        {
            service = new UsersService();
        }

        public List<UserEntity> GetAll()
        {
            return service.GetAll().ToList();
        }

        public UserEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public void Save(UserEntity entity)
        {
            service.Save(entity);
        }

        public void Delete(UserEntity entity)
        {
            service.Delete(entity);
        }
    }
}
