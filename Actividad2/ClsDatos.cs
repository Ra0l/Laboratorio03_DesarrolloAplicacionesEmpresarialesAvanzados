using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2
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

        public SqlDataReader Listaclientes()
        {
            try
            {
                SqlConnection cn = Leercadena();
                    SqlCommand cmd = new SqlCommand("UspListaClientes");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader
                        (CommandBehavior.CloseConnection);
                    return dr;
                }
                catch (Exception)
            {
                throw;
            }
            }
        }
    }
}
