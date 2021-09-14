using ExemploApiCatalogoTimes.Entities;
using ExemploApiCatalogoTimes.Exceptions;
using ExemploApiCatalogoTimes.InputModel;
using ExemploApiCatalogoTimes.Repositories;
using ExemploApiCatalogoTimes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoTimes.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _TimeRepository;

        public TimeService(ITimeRepository TimeRepository)
        {
            _TimeRepository = TimeRepository;
        }

        public async Task<List<TimeViewModel>> Obter(int pagina, int quantidade)
        {
            var Times = await _TimeRepository.Obter(pagina, quantidade);

            return Times.Select(Time => new TimeViewModel
            {
                                    Id = Time.Id,
                                    Nome = Time.Nome,
                                    Produtora = Time.Produtora,
                                    Preco = Time.Preco
                                })
                               .ToList();
        }

        public async Task<TimeViewModel> Obter(Guid id)
        {
            var Time = await _TimeRepository.Obter(id);

            if (Time == null)
                return null;

            return new TimeViewModel
            {
                Id = Time.Id,
                Nome = Time.Nome,
                Cidade = Time.Cidade,
                Preco = Time.Preco
            };
        }

        public async Task<TimeViewModel> Inserir(TimeInputModel Time)
        {
            var entidadeTime = await _TimeRepository.Obter(Time.Nome, Time.Produtora);

            if (entidadeTime.Count > 0)
                throw new TimeJaCadastradoException();

            var TimeInsert = new Time
            {
                Id = Guid.NewGuid(),
                Nome = Time.Nome,
                Produtora = Time.Produtora,
                Preco = Time.Preco
            };

            await _TimeRepository.Inserir(TimeInsert);

            return new TimeViewModel
            {
                Id = timeInsert.Id,
                Nome = time.Nome,
                Estado = time.Estado,
                Preco = time.Preco
            };
        }

        public async Task Atualizar(Guid id, TimeInputModel Time)
        {
            var entidadeTime = await _TimeRepository.Obter(id);

            if (entidadeTime == null)
                throw new TimeNaoCadastradoException();

            entidadeTime.Nome = Time.Nome;
            entidadeTime.Produtora = Time.Produtora;
            entidadeTime.Preco = Time.Preco;

            await _timeRepository.Atualizar(entidadeTime);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _TimeRepository.Obter(id);

            if (entidadeJogo == null)
                throw new timeNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _timeRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var Time = await _timeRepository.Obter(id);

            if (time == null)
                throw new JogoNaoCadastradoException();

            await _timeRepository.Remover(id);
        }

        public void Dispose()
        {
            _timeRepository?.Dispose();
        }
    }
}
