using PowerPlant.Application.DTO;
using System.Collections.Generic;

namespace PowerPlant.Application.Interfaces
{
    public interface IPowerCalculateAppService
    {
        List<PowerSupplyDTO> CalculatePowerRequired(PayloadDTO payloadDTO);
    }
}
