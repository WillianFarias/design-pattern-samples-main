using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran

{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class DebitoMotoristaController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorDebitosCondutorService _IDetranVerificadorDebitosCondutorService;
        public DebitoMotoristaController(IMapper mapper, IDetranVerificadorDebitosCondutorService detranVerificadorDebitosCondutorServices)
        {
            _Mapper = mapper;
            _IDetranVerificadorDebitosCondutorService = detranVerificadorDebitosCondutorServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<DebitoCondutorModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery] CondutorModel model)
        {
            var debitos = await _IDetranVerificadorDebitosCondutorService.ConsultarDebitosCondutor(_Mapper.Map<Condutor>(model));

            var result = new SuccessResultModel<IEnumerable<DebitoVeiculoModel>>(_Mapper.Map<IEnumerable<DebitoVeiculoModel>>(debitos));

            return Ok(result);
        }
    }
}

