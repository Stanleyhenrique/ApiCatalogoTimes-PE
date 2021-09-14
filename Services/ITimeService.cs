using ExemploApiCatalogoTimes.InputModel;
using ExemploApiCatalogoTimes.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Services
{
    public interface ITimeService : IDisposable
    {
        Task<List<TimeViewModel>> Obter(int pagina, int quantidade);
        Task<TimeViewModel> Obter(Guid id);
        Task<TimeViewModel> Inserir(TimeInputModel Time);
        Task Atualizar(Guid id, TimeInputModel Time);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
