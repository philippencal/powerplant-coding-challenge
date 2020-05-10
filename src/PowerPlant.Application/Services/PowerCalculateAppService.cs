using AutoMapper;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Factories;
using PowerPlant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public List<PowerSupplyRequiredDTO> CalculatePowerRequired(PayloadDTO payloadDTO)
        {
            var powerplants = new List<Models.PowerPlant>();
            var supplyRequired = new List<PowerSupplyRequiredDTO>();
            var loadingRequired = payloadDTO.Load;

            foreach(var powerplantDTO in payloadDTO.Powerplants)
            {
                powerplants.Add(PowerPlantFactory.Build(mapper, payloadDTO.Fuels, powerplantDTO));
            }

            var powerplantsCostGroups = powerplants.GroupBy(p => p.CalculateEnergyCost()).OrderBy(p => p.Key);
            foreach (var powerplantsCostGroup in powerplantsCostGroups)
            {
                if (loadingRequired == 0)
                {
                    break;
                }

                foreach (var powerplant in powerplantsCostGroup)
                {
                    if (powerplant.CanOperate())
                    {
                        var powerProduced = powerplant.ProducePower(loadingRequired);
                        if (powerProduced > 0)
                        {
                            loadingRequired -= powerProduced;
                            supplyRequired.Add(new PowerSupplyRequiredDTO { Name = powerplant.Name, Power = powerProduced });
                        }
                    }
                }
            }

            return supplyRequired;
        }
    }
}
