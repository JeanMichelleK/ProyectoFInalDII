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
    internal class PersistenciaAeropuerto : IPersistenciaAeropuerto
    {
        private static PersistenciaAeropuerto _instancia = null;
        private PersistenciaAeropuerto() { }
        public static PersistenciaAeropuerto GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaAeropuerto();
            return _instancia;
        }

        public void Alta(Aeropuerto unA)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            //Llamamos conexion la operacion 
            SqlCommand Comando = new SqlCommand("AltaAeropuerto", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoA", unA.CodigoA);
            Comando.Parameters.AddWithValue("@Nombre", unA.Nombre);
            Comando.Parameters.AddWithValue("@Direccion", unA.Direccion);
            Comando.Parameters.AddWithValue("@ImpuestoS", unA.ImpuestoSalida);
            Comando.Parameters.AddWithValue("@ImpuestoL", unA.ImpuestoLlegada);
            Comando.Parameters.AddWithValue("@CodigoC", unA.Ciudad.CodigoCiudad);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Ese aeropuerto ya existe.");
                if (Return == -2)
                    throw new Exception("Esa ciudad no existe.");
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

        public void Modificar(Aeropuerto unA)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand Comando = new SqlCommand("ModificarAeropuerto", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoA", unA.CodigoA);
            Comando.Parameters.AddWithValue("@Nombre", unA.Nombre);
            Comando.Parameters.AddWithValue("@Direccion", unA.Direccion);
            Comando.Parameters.AddWithValue("@ImpuestoS", unA.ImpuestoSalida);
            Comando.Parameters.AddWithValue("@ImpuestoL", unA.ImpuestoLlegada);
            Comando.Parameters.AddWithValue("@CodigoC", unA.Ciudad.CodigoCiudad);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Ese aeropuerto no existe.");
                if (Return == -2)
                    throw new Exception("Esa ciudad no existe.");
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

        public void Baja(Aeropuerto unA)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand Comando = new SqlCommand("BajaAeropuerto", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoA", unA.CodigoA);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Ese aeropuerto no existe.");
                if (Return == -2)
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

        public Aeropuerto BuscarAeropuertoActivo(string pCodigo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Aeropuerto unA = null;
            SqlCommand Comando = new SqlCommand("BuscarAeropuertoActivo", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unA = new Aeropuerto((string)Lector["CodigoA"], (string)Lector["Nombre"], (string)Lector["Direccion"], Convert.ToDouble(Lector["ImpuestoS"]), Convert.ToDouble(Lector["ImpuestoL"]),FabricaPersistencia.GetPersistenciaCiudad().BuscarCiudadActiva((string)Lector["CodigoC"]));
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
            return unA;
        }
        internal Aeropuerto BuscarAeropuertoTodos(string pCodigo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Aeropuerto unA = null;
            SqlCommand Comando = new SqlCommand("BuscarAeropuerto", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unA = new Aeropuerto((string)Lector["CodigoA"], (string)Lector["Nombre"], (string)Lector["Direccion"], Convert.ToDouble(Lector["ImpuestoS"]), Convert.ToDouble(Lector["ImpuestoL"]), FabricaPersistencia.GetPersistenciaCiudad().BuscarCiudadActiva((string)Lector["CodigoC"]));
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
            return unA;
        }
    }
}
