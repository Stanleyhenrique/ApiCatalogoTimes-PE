using System;

namespace ExemploApiCatalogoTimes.Exceptions
{
    public class TimeJaCadastradoException : Exception
    {
        public TimeJaCadastradoException()
            : base("Este Time já está cadastrado!")
        { }
    }
}
