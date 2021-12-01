using System.Text.RegularExpressions;

namespace HBMStore.Domain.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeEhIgual(object primeiroObj, object segundoObj, string mensagem)
        {
            if (primeiroObj != segundoObj)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhDiferente(object primeiroObj, object segundoObj, string mensagem)
        {
            if (primeiroObj == segundoObj)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarQuantidadeCaracteres(string valor, int quantidadeMaxima, string mensagem)
        {
            var quantidadeCaracteresValor = valor.Trim().Length;
            if (quantidadeCaracteresValor > quantidadeMaxima)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarQuantidadeCaracteres(string valor, int quantidadeMinima, int quantidadeMaxima, string mensagem)
        {
            var quantidadeCaracteresValor = valor.Trim().Length;
            if (quantidadeCaracteresValor < quantidadeMinima || quantidadeMinima > quantidadeMaxima)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeAtendeExpressao(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaNulo(object primeiroObj, string mensagem)
        {
            if (primeiroObj == null)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaEntreMinimoMaximo(double valor, double valorMinimo, double valorMaximo, string mensagem)
        {
            if (valor < valorMinimo || valor > valorMaximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaEntreMinimoMaximo(float valor, float valorMinimo, float valorMaximo, string mensagem)
        {
            if (valor < valorMinimo || valor > valorMaximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaEntreMinimoMaximo(int valor, int valorMinimo, int valorMaximo, string mensagem)
        {
            if (valor < valorMinimo || valor > valorMaximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaEntreMinimoMaximo(long valor, long valorMinimo, long valorMaximo, string mensagem)
        {
            if (valor < valorMinimo || valor > valorMaximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEstaEntreMinimoMaximo(decimal valor, decimal valorMinimo, decimal valorMaximo, string mensagem)
        {
            if (valor < valorMinimo || valor > valorMaximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhMenorIgualMinimo(double valor, double valorMinimo, string mensagem)
        {
            if (valor <= valorMinimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhMenorIgualMinimo(float valor, float valorMinimo, string mensagem)
        {
            if (valor <= valorMinimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhMenorIgualMinimo(int valor, int valorMinimo, string mensagem)
        {
            if (valor <= valorMinimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhMenorIgualMinimo(long valor, long valorMinimo, string mensagem)
        {
            if (valor <= valorMinimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhMenorIgualMinimo(decimal valor, decimal valorMinimo, string mensagem)
        {
            if (valor <= valorMinimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhFalso(bool flagCondicao, string mensagem)
        {
            if (flagCondicao)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeEhVerdadeiro(bool flagCondicao, string mensagem)
        {
            if (!flagCondicao)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}
