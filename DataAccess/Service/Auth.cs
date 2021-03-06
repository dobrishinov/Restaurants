﻿namespace DataAccess.Service
{
    using System.Linq;
    using Repository;
    using Entity;

    public class Auth
    {
        public UserEntity LoggedUser { get; private set; }

        public void Authenticate(string username, string password)
        {
            UsersRepository usersRepository = new UsersRepository();
            LoggedUser = usersRepository.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (LoggedUser == null)
            {
                
                LoggedUser = usersRepository.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();

            }
        }
    }
}