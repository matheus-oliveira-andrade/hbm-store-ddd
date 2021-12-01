using HBMStore.Core.DomainObjects;
using System.Collections.Generic;

namespace HBMStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        private void Validar()
        {
            Validacoes.ValidarSeEstaVazio(Nome, $"O campo {nameof(Nome)} da categoria não pode estar vazio");
            Validacoes.ValidarSeEhIgual(Codigo, 0, $"O campo {nameof(Codigo)} da categoria não pode ser {0}");
        }
    }
}
