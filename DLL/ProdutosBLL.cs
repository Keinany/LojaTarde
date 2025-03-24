using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace BLL
{
    public class ProdutosBLL
    {
        public void Incluir(ProdutoInformation produto)
        {
            //produto obrigatório
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            //preço não pode ser negativo
            if (produto.Preco < 0)
            {
                throw new Exception("Preço não pode ser negativo");
            }
            //estoque não pode ser negativo
            if (produto.Estoque < 0)
            {
                throw new Exception("Estoque não pode ser negativo");
            }
            //se tudo está OK, chama a rotina para alterar produto
            ProdutosDAL obj = new ProdutosDAL();
            obj.Incluir(produto);
        }
    }
}
