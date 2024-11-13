using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using weekTwoDayFive.Models;
using weekTwoDayFive.Repository;

namespace weekTwoDayFive.Services
{

    public interface IUserServices
    {
        void Register(UserModel user);
        UserModel Login(LoginModel user);
        IEnumerable<UserModel> getAllStudents();
        

    }
    public class UserServices : IUserServices
    {
        public void Register(UserModel user)
        {
            lists.userModels.Add(user);
        }
        public UserModel Login(LoginModel loginData)
        {
            var loginUser = lists.userModels.Where(u => u.Usename == loginData.Usename && u.Password == loginData.Password).FirstOrDefault();
            
            return loginUser;
        }
        public IEnumerable<UserModel> getAllStudents()
        {
            var Users = lists.userModels.Select(n => n);
            return Users;
        }

    }
}
