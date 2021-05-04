using System;

namespace Dio.Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta MinhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Wesley");
            
            Console.WriteLine(MinhaConta.ToString());
            
        }
    }
}
