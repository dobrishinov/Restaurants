namespace WebServices.Services
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITasksWebService" in both code and config file together.
    [ServiceContract]
    public interface IRestaurantWebService
    {
        [OperationContract]
        RestaurantEntity GetById(int id);

        [OperationContract]
        List<RestaurantEntity> GetAll();

        [OperationContract]
        int Count();

        [OperationContract]
        void Save(RestaurantEntity entity);

        [OperationContract]
        void Delete(RestaurantEntity entity);
    }
}
