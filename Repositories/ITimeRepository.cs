using ExemploApiCatalogoTimes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public interface ITimeRepository : IDisposable
    {
        Task<List<Time>> Obter(int pagina, int quantidade);
        Task<Time> Obter(Guid id);
        Task<List<Time>> Obter(string nome, string estado);
        Task Inserir(Time Time);
        Task Atualizar(Time Time);
        Task Remover(Guid id);
    }
}
