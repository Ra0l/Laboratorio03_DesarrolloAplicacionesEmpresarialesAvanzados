using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana03_6_VI
{
    class ClsDatos
    {
        //funcion clase cdenas
        public SqlConnection Leercadena()
        {
           //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4S636AC\\SQLEXPRESS; " +
             //   "Initial Catalog=Neptuno; Integrated Security=true");
           // return connection;

            SqlConnection connection = new SqlConnection("Data Source=sql5047.site4now.net; " +
            "Initial Catalog=DB_A5A76C_raul966; User ID=DB_A5A76C_raul966_admin ; Password=");
             return connection;
        }

        public DataTable ListaPedidoFechas(DateTime x, DateTime y)
        {
            SqlConnection connection = Leercadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_ListarPedidosEntreFechas", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@FEC1", x);
            sqlData.SelectCommand.Parameters.AddWithValue("@FEC2", y);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable ListarDetalle(int x)
        {
            SqlConnection connection = Leercadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_ListarDetalle", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", x);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public double PedidoTotal(Int32 idpedido)
        {
            SqlConnection connection = Leercadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_Total", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", idpedido);
            sqlData.SelectCommand.Parameters.Add(
                "@Total", SqlDbType.Money).Direction = ParameterDirection.Output;
            sqlData.SelectCommand.ExecuteScalar();
            Int32 total = Convert.ToInt32(
                sqlData.SelectCommand.Parameters["@Total"].Value);

            connection.Close();
            return total;
        }
    }
}
