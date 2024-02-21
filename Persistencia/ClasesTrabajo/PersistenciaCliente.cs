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
    internal class PersistenciaCliente : IPersistenciaCliente
    {
        private static PersistenciaCliente _instancia = null;
        private PersistenciaCliente() { }
        public static PersistenciaCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCliente();
            return _instancia;
        }
        public void Alta(Cliente unC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("AltaCliente", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unC.NroPasaporte);
            Comando.Parameters.AddWithValue("@Nombre", unC.Nombre);
            Comando.Parameters.AddWithValue("@PassCli", unC.PassCli);
            Comando.Parameters.AddWithValue("@NroTarjeta", unC.NroTarjeta);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("Ya existe un cliente con ese pasaporte.");
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
        public void Modificar(Cliente unC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("ModificarCliente", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unC.NroPasaporte);
            Comando.Parameters.AddWithValue("@Nombre", unC.Nombre);
            Comando.Parameters.AddWithValue("@PassCli", unC.PassCli);
            Comando.Parameters.AddWithValue("@NroTarjeta", unC.NroTarjeta);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("No existe un cliente con ese pasaporte.");
                if (Return == -2)
                    throw new Exception("Error al modificar, intentelo de nuevo.");
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
        public void Baja(Cliente unC, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            SqlCommand Comando = new SqlCommand("AltaCliente", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", unC.NroPasaporte);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(Retorno);
            try
            {
                _cnn.Open();
                Comando.ExecuteNonQuery();
                int Return = Convert.ToInt32(Retorno.Value);
                if (Return == -1)
                    throw new Exception("No existe un cliente con ese pasaporte.");
                if (Return == -2)
                    throw new Exception("Error al dar de baja, intentelo de nuevo.");
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
        public Cliente BuscarClienteActivo(string pPasaporte, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Cliente unC = null;
            SqlCommand Comando = new SqlCommand("BuscarClienteActivo", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", pPasaporte);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unC = new Cliente((string)Lector["NroPasaporte"], (string)Lector["Nombre"], (string)Lector["PassCli"], (string)Lector["NroTarjeta"]);
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
            return unC;
        }
        internal Cliente BuscarClienteTodos(string pPasaporte, Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Cliente unC = null;
            SqlCommand Comando = new SqlCommand("BuscarCliente", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NroPasaporte", pPasaporte);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unC = new Cliente((string)Lector["NroPasaporte"], (string)Lector["Nombre"], (string)Lector["PassCli"], (string)Lector["NroTarjeta"]);
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
            return unC;
        }
        internal List<Cliente> ListadoClientes(Empleado pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pUsu));
            Cliente unC = null;
            List<Cliente> Lista = new List<Cliente>();
            SqlCommand Comando = new SqlCommand("ListarCliente", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        unC = new Cliente((string)Lector["NroPasaporte"], (string)Lector["Nombre"], (string)Lector["PassCli"], (string)Lector["NroTarjeta"]);
                        Lista.Add(unC);
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
