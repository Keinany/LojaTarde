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
    public class VendasBLL
    {
        //Nome da venda é obrigatório
        public void Incluir(VendaInformation venda)
        {
            if (venda.D.Trim().Length == 0)
            {
                throw new Exception("O nome da venda é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            cliente.Email = cliente.Email.ToLower();
            //Se está OK, chama a rotina para inserir 
            ClientesDAL obj = new ClientesDAL();
            obj.Incluir(cliente);
        }
        public void Alterar(ClienteInformation cliente)
        {
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            cliente.Email = cliente.Email.ToLower();
            //Se tudo está OK, chama a rotina para alterar cliente
            ClientesDAL obj = new ClientesDAL();
            obj.Alterar(cliente);
        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um cliente antes de excluií-lo");
            }
            ClientesDAL obj = new ClientesDAL();
            obj.Excluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.Listagem(filtro);
        }
    }
}
