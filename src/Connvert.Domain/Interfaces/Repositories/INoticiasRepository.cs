using Connvert.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connvert.Domain.Interfaces.Repositories
{
    public interface INoticiasRepository
    {
        Task<Noticias> IncluirAsync(Noticias vmNoticias);
        Task<Noticias> AtualizarAsync(string id, Noticias vmNoticias);
        IEnumerable<Noticias> BuscarAsync(Noticias vmNoticias);

        Task<Noticias> Existe(string id);
        Noticias Buscar(string id);
        void Remover(string id);
    }
}
