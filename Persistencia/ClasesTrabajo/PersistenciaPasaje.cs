using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaPasaje 
    {
        private static PersistenciaPasaje _instancia = null;
        private PersistenciaPasaje() { }
        public static PersistenciaPasaje GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPasaje();
            return _instancia;
        }

        public void Alta(Pasaje unP, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("AltaPasaje", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unP.Cliente.NroPasaporte);
            Comando.Parameters.AddWithValue("@IdVenta", unP.Venta.IdVenta);
            Comando.Parameters.AddWithValue("@Asiento", unP.Asiento);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Ese cliente no existe.");
                if (Return == -2)
                    throw new Exception("Esa venta no existe.");
                if (Return == -3)
                    throw new Exception("Error al dar de alta, intentelo de nuevo.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }
        public List<Pasaje> ListarPasajes(int CodigoV, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Pasaje unP = null;
            List<Pasaje> Lista = new List<Pasaje>();
            SqlCommand Comando = new SqlCommand("ListarPasajes", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        unP = new Pasaje((Cliente)Lector["NroPasaporte"], (Venta)Lector["IdVenta"], (int)Lector["Asiento"]);
                        Lista.Add(unP);
                    }
                }
                Lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return Lista;
        }
    }
}
