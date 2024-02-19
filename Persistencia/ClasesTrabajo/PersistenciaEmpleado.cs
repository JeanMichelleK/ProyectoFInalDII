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
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        private static PersistenciaEmpleado _instancia = null;
        private PersistenciaEmpleado() { }
        public static PersistenciaEmpleado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();
            return _instancia;
        }
        public Empleado Buscar(string pUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Empleado unE = null;
            SqlCommand Comando = new SqlCommand("BuscarEmpleado", _cnn);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Usuario", pUsu);
            try
            {
                _cnn.Open();
                SqlDataReader Lector = Comando.ExecuteReader();
                if (Lector.HasRows)
                {
                    Lector.Read();
                    unE = new Empleado((string)Lector["Usuario"], (string)Lector["PassUsu"], (string)Lector["NombreCompleto"], (string)Lector["Labor"]);
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
            return unE;
        }
    }
}
