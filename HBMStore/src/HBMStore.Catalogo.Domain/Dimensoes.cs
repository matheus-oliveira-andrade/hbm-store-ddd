using HBMStore.Core.DomainObjects;

namespace HBMStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} X {Altura} X {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }

        private void Validar()
        {
            int valorMinimo = 1;

            Validacoes.ValidarSeEhMenorQue(Altura, valorMinimo, $"O campo {nameof(Altura)} não pode ser menor ou igual a {valorMinimo}");
            Validacoes.ValidarSeEhMenorQue(Largura, valorMinimo, $"O campo {nameof(Largura)} não pode ser menor ou igual a {valorMinimo}");
            Validacoes.ValidarSeEhMenorQue(Profundidade, valorMinimo, $"O campo {nameof(Profundidade)} não pode ser menor ou igual a {valorMinimo}");
        }
    }
}
