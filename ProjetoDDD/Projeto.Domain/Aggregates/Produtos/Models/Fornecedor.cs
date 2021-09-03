using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Produtos.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        #region Relacionamentos

        public List<Produto> Produtos { get; set; }

        #endregion
    }
}
