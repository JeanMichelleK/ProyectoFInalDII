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
        public void Alta(Venta unaV, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlTransaction Transaccion = null;
            SqlCommand Comando = new SqlCommand("AltaVenta", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unaV.Cliente.NroPasaporte);
            Comando.Parameters.AddWithValue("@CodigoV", unaV.Vuelo.CodigoVuelo);
            Comando.Parameters.AddWithValue("@Monto", unaV.Monto);
            Comando.Parameters.AddWithValue("@Usuario", unaV.Usuario.Usuario);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Transaccion = _cnn.BeginTransaction();
                Comando.Transaction = Transaccion;
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
                foreach (Pasaje Pasa in unaV.ListaP)
                {
                    PersistenciaPasaje.Alta(Pasa, Return, Transaccion);
                }
                Transaccion.Commit();
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public List<Venta> VentaVuelo(Vuelo punV, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            List<Venta> Lista = new List<Venta>();
            Venta unaV = null;
            SqlCommand Comando = new SqlCommand("ListadoVentasDeVuelo", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoV", punV.CodigoVuelo);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        unaV = new Venta((int)Lector["IdVenta"], PersistenciaCliente.GetInstancia().BuscarClienteTodos((string)Lector["NroPasaporte"], pUsu), punV, Convert.ToDateTime(Lector["FechaVenta"]), Convert.ToDouble(Lector["Monto"]), FabricaPersistencia.GetPersistenciaEmpleado().Buscar((string)Lector["Usuario"], pUsu), PersistenciaPasaje.GetInstancia().ListarPasajes((int)Lector["IdVenta"], pUsu));
                        Lista.Add(unaV);
                    }
                }
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
