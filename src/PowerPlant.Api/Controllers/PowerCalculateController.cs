using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Interfaces;

namespace PowerPlant.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PowerCalculateController : ControllerBase
    {
        private readonly ILogger<PowerCalculateController> logger;
        private readonly IPowerCalculateAppService powerCalculateAppService;

        public PowerCalculateController(ILogger<PowerCalculateController> logger, IPowerCalculateAppService powerCalculateAppService)
        {
            this.logger = logger;
            this.powerCalculateAppService = powerCalculateAppService;
        }

        /// <summary>
        /// Calculate how much power each of a multitude of different powerplants need to produce when the load is given.
        /// </summary>
        /// <remarks>
        /// In order to calculate the power required, the payload body object contains 3 types of data:
        /// 
        /// <b>load:</b> The load is the amount of energy(MWh) that need to be generated during one hour. <br/><br/>
        /// <b>fuels:</b> based on the cost of the fuels of each powerplant, the merit-order can be determined which is the starting point for deciding which powerplants should be switched on and how much power they will deliver. Wind-turbine are either switched-on, and in that case generate a certain amount of energy depending on the % of wind, or can be switched off. <br/>
        ///     <ul>
        ///         <li><i>gas(euro/MWh):</i> the price of gas per MWh.Thus if gas is at 6 euro/MWh and if the efficiency of the powerplant is 50% (i.e. 2 units of gas will generate one unit of electricity), the cost of generating 1 MWh is 12 euro.</li>
        ///         <li><i>kerosine(euro/Mwh):</i> the price of kerosine per MWh.</li>
        ///         <li><i>co2(euro/ton):</i> the price of emission allowances(optionally to be taken into account).</li>
        ///         <li><i>wind(%):</i> percentage of wind.Example: if there is on average 25% wind during an hour, a wind-turbine with a Pmax of 4 MW will generate 1MWh of energy.</li>
        ///     </ul>
        /// <b>powerplants:</b> describes the powerplants at disposal to generate the demanded load.For each powerplant. is specified: <br/>
        ///     <ul>
        ///         <li><i>name:</i> the powerplant identification name.</li>
        ///         <li><i>type:</i> gasfired, turbojet or windturbine.</li>
        ///         <li><i>efficiency:</i> the efficiency at which they convert a MWh of fuel into a MWh of electrical energy. Wind-turbines do not consume 'fuel' and thus are considered to generate power at zero price.</li>
        ///         <li><i>pmax:</i> the maximum amount of power the powerplant can generate.</li>
        ///         <li><i>pmin:</i> the minimum amount of power the powerplant generates when switched on.</li>
        ///     </ul>
        ///     <br/>
        ///     <b>v parameter: describes the api version you want to use, set 1 by default.</b>
        /// </remarks>
        /// <param name="payloadDTO">A payload structure contain the load, fuels and powerplants information.</param>
        /// <returns>returns how much power each powerplant should deliver</returns>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        public List<PowerSupplyRequiredDTO> Post([FromBody] PayloadDTO payloadDTO)
        {
            return powerCalculateAppService.CalculatePowerRequired(payloadDTO);
        }
    }
}
