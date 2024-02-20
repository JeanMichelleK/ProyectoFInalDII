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
    internal class PersistenciaCiudad : IPersistenciaCiudad
    {
        private static PersistenciaCiudad _instancia = null;
        private PersistenciaCiudad() { }
        public static PersistenciaCiudad GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCiudad();
            return _instancia;
        }

        public void Alta(Ciudad unaC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("AltaCiudad", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoC", unaC.CodigoCiudad);
            Comando.Parameters.AddWithValue("@Nombre", unaC.Nombre);
            Comando.Parameters.AddWithValue("@Pais", unaC.Pais);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Esa ciudad ya existe.");
                if (Return == -2)
                    throw new Exception("Error al dar de alta, intente de nuevo.");
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

        public void Modificar(Ciudad unaC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("ModificarCiudad", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoC", unaC.CodigoCiudad);
            Comando.Parameters.AddWithValue("@Nombre", unaC.Nombre);
            Comando.Parameters.AddWithValue("@Pais", unaC.Pais);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Esa ciudad no existe.");
                if (Return == -2)
                    throw new Exception("Error al modificar, intente de nuevo.");
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
        public void Baja(Ciudad unaC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("BajaCiudad", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoC", unaC.CodigoCiudad);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Esa ciudad no existe.");
                if (Return == -2)
                    throw new Exception("Error al eliminar, intente de nuevo.");
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

        public Ciudad BuscarCiudadActiva(string pCodigo, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Ciudad unaC = null;
            SqlCommand Comando = new SqlCommand("BuscarCiudadActiva", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoC", pCodigo);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unaC = new Ciudad((string)Lector["CodigoC"], (string)Lector["Nombre"], (string)Lector["Pais"]);
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
            return unaC;
        }
        internal Ciudad BuscarCiudadTodas(string pCodigo, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Ciudad unaC = null;
            SqlCommand Comando = new SqlCommand("BuscarCiudad", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@CodigoC", pCodigo);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unaC = new Ciudad((string)Lector["CodigoC"], (string)Lector["Nombre"], (string)Lector["Pais"]);
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
            return unaC;
        }
    }
}
