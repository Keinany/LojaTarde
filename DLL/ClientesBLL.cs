using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace BLL
{
    public class ClientesBLL
    {
        //Nome do cliente é obrigatório
        public void Incluir(ClienteInformation cliente)
        {
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            cliente.Email = cliente.Email.ToLower();
            //Se está OK, chama a rotina para inserir 
            ClientesDAL obj = new ClientesDAL();
            obj.Incluir(cliente);
        }
    }
}
