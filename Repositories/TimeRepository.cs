using ExemploApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private static Dictionary<Guid, Time> Times = new Dictionary<Guid, Time>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Time{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Sport", Estado = "Recife", Preco = 412000000} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Time{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Santa Cruz", Estado = "Recife", Preco = 292000000} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Time{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Nautico", Estado = "Recife", Preco = 212000000} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Time{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Ibis", Estado = "Recife", Preco = 500000} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Time{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Salgueiro", Estado = "Salgueiro", Preco = 1200000} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Time{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Afogados", Estado = "Afogados da Ingazeira", Preco = 120000} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult<Jogo>(null);

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
