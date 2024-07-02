using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;//Con estas referencias se utiliza la conexion al SQL

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.conexion))
                {
                    string query = "SELECT IdUsuario, Nombre, Correo, Telefono, UsuarioIngreso, FechaIngreso, UsuarioModifico, FechaModifico FROM Catalogo.USUARIO";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = dr["IdUsuario"] != DBNull.Value ? Convert.ToInt32(dr["IdUsuario"]) : 0,
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : string.Empty,
                                Telefono = dr["Telefono"] != DBNull.Value ? dr["Telefono"].ToString() : string.Empty,
                                UsuarioIngreso = dr["UsuarioIngreso"] != DBNull.Value ? dr["UsuarioIngreso"].ToString() : string.Empty,
                                FechaIngreso = dr["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngreso"]) : DateTime.MinValue,
                                UsuarioModifico = dr["UsuarioModifico"] != DBNull.Value ? dr["UsuarioModifico"].ToString() : string.Empty,
                                FechaModifico = dr["FechaModifico"] != DBNull.Value ? Convert.ToDateTime(dr["FechaModifico"]) : DateTime.MinValue
                            });
                        }

                        // Verificar si se están leyendo registros
                        System.Diagnostics.Debug.WriteLine($"Total registros leídos es: {lista.Count}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                lista = new List<Usuario>();
            }
            return lista;
        }
    }



}

