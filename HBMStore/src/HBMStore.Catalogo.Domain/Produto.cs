using HBMStore.Domain.DomainObjects;
using System;

namespace HBMStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome,
                       string descricao,
                       bool ativo,
                       decimal valor,
                       Guid categoriaId,
                       DateTime dataCadastro,
                       string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            CategoriaId = categoriaId;
            DataCadastro = dataCadastro;
            Imagem = imagem;

            // Fail fast validation
            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Validacoes.ValidarSeEstaNulo(categoria, $"A categoria não pode ser nula");

            CategoriaId = Categoria.Id;
            Categoria = categoria;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeEstaVazio(descricao, $"O campo {nameof(descricao)} do produto não pode estar vazio");
            Validacoes.ValidarSeEstaNulo(descricao, $"O campo {nameof(descricao)} do produto não pode estar nulo");

            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;

            if (!PossuiEmEstoque(quantidade))
                throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEmEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        private void Validar()
        {
            // Assertion concern
            Validacoes.ValidarSeEstaVazio(Nome, $"O campo {nameof(Nome)} do produto não pode estar vazio");
            Validacoes.ValidarSeEstaVazio(Descricao, $"O campo {nameof(Descricao)} do produto não pode estar vazio");
            Validacoes.ValidarSeEhDiferente(CategoriaId, Guid.Empty, $"O campo {nameof(CategoriaId)} do produto não pode estar vazio");
            Validacoes.ValidarSeEhMenorIgualMinimo(Valor, 0, $"O campo {nameof(Valor)} do produto não pode ser menor menor ou igual a {0}");
            Validacoes.ValidarSeEstaVazio(Imagem, $"O campo {nameof(Imagem)} do produto não pode estar vazio");
        }
    }
}
