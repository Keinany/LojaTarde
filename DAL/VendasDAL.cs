using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos;


namespace DAL
{
    public class VenadasDAL
    {
        public void Incluir(VendaInformation venda)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                //define que usarmos stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                //executa a stored procedure
                cmd.CommandText = "insere_venda";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pdata = new SqlParameter("@data", SqlDbType.VarChar, 100);
                pdata.Value = venda.Data;
                cmd.Parameters.Add(pdata);

                SqlParameter pquantidade = new SqlParameter("@quantidade", SqlDbType.VarChar, 100);
                pquantidade.Value = venda.Quantidade;
                cmd.Parameters.Add(pquantidade);

                SqlParameter pfaturado = new SqlParameter("@faturado", SqlDbType.Bit);
                pfaturado.Value = venda.Faturado;
                cmd.Parameters.Add(pfaturado);

                SqlParameter pCodigoCliente = new SqlParameter("@codigocliente", SqlDbType.Int);
                pCodigoCliente.Value = venda.CodigoCliente;
                cmd.Parameters.Add(pCodigoCliente);

                SqlParameter pCodigoProduto = new SqlParameter("@codigoproduto", SqlDbType.Int);
                pCodigoProduto.Value = venda._CodigoProduto;
                cmd.Parameters.Add(pCodigoProduto);

                cn.Open();
                cmd.ExecuteNonQuery();
                venda.Codigo = (Int32)cmd.Parameters["@codigo"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        public void Alterar(VendaInformation venda)
        {
            //coneção
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "altera_venda";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pdata = new SqlParameter("@data", SqlDbType.VarChar, 100);
                pdata.Value = venda.Data;
                cmd.Parameters.Add(pdata);

                SqlParameter pquantidade = new SqlParameter("@quantidade", SqlDbType.VarChar, 100);
                pquantidade.Value = venda.Quantidade;
                cmd.Parameters.Add(pquantidade);

                SqlParameter pfaturado = new SqlParameter("@faturado", SqlDbType.Bit);
                pfaturado.Value = venda.Faturado;
                cmd.Parameters.Add(pfaturado);

                SqlParameter pCodigoCliente = new SqlParameter("@codigocliente", SqlDbType.Int);
                pCodigoCliente.Value = venda.CodigoCliente;
                cmd.Parameters.Add(pCodigoCliente);

                SqlParameter pCodigoProduto = new SqlParameter("@codigoproduto", SqlDbType.Int);
                pCodigoProduto.Value = venda._CodigoProduto;
                cmd.Parameters.Add(pCodigoProduto);

            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(int codigo)
        {
            //coneção
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "exclui_venda";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente " + codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable Listagem(string filtro)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao();
                //adapter
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "seleciona_venda";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //parâmetro filtro
                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                pfiltro.Value = filtro;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro servidor SQL: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

