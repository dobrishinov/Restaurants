namespace WebServices.Services
{
    using DataAccess.Entity;
    using System.Collections.Generic;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserWebService" in both code and config file together.
    [ServiceContract]
    public interface IUserWebService
    {
        [OperationContract]
        List<UserEntity> GetAll();

        [OperationContract]
        UserEntity GetById(int id);

        [OperationContract]
        void Save(UserEntity entity);

        [OperationContract]
        void Delete(UserEntity entity);
    }
}
