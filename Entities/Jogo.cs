using System;

namespace ExemploApiCatalogoTimes.Entities
{
    public class Time
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public double Preco { get; set; }
    }
}
