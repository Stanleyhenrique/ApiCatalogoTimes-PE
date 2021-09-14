using System;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class TimeNaoCadastradoException: Exception
    {
        public TimeNaoCadastradoException()
            :base("Este Time não está cadastrado!")
        {}
    }
}
