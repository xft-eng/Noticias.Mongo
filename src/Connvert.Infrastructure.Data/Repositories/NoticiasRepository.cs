using Connvert.Domain.DTOs;
using Connvert.Domain.Interfaces.Repositories;
using Connvert.Infrastructure.Data.DbContext;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connvert.Infrastructure.Data.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {
        private readonly IMongoCollection<Noticias> _noticias;

        public NoticiasRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _noticias = database.GetCollection<Noticias>("noticias");
        }

        public async Task<Noticias> IncluirAsync(Noticias vmNoticias)
        {

            await _noticias.InsertOneAsync(vmNoticias);

            return vmNoticias;
        }

        public async Task<Noticias> AtualizarAsync(string id, Noticias vmNoticias)
        {

            await _noticias.ReplaceOneAsync(n => n.Id == id, vmNoticias);

            return vmNoticias;
        }

        public IEnumerable<Noticias> BuscarAsync(Noticias vmNoticias)
        {

            if (!string.IsNullOrEmpty(vmNoticias.Titulo))
            {
                return _noticias.Find(n => n.Titulo.ToLower().Contains(vmNoticias.Titulo)).ToList();

            }
            if (!string.IsNullOrEmpty(vmNoticias.Texto))
            {
                return _noticias.Find(n => n.Texto.ToLower().Contains(vmNoticias.Texto)).ToList();
            }
            if (!string.IsNullOrEmpty(vmNoticias.Autor))
            {
                return _noticias.Find(n => n.Autor.ToLower().Contains(vmNoticias.Autor)).ToList();
            }

            return null;
        }

        public async Task<Noticias> Existe(string id)
        {

            return await _noticias.Find(n => n.Id == id).FirstOrDefaultAsync();

        }

        public Noticias Buscar(string id)
        {
            return _noticias.Find(n => n.Id == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _noticias.DeleteOne(n => n.Id == id);
        }
    }
}
