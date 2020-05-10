using AutoMapper;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Factories;
using PowerPlant.Application.Interfaces;
using System.Collections.Generic;
using Models = PowerPlant.Domain.Models;

namespace PowerPlant.Application.Services
{
    public class PowerCalculateAppService : IPowerCalculateAppService
    {
        private readonly IMapper mapper;

        public PowerCalculateAppService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<PowerPlantResponseDTO> CalculatePowerRequired(PayloadDTO payloadDTO)
        {
            var powerplants = new List<Models.PowerPlant>();
            foreach(var powerplantDTO in payloadDTO.Powerplants)
            {
                powerplants.Add(PowerPlantFactory.Build(mapper, payloadDTO.Fuels, powerplantDTO));
            }

            return null;
        }
    }
}
