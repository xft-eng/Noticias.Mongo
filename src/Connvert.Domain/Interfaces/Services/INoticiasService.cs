using Connvert.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connvert.Domain.Interfaces.Repositories
{
    public interface INoticiasService
    {
        Task<Noticias> IncluirAsync(Noticias vmNoticias);
        Task<Noticias> EditarAsync(string id, Noticias vmNoticias);
        Task<Noticias> ExisteAsync(string id);
        IEnumerable<Noticias> ListarAsync(Noticias vmNoticias);
        void Remover(string id);
    }
}
