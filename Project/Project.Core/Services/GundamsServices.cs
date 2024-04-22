using Project.Core.Mapping;
using Project.Database.Dtos.Request;
using Project.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class GundamsServices
    {
        private GundamsRepository GundamsRepository { get; set; }

        public GundamsServices(GundamsRepository gundamsRepository)
        {
            GundamsRepository = gundamsRepository;
        }

        public void AddGundam(AddGundamRequest payload)
        {
            var gundam = payload.ToEntity();
            GundamsRepository.Add(gundam);
        }

        public void AddGundams(List<AddGundamRequest> payload)
        {
            var gundams = payload.ToEntities();

            GundamsRepository.AddRange(gundams);
        }
    }
}
