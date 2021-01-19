using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Services
{
    public interface IDetranVerificadorDebitosCondutorService
    {
        Task<IEnumerable<DebitoVeiculo>> ConsultarDebitosCondutor(Condutor condutor);
    }
}
