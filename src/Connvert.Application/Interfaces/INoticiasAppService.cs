using Connvert.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connvert.Application.Interfaces
{
    public interface INoticiasAppService
    {
        Task<NoticiasModel> IncluirAsync(NoticiasModel vmNoticias);
        Task<NoticiasModel> EditarAsync(string id, NoticiasModel vmNoticias);
        IEnumerable<NoticiasModel> ListarAsync(ConsultaNoticiasModel vmNoticias);
        Task<NoticiasModel> ExisteAsync(string id);
        void Remover(string id);
    }
}
