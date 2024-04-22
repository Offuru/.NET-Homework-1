using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Database.Dtos.Common;
using Project.Database.Dtos.Request;
using Project.Database.Dtos.Response;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Mapping
{
    public static class UserMappingExtension
    {
        public static User ToEntity(this AddUserRequest dto)
        {
            if (dto == null)
                return null; 

            User user = new User();

            user.Id = dto.Id;
            user.Balance = dto.Balance;
            user.Username = dto.Username;

            return user;
        }

        public static List<User> ToEntities(this List<AddUserRequest> dtos)
        {
            var result = dtos.Select(dto => dto.ToEntity()).ToList();
            return result;
        }

        public static GetUserDetailsResponse ToUserDto(this User entity)
        {
            if (entity == null)
                return null;

            var result = new GetUserDetailsResponse();
            result.Id = entity.Id;
            result.Balance = entity.Balance;
            result.Username = entity.Username;  
            result.Gundams = entity.Gundams;

            return result;
        }

    }
}
