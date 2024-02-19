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
    internal class PersistenciaVenta : IPersistenciaVenta
    {
        private static PersistenciaVenta _instancia = null;
        private PersistenciaVenta() { }
        public static PersistenciaVenta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaVenta();
            return _instancia;
        }
        public void Alta(Venta unaV)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand Comando = new SqlCommand("AltaVenta", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unaV.Cliente.NroPasaporte);
            Comando.Parameters.AddWithValue("@CodigoV", unaV.Vuelo.CodigoVuelo);
            Comando.Parameters.AddWithValue("@FechaVenta", unaV.FechaVenta);
            Comando.Parameters.AddWithValue("@Monto", unaV.Monto);
            Comando.Parameters.AddWithValue("@Usuario", unaV.Usuario.Usuario);
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
                    throw new Exception("Ese vuelo no existe.");
                if (Return == -3)
                    throw new Exception("El empleado no existe.");
                if (Return == -4)
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
    }
}
