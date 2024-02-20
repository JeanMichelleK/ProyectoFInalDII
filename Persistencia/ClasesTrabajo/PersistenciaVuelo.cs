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
    internal class PersistenciaVuelo : IPersistenciaVuelo
    {
        private static PersistenciaVuelo _instancia = null;
        private PersistenciaVuelo() { }
        public static PersistenciaVuelo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaVuelo();
            return _instancia;
        }

        public void Alta(Vuelo unV, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("AltaVuelo", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoV", unV.CodigoVuelo);
            Comando.Parameters.AddWithValue("@FechaYHoraSalida", unV.FechaHoraSalida);
            Comando.Parameters.AddWithValue("@FechaYHoraLlegada", unV.FechaHoraLlegada);
            Comando.Parameters.AddWithValue("@AeropuertoPartida", unV.AeropuertoPartida);
            Comando.Parameters.AddWithValue("@AeropuertoLlegada", unV.AeropuertoLlegada);
            Comando.Parameters.AddWithValue("@Precio", unV.Precio);
            Comando.Parameters.AddWithValue("CantAsientos", unV.CantidadAsientos);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("El aeropuerto de partida no existe.");
                if (Return == -2)
                    throw new Exception("El aeropuerto de llegada no existe.");
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

        public List<Vuelo> ListadoVuelos(Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Vuelo unV = null;
            List<Vuelo> Lista = new List<Vuelo>();
            SqlCommand Comando = new SqlCommand("ListadoVuelos", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        unV = new Vuelo((string)Lector["CodigoV"], Convert.ToDateTime(Lector["FechaYHoraSalida"]), Convert.ToDateTime(Lector["FechaYHoraLlegada"]), (Aeropuerto)Lector["AeropuertoPartida"], (Aeropuerto)Lector["AeropuertoLlegada"], Convert.ToDouble(Lector["Precio"]), Convert.ToInt32(Lector["CantAsientos"]));
                        Lista.Add(unV);
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
