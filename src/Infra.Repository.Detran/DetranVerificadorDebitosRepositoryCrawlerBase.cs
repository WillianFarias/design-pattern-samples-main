using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public abstract class DetranVerificadorDebitosRepositoryCrawlerBase : IDetranVerificadorDebitosRepository
    {
        public async Task<IEnumerable<DebitoVeiculo>> ConsultarDebitos(Veiculo veiculo)
        {
            var html = await RealizarAcesso(veiculo);
            return await PadronizarResultado(html);
        }

        protected abstract Task<string> RealizarAcesso(Veiculo veiculo);
        protected abstract Task<IEnumerable<DebitoVeiculo>> PadronizarResultado(string html);

        public async Task<IEnumerable<DebitoCondutor>> ConsultarDebitos(Condutor condutor)
        {
            var html = await RealizarAcesso(condutor);
            return await PadronizarResultadoCondutor(html);
        }

        protected abstract Task<string> RealizarAcesso(Condutor condutor);
        protected abstract Task<IEnumerable<DebitoCondutor>> PadronizarResultadoCondutor(string html);
    }
}
