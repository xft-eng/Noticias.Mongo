using AutoMapper;
using Connvert.Application.Interfaces;
using Connvert.Application.Model;
using Connvert.Domain.DTOs;
using Connvert.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connvert.Application.Service
{
    public class NoticiasAppService : INoticiasAppService
    {


        private readonly INoticiasService _noticiasService;
        private readonly IMapper _mapper;


        public NoticiasAppService(INoticiasService noticiasService, IMapper mapper)
        {
            _noticiasService = noticiasService;
            _mapper = mapper;
        }


        public async Task<NoticiasModel> IncluirAsync(NoticiasModel vmNoticias)
        {

            var vmModel = _mapper.Map<Noticias>(vmNoticias);

            var noticias = await _noticiasService.IncluirAsync(vmModel);

            return _mapper.Map<NoticiasModel>(noticias);
        }

        public async Task<NoticiasModel> EditarAsync(string id, NoticiasModel vmNoticias)
        {

            var vmModel = _mapper.Map<Noticias>(vmNoticias);

            var noticias = await _noticiasService.EditarAsync(id, vmModel);

            return _mapper.Map<NoticiasModel>(noticias);
        }

        public IEnumerable<NoticiasModel> ListarAsync(ConsultaNoticiasModel vmNoticias)
        {

            var vmModel = _mapper.Map<Noticias>(vmNoticias);

            var noticias = _noticiasService.ListarAsync(vmModel);

            return _mapper.Map<IEnumerable<NoticiasModel>>(noticias);
        }


        public async Task<NoticiasModel> ExisteAsync(string id)
        {

            var noticias = await _noticiasService.ExisteAsync(id);

            return _mapper.Map<NoticiasModel>(noticias);
        }


        public void Remover(string id)
        {

            _noticiasService.Remover(id);

        }

    }
}
