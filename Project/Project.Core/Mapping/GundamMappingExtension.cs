using Project.Database.Dtos.Common;
using Project.Database.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Gundam = Project.Database.Entities.Gundam;

namespace Project.Core.Mapping
{
    public static class GundamMappingExtension
    {
        public static Gundam ToEntity(this AddGundamRequest dto)
        {
            if (dto == null)
                return null;

            var gundam = new Gundam();
            gundam.Name = dto.Name;
            gundam.Grade = dto.Grade;
            gundam.Price = dto.Price;
            gundam.Series = dto.Series;
            gundam.ReleaseDate = dto.ReleaseDate;
            gundam.Available = dto.Available;
            gundam.AssignedUserId = dto.UserId;
            gundam.Scale = dto.Scale;
            gundam.Id = dto.Id;

            return gundam;
        }

        public static List<Gundam> ToEntities(this List<AddGundamRequest> dtos)
        {
            var results = dtos.Select(dto => dto.ToEntity()).ToList();
            return results;
        }
    }
}
