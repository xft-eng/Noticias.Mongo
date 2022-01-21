using Connvert.Domain.DTOs;
using Connvert.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connvert.Domain.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly INoticiasRepository _repository;

        public NoticiasService(INoticiasRepository repository) =>
            _repository = repository;

        public async Task<Noticias> IncluirAsync(Noticias vmNoticias)
        {
            return await _repository.IncluirAsync(vmNoticias).ConfigureAwait(true);
        }

        public async Task<Noticias> EditarAsync(string id, Noticias vmNoticias)
        {
            return await _repository.AtualizarAsync(id, vmNoticias).ConfigureAwait(true);
        }

        public async Task<Noticias> ExisteAsync(string id)
        {
            return await _repository.Existe(id).ConfigureAwait(true);
        }

        public IEnumerable<Noticias> ListarAsync(Noticias vmNoticias)
        {
            return _repository.BuscarAsync(vmNoticias);
        }

        public void Remover(string id)
        {
            _repository.Remover(id);
        }

    }
}
