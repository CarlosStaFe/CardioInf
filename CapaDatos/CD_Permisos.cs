using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Permisos:Conexion
    {
        //***** METODO PARA LISTAR LOS PERMISOS DE CADA USUARIO *****
        public List<CE_Permisos> ListaPermisos(int idUsuario)
        {
            List<CE_Permisos> lista = new List<CE_Permisos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Connection = connection;
                        command.CommandText = "SP_ListaPermisos";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Permisos()
                                {
                                    id_Permiso = Convert.ToInt32(dr["id_Permiso"]),
                                    fk_Usuarios = Convert.ToInt32(dr["fk_Usuarios"]),
                                    fk_Botones = Convert.ToInt32(dr["fk_Botones"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Detalle = dr["Detalle"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Permisos>();
                    }
                }
            }
            return lista;
        }
    }

    //***** METODO PARA ACTUALIZAR LOS PERMISOS DE CADA USUARIO *****
    public class CD_PermisosNew : Conexion
    {
        //***** METODO PARA REGISTRAR UN PERMISO *****
        public int Registrar(CE_PermisosNew obj, out string Mensaje)
        {
            int idPermiso = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarPermiso", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("fk_Usuarios", obj.fk_Usuarios);
                        command.Parameters.AddWithValue("fk_Botones", obj.fk_Botones);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idPermiso = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idPermiso = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idPermiso;
        }

        //***** METODO PARA ELIMINAR UN PERMISO *****
        public bool Eliminar(CE_PermisosNew obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EliminarPermiso", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Permiso", obj.id_Permiso);
                        command.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }
    }
}
