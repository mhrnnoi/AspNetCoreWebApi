using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineVeterinary.Application.CareGivers.Commands.Add;
using OnlineVeterinary.Application.CareGivers.Commands.DeleteById;
using OnlineVeterinary.Application.CareGivers.Commands.Update;
using OnlineVeterinary.Application.CareGivers.Queries.GetAll;
using OnlineVeterinary.Application.CareGivers.Queries.GetById;
using OnlineVeterinary.Application.CareGivers.Queries.GetPets;
using OnlineVeterinary.Contracts.CareGivers.Request;

namespace OnlineVeterinary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CareGiverController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatR;
        public CareGiverController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddCareGiverAsync(AddCareGiverRequest request)
        {
            var command = _mapper.Map<AddCareGiverCommand>(request);

            var careGiver = await _mediatR.Send(command);
            return Ok(careGiver);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllCareGiversAsync()
        {
            var query = new GetAllCareGiversQuery();
            var careGivers = await _mediatR.Send(query);
            return Ok(careGivers);

        }
        [HttpGet]
        public async Task<IActionResult> GetCareGiverByIdAsync(Guid id)
        {
            var query = new GetCareGiverByIdQuery(id);
            var careGiver = await _mediatR.Send(query);
            return Ok(careGiver);

        }

        [HttpGet]
        public async Task<IActionResult> GetPetsOfCareGiverByIdAsync(Guid id)
        {
            var query = new GetPetsOfCareGiverByIdQuery(id);
            var pets = await _mediatR.Send(query);
            return Ok(pets);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCareGiverAsync(UpdateCareGiverRequest request)
        {
            var command = _mapper.Map<UpdateCareGiverCommand>(request);

            var careGiver = await _mediatR.Send(command);
            return Ok(careGiver);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCareGiverByIdAsync(Guid id)
        {
            var query = new DeleteCareGiverByIdCommand(id);
            var result = await _mediatR.Send(query);
            return Ok(result);

        }


    }
}