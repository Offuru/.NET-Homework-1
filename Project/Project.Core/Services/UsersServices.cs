using Project.Core.Mapping;
using Project.Database.Dtos.Request;
using Project.Database.Dtos.Response;
using Project.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class UsersServices
    {
        private UsersRepository UsersRepository { get; set; }

        public UsersServices(UsersRepository usersRepository)
        {  
            this.UsersRepository = usersRepository;
        }

        public void AddUser(AddUserRequest payload)
        {
            var user = payload.ToEntity();
            UsersRepository.Add(user);
        }

        public void AddUsers(List<AddUserRequest> payload)
        {
            var users = payload.ToEntities();
            UsersRepository.AddRange(users);
        }

        public GetUserDetailsResponse GetUserDetails(int userId)
        {
            var user = UsersRepository.GetById(userId);
            var result = user.ToUserDto();

            return result;
        }
    }
}
