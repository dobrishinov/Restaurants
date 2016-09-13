using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserWebService" in both code and config file together.
    [ServiceContract]
    public interface IUserWebService
    {
        [OperationContract]
        UserEntity GetById(int id);

        [OperationContract]
        List<UserEntity> GetAll();

        [OperationContract]
        void Save(UserEntity entity);

        [OperationContract]
        void Delete(UserEntity entity);
    }
}
