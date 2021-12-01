using HBMStore.Domain.DomainObjects;
using System;
using Xunit;

namespace HBMStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarException()  
        {
            DomainException ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty,
                            "Descrição",
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            "imagem",
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            string.Empty,
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            "imagem",
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            100,
                            Guid.Empty,
                            DateTime.Now,
                            "imagem",
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            0,
                            Guid.NewGuid(),
                            DateTime.Now,
                            "imagem",
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo Valor do produto não pode ser igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            -1,
                            Guid.NewGuid(),
                            DateTime.Now,
                            "imagem",
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo Valor do produto não pode ser menor que 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            string.Empty,
                            new Dimensoes(1, 1, 1)
                            ));

            Assert.Equal($"O campo Imagem do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            string.Empty,
                            new Dimensoes(0, 1, 1)
                            ));

            Assert.Equal($"O campo Altura não pode ser menor ou igual a 1", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            string.Empty,
                            new Dimensoes(1, 0, 1)
                            ));

            Assert.Equal($"O campo Largura não pode ser menor ou igual a 1", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome",
                            "Descricao",
                            false,
                            100,
                            Guid.NewGuid(),
                            DateTime.Now,
                            string.Empty,
                            new Dimensoes(1, 1, 0)
                            ));

            Assert.Equal($"O campo Profundidade não pode ser menor ou igual a 1", ex.Message);
        }
    }
}
