using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Common
{
    public class GundamDtoNoUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Scale { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Series { get; set; }
        public bool Available { get; set; }
    }

    public static class GundamNoUserExtension
    {
        public static GundamDtoNoUser ToNoUserDto(this Gundam entity)
        {
            var dto = new GundamDtoNoUser();

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Grade = entity.Grade;
            dto.Price = entity.Price;
            dto.Series = entity.Series;
            dto.Scale = entity.Scale;
            dto.ReleaseDate = entity.ReleaseDate;
            dto.Available = entity.Available;

            return dto;
        }

        public static List<GundamDtoNoUser> ToNoUserDtos(this List<Gundam> entities)
        {
            var result = entities.Select(g => g.ToNoUserDto()).ToList();

            return result;
        }
    }
}
