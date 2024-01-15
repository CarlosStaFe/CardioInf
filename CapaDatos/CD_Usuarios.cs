using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Usuarios:Conexion
    {
        //***** BUSQUEDA DE USUARIO EN EL LOGIN *****
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM usuarios WHERE Usuario = @user AND Clave = @pass";
                    command.CommandType= CommandType.Text;
                    MySqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CE_UserLogin.id_Usuario = dr.GetInt32(0);
                            CE_UserLogin.Apellido = dr.GetString(1);
                            CE_UserLogin.Nombres = dr.GetString(2);
                            CE_UserLogin.Nivel = dr.GetInt32(3);
                            CE_UserLogin.Funcion = dr.GetString(4);
                            CE_UserLogin.Usuario = dr.GetString(5);
                            CE_UserLogin.Clave = dr.GetString(6);
                            CE_UserLogin.Activo = dr.GetBoolean(7);
                            CE_UserLogin.UserRegistro = dr.GetString(8);
                            CE_UserLogin.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                            //CE_UserLogin.FechaRegistro = Convert.ToString(dr.GetDateTime(9));
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } 
        }

        //***** METODO PARA LISTAR LOS USUARIOS *****
        public List<CE_Usuarios> ListaUser()
        {
            List<CE_Usuarios> lista = new List<CE_Usuarios>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Usuarios ORDER BY Usuario";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Usuarios()
                                {
                                    id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                    Apellido = dr["Apellido"].ToString(),
                                    Nombres = dr["Nombres"].ToString(),
                                    Nivel = Convert.ToInt32(dr["Nivel"]),
                                    Funcion = dr["Funcion"].ToString(),
                                    Usuario = dr["Usuario"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Usuarios>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Usuarios obj, out string Mensaje)
        {
            int idUsuario = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Apellido", obj.Apellido);
                        command.Parameters.AddWithValue("_Nombres", obj.Nombres);
                        command.Parameters.AddWithValue("_Nivel", obj.Nivel);
                        command.Parameters.AddWithValue("_Funcion", obj.Funcion);
                        command.Parameters.AddWithValue("_Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("_Clave", obj.Clave);
                        command.Parameters.AddWithValue("_Activo", obj.Activo);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idUsuario = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idUsuario = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idUsuario;
        }

        //***** METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Usuarios obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarUsuario",connection))
                {
                    try
                    {        
                        command.Parameters.AddWithValue("_id_Usuario", obj.id_Usuario);
                        command.Parameters.AddWithValue("_Apellido", obj.Apellido);
                        command.Parameters.AddWithValue("_Nombres", obj.Nombres);
                        command.Parameters.AddWithValue("_Nivel", obj.Nivel);
                        command.Parameters.AddWithValue("_Funcion", obj.Funcion);
                        command.Parameters.AddWithValue("_Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("_Clave", obj.Clave);
                        command.Parameters.AddWithValue("_Activo", obj.Activo);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
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

        //***** METODO PARA ELIMINAR UN USUARIO *****
        public bool Eliminar(CE_Usuarios obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Usuario", obj.id_Usuario);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
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
