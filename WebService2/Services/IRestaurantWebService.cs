namespace WebServices.Services
{
    using DataAccess.Entity;
    using System.Collections.Generic;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITasksWebService" in both code and config file together.
    [ServiceContract]
    public interface IRestaurantWebService
    {
        [OperationContract]
        RestaurantEntity GetById(int id);

        [OperationContract]
        List<RestaurantEntity> GetAll();

        [OperationContract]
        void Save(RestaurantEntity entity);

        [OperationContract]
        void Delete(RestaurantEntity entity);
    }
}
