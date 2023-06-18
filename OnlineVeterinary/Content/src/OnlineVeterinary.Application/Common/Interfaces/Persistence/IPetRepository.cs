using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineVeterinary.Application.DTOs;
using OnlineVeterinary.Domain.CareGivers.Entities;
using OnlineVeterinary.Domain.Pet.Entities;

namespace OnlineVeterinary.Application.Common.Interfaces.Persistence
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<CareGiver> GetCareGiverOfPet(Guid id);
    }
}